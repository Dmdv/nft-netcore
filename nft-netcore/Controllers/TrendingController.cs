using System.Text;
using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Abstractions.Utilities;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Nft.ArgumentsBinding;
using Nft.Serialization;

namespace Nft.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class TrendingController : ControllerBase
{
    private readonly IGraphQLClient _client;
    private readonly IMapper _mapper;
    private readonly ILogger<TrendingController> _logger;
    private readonly IDistributedCache _cache;
    private readonly int _slidingExpiration;
    private readonly int _absoluteExpiration;

    public TrendingController(
        IGraphQLClient client, 
        IMapper mapper,
        IDistributedCache cache,
        IConfiguration configuration,
        ILogger<TrendingController> logger)
    {
        _client = client;
        _mapper = mapper;
        _cache = cache;
        _logger = logger;
        _slidingExpiration = Convert.ToInt32(configuration["TrendingSlidingExpiration"]) | 1;
        _absoluteExpiration = Convert.ToInt32(configuration["TrendingAbsoluteExpiration"]) | 5;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Models.Icytools.Target.Trending.TrendingCollectionsVm?> Get([FromQuery] TrendingArgs query)
    {
        var key = query.ToString();

        _logger.LogInformation(@"Fetching trending collection {Query}", Request.GetEncodedPathAndQuery());
        _logger.LogInformation(@"Fetching trending collection {Name}", key);
        
        List<string> paramArr = new ();

        if (!string.IsNullOrWhiteSpace(query.After))
        {
            paramArr.Add($"after: \"{query.After}\"");
        }
        if (query.First != null && query.First != 0)
        {
            paramArr.Add($"first: {query.First}");
        }

        if (query.OrderBy != null)
        {
            paramArr.Add($"orderBy: {query.OrderBy.String().ToUpper()}");
        }
        if (query.OrderDirection != null)
        {
            paramArr.Add($"orderDirection: {query.OrderDirection.String().ToUpper()}");
        }
        if (query.TimePeriod != null)
        {
            paramArr.Add($"timePeriod: {query.TimePeriod.String().ToUpper()}");
        }

        // ============================================
        // Use this if want to pass variable explicitly
        // var marketplace = new
        // {
        //     In = new[] { "LOOKSRARE" }
        // };
        // query Contracts(marketplace: $marketplace)
        // and add to list 
        // sc.Add($"marketplace: $marketplace");
        // ============================================

        if (query.Markets is { Op: EqualityInput.In or EqualityInput.NotIn })
        {
            // =====================================
            // Example:
            // var str = @"{ in:[ZEROX,LOOKSRARE] }";
            // =====================================

            var markets = new StringBuilder().AppendJoin(",", query.Markets.Market.Select(x => x.String().ToUpper()));
            var str = @$"{{{query.Markets.Op.String().ToLowerFirst()}:[{markets}]}}";
            paramArr.Add($"marketplace: {str}");
        }
        
        if (query.Markets is { Op: EqualityInput.Eq } market)
        {
            // =====================================
            // Example:
            // var str = @"{ eq: CRYPTOPUNKS }";
            // =====================================

            paramArr.Add($"marketplace: {{eq: {market.Market.First().String().ToUpper()}}}");
        }


        var filter = string.Empty;
        if (paramArr.Count > 0)
        {
            var sb = new StringBuilder().AppendJoin(", ", paramArr);
            filter = $"({sb})";
        }

        _logger.LogInformation(@"Filter applied {Filter}", filter);

        var qlRequest = new GraphQLRequest
        {
            Query = $@"
                        query Contracts {{
                            trendingCollections {filter} {{
                                edges {{
                                    cursor
                                    node {{
                                        ... on ERC721Contract {{
                                            name
                                            symbol
                                            isVerified
                                            address
                                            tokenStandard
                                            circulatingSupply      
                                            unsafeOpenseaBannerImageUrl
                                            unsafeOpenseaDescription
                                            unsafeOpenseaImageUrl
                                            unsafeOpenseaSlug
                                            unsafeOpenseaExternalUrl               
                                            stats {{
                                                volume
                                                average
                                                ceiling
                                                floor
                                                totalSales                        
                                            }}
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
                        "
            // ============================================
            // Use this if want to pass variables explicitly
            // Variables = new
            // {
            //     marketplace = new
            //     {
            //         In = new[] { "LOOKSRARE" }
            //     }
            // }
            // ============================================
        };

        if (query.Refresh)
        {
            await _cache.RemoveAsync(key);
        }

        var cacheItem = await _cache.GetAsync(key);
        if (cacheItem == null)
        {
            var resp = await _client.SendQueryAsync<Models.Icytools.Source.Trending.TrendingData>(qlRequest);
            if (resp.Errors?.Length > 0)
            {
                var httpResp = resp.AsGraphQLHttpResponse();
                var msg = resp.Errors.First().Message;
                var error = $"GraphQL query was not success, Status code: {httpResp.StatusCode}, Reason: {msg}";
                throw new HttpRequestException(error, inner: null, httpResp.StatusCode);
            }

            var cachedDto = _mapper.Map<Models.Icytools.Target.Trending.TrendingDataViewModel>(resp.Data);

            await UpdateRedisItem(cachedDto, key).ConfigureAwait(false);
            
            return cachedDto.TrendingCollections;
        }

        var dto = System.Text.Json.JsonSerializer.Deserialize(cacheItem, CommonSerializationContext.Default.TrendingDataViewModel);
        return dto?.TrendingCollections;
    }

    private async Task UpdateRedisItem(Models.Icytools.Target.Trending.TrendingDataViewModel dto, string key)
    {
        var options = new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(DateTime.Now.AddMinutes(_absoluteExpiration))
            .SetSlidingExpiration(TimeSpan.FromMinutes(_slidingExpiration));
        var value = System.Text.Json.JsonSerializer.Serialize(dto, CommonSerializationContext.Default.TrendingDataViewModel);

        await _cache.SetAsync(key, Encoding.ASCII.GetBytes(value), options);
    }
}