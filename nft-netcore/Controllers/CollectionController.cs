using System.Text;
using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nft.ArgumentsBinding;
using Nft.Models.Blockdaemon.Target;
using Nft.Models.Icytools.Target.CollectionItems;
using NuGet.Packaging.Signing;
using CommonSerializationContext = Nft.Serialization.CommonSerializationContext;
using TokenViewModel = Nft.Models.Blockdaemon.Target.TokenViewModel;

namespace Nft.Controllers;

[Route("[controller]")]
[Produces("application/json")]
[ApiController]
public class CollectionController : ControllerBase
{
    private readonly ILogger<CollectionController> _logger;
    private readonly IGraphQLClient _qlClient;

    private readonly IMemoryCache _cache;
    private readonly IMapper _mapper;

    // private readonly HttpClient _osClient;
    private readonly HttpClient _bdClient;
    private readonly int _minutesInCache;

    public CollectionController(
        ILogger<CollectionController> logger,
        IHttpClientFactory clientFactory,
        IGraphQLClient qlClient,
        IMemoryCache cache,
        IMapper mapper, 
        IConfiguration configuration
    )
    {
        _logger = logger;
        _qlClient = qlClient;
        _cache = cache;
        _mapper = mapper;
        // _osClient = clientFactory.CreateClient("opensea");
        _bdClient = clientFactory.CreateClient("blockdaemon");
        _logger.LogInformation("Started Token controller");
        _minutesInCache = Convert.ToInt32(configuration["MinutesInCache"]);
    }

    // This uses opensea (1 request)
    // 1. Collection info
    // 2. Items info + images

    // Example:
    // {{opensea_v1}}/assets?asset_contract_address={{nyoling_address}}&limit=2&order_direction=desc

    // GET: collection?address=""
    // [HttpGet(Name = "GetCollectionItems")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionContentViewModel))]
    // public async Task<CollectionContentViewModel> GetWithOpensea([FromQuery] CollectionArgs args)
    // {
    //     _logger.LogInformation("Collection: {AssetContractAddress}", args.Address);
    //         
    //     var uriBuilder = new StringBuilder($"api/v1/assets?asset_contract_address={args.Address}");
    //
    //     if (!string.IsNullOrWhiteSpace(args.Cursor))
    //     {
    //         uriBuilder.Append("&cursor=").Append(args.Cursor);
    //     }
    //     if (args.Limit != null)
    //     {
    //         uriBuilder.Append("&limit=").Append(args.Limit);
    //     }
    //     if (args.OrderDirection != null)
    //     {
    //         uriBuilder.Append("&order_direction=").Append(args.OrderDirection.String().ToLower());
    //     }
    //     
    //     var resp = await _osClient.GetAsync(uriBuilder.ToString());
    //     resp.EnsureSuccessStatusCode();
    //     var model = await resp.Content.ReadFromJsonAsync(CommonSerializationContext.Default.CollectionContentModel);
    //     var collection = _mapper.Map<CollectionContentViewModel>(model);
    //
    //     return collection;
    // }


    // 1. This uses blockdaemon to fetch items
    // 2. Uses ICYTOOLS to fetch item images

    // Example:
    // {{BLOCKDAEMON_NFT_URL_REST}}/assets?contract_address={{nyoling_address}}&page_size=10&sort_by=mint_date

    // GET: collection?address=""
    // [HttpGet(Name = "GetCollectionItems")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionContentViewModel))]
    // public async Task<CollectionContentViewModel> GetWithBlockdaemon([FromQuery] CollectionArgs args)
    // {
    //     _logger.LogInformation("Collection: {AssetContractAddress}", args.Address);
    //
    //     var uriBuilder = new StringBuilder($"assets?contract_address={args.Address}&sort_by=mint_date");
    //
    //     if (args.Cursor != null)
    //     {
    //         uriBuilder.Append("&page_token=").Append(args.Cursor);
    //     }
    //
    //     if (args.Limit != null)
    //     {
    //         uriBuilder.Append("&page_size=").Append(args.Limit);
    //     }
    //
    //     if (args.OrderDirection != null)
    //     {
    //         uriBuilder.Append("&order=").Append(args.OrderDirection.String().ToLower());
    //     }
    //
    //     Models.Blockdaemon.Source.Assets.AssetRoot? model;
    //     using (var resp = await _bdClient.GetAsync(uriBuilder.ToString()))
    //     {
    //         resp.EnsureSuccessStatusCode();
    //         model = await resp.Content.ReadFromJsonAsync(CommonSerializationContext.Default.AssetRoot);
    //     }
    //
    //     var collection = _mapper.Map<CollectionContentViewModel>(model);
    //     var assets = new List<TokenViewModel>();
    //
    //     var tasks = new List<Task>(collection.Tokens.Count);
    //     foreach (var asset in collection.Tokens)
    //     {
    //         var key = $"{asset.ContractAddress}:{asset.TokenId}";
    //         if (_cache.TryGetValue(key, out TokenViewModel assetVm))
    //         {
    //             assets.Add(assetVm);
    //             continue;
    //         }
    //
    //         assets.Add(asset);
    //
    //         var task = Task.Run(async () =>
    //         {
    //             var contractAddress = $"contractAddress: \"{asset.ContractAddress}\"";
    //             var tokenId = $"tokenId: \"{asset.TokenId}\"";
    //
    //             var qlRequest = new GraphQLRequest
    //             {
    //                 Query = $@"
    //                   query TokenImages {{
    //                       token(
    //                                 {contractAddress},
    //                                 {tokenId},
    //                             ) {{
    //                                 ... on ERC721Token {{
    //                                 images {{
    //                                     url
    //                                     width
    //                                     height
    //                                     mimeType
    //                                 }}
    //                               }}
    //                             }}
    //                           }}
    //                 "
    //             };
    //             
    //             var qlResp = await _qlClient.SendQueryAsync<Models.Icytools.Source.Images.ImageData>(qlRequest);
    //             if (qlResp.Errors?.Length > 0)
    //             {
    //                 var httpResp = qlResp.AsGraphQLHttpResponse();
    //                 var msg = qlResp.Errors.First().Message;
    //                 var error = $"GraphQL query was not success, Status code: {httpResp.StatusCode}, Reason: {msg}";
    //                 _logger.LogError(
    //                     "Fetching images for contract: {AssetContractAddress}, tokenID: {AssetTokenId}, error: {Error}",
    //                     asset.ContractAddress, asset.TokenId, error);
    //                 return;
    //             }
    //             
    //             var images = qlResp.Data.TokenDetail.Images;
    //
    //             foreach (var image in images)
    //             {
    //                 switch (image.Height)
    //                 {
    //                     case 100:
    //                         asset.Image100Url = image.Url;
    //                         break;
    //                     case 200:
    //                         asset.Image200Url = image.Url;
    //                         break;
    //                     case 400:
    //                         asset.Image400Url = image.Url;
    //                         break;
    //                     case 800:
    //                         asset.Image800Url = image.Url;
    //                         break;
    //                     case 1200:
    //                         asset.Image1200Url = image.Url;
    //                         break;
    //                 }
    //             }
    //
    //             _cache.Set(key, asset, TimeSpan.FromMinutes(100));
    //         });
    //         
    //         tasks.Add(task);
    //     }
    //
    //     await Task.WhenAll(tasks);
    //
    //     collection.Tokens = assets;
    //
    //     return collection;
    // }

    // private record Token(string Address, string TokenId);

    [HttpGet(Name = "GetCollectionItems")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionItemsViewModel))]
    public async Task<CollectionItemsViewModel> GetWithIcytools([FromQuery] CollectionArgs args)
    {
        _logger.LogInformation("Collection: {AssetContractAddress}", args.Address);

        var addressFilter = $"\"{args.Address}\"";
        var tokensFilter = "";

        var filters = new List<string>();
        if (!string.IsNullOrWhiteSpace(args.Cursor))
        {
            filters.Add($"after: \"{args.Cursor}\"");
        }
        if (args.Limit != null)
        {
            filters.Add($"first: {args.Limit}");
        }

        if (filters.Count > 0)
        {
            var sb = new StringBuilder().AppendJoin(',', filters);
            tokensFilter = $"({sb})";
        }

        var qlRequest = new GraphQLRequest
        {
            Query = $@"
                    query CollectionItems {{
                      contract(address: {addressFilter}) {{
                        ... on ERC721Contract {{
                                symbol
                                name
                                circulatingSupply
                                stats {{
                                    floor
                                    volume
                                    totalSales
                                    ceiling
                                    average
                                }}
                                unsafeOpenseaBannerImageUrl
                                unsafeOpenseaDescription
                                unsafeOpenseaImageUrl
                                unsafeOpenseaSlug
                                unsafeOpenseaExternalUrl
                                isVerified
                                tokenStandard
                            }}
                            tokens {tokensFilter} {{
                                edges {{
                                    cursor
                                    node {{
                                        ... on ERC721Token {{
                                            name
                                            tokenId
                                            contract {{
                                                address
                                            }}
                                            metadata {{
                                                animation_url
                                                description
                                                external_url
                                                youtube_url
                                            }}
                                        }}
                                        images {{
                                            width
                                            height
                                            url
                                        }}
                                    }}
                                }}
                                pageInfo {{
                                    hasNextPage
                                    hasPreviousPage
                                    startCursor
                                    endCursor
                                }}
                             }}
                          }}
                       }}
            "
        };

        var qlResp = await _qlClient.SendQueryAsync<Models.Icytools.Source.CollectionItems.ContractData>(qlRequest);
        if (qlResp.Errors?.Length > 0)
        {
            var httpResp = qlResp.AsGraphQLHttpResponse();
            var msg = qlResp.Errors.First().Message;
            var error = $"GraphQL query was not success, Status code: {httpResp.StatusCode}, Reason: {msg}";
            _logger.LogError(
                "Fetching images for contract: {AssetContractAddress}, tokenID: {AssetTokenId}, error: {Error}",
                "asset.ContractAddress", "asset.TokenId", error);

            throw new HttpRequestException(error, inner: null, httpResp.StatusCode);
        }

        var collection = _mapper.Map<CollectionItemsViewModel>(qlResp.Data);

        return collection;
    }
}