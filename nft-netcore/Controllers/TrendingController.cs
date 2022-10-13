using System.Text;
using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Abstractions.Utilities;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nft.ArgumentsBinding;

namespace Nft.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class TrendingController : ControllerBase
{
    private readonly IGraphQLClient _client;
    private readonly IMapper _mapper;
    private readonly IMemoryCache _cache;
    private readonly ILogger<TrendingController> _logger;

    // GET: Trending
    public TrendingController(IGraphQLClient client, IMapper mapper, IMemoryCache cache, ILogger<TrendingController> logger)
    {
        _client = client;
        _mapper = mapper;
        _cache = cache;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<Models.Icytools.Target.TrendingCollections?> Get([FromQuery] TrendingArgs args)
    {
        var key = args.ToString();
        
        _logger.LogInformation(@"Fetching trending collection {Name}", key);
        
        List<string> sc = new ();

        if (args.First != null)
        {
            sc.Add($"first: {args.First}");
        }
        if (args.OrderBy != null)
        {
            sc.Add($"orderBy: {args.OrderBy.String().ToUpper()}");
        }
        if (args.OrderDirection != null)
        {
            sc.Add($"orderDirection: {args.OrderDirection.String().ToUpper()}");
        }
        if (args.TimePeriod != null)
        {
            sc.Add($"timePeriod: {args.TimePeriod.String().ToUpper()}");
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

        if (args.Markets != null)
        {
            // =====================================
            // Example:
            // var str = @"{ in:[ZEROX,LOOKSRARE] }";
            // =====================================

            var markets = new StringBuilder().AppendJoin(",", args.Markets.Market.Select(x => x.String().ToUpper()));
            var str = @$"{{ {args.Markets.Op.String().ToLowerFirst()} :[{markets}] }}";
            sc.Add($"marketplace: {str}");
        }
        
        var sb = new StringBuilder().AppendJoin(", ", sc);

        var query = new GraphQLRequest
        {
            Query = $@"
                        query Contracts {{
                            trendingCollections({sb}) {{
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
                        ",
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

        if (args.Refresh)
        {
            _cache.Remove(key);
        }

        return _cache.GetOrCreateAsync(key, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            var resp = await _client.SendQueryAsync<Models.Icytools.Source.Data>(query);
            if (resp.Errors?.Length > 0)
            {
                var httpResp = resp.AsGraphQLHttpResponse();
                var msg = resp.Errors.First().Message;
                var error = $"GraphQL query was not success, Status code: {httpResp.StatusCode}, Reason: {msg}";
                throw new HttpRequestException(error, inner: null, httpResp.StatusCode);
            }
            
            var dto = _mapper.Map<Models.Icytools.Target.Data>(resp.Data);
            return dto.TrendingCollections;
        });
    }

    // // GET: Trending/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }
}