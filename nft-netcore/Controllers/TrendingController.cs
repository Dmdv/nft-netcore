using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
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
    public Task<Models.Icytools.Target.TrendingCollections> Get([FromQuery] TrendingArgs args)
    {
        var key = $"trending-orderby:{args.OrderBy}-sort:{args.SortDirection}";
        
        _logger.LogInformation(@"Fetching trending collection {Name}", key);
        
        var query = new GraphQLRequest
        {
            Query = $@"
                        query Contracts($timePeriod: TrendingCollectionsTimePeriodEnum) {{
                            trendingCollections(timePeriod: $timePeriod, orderBy: {args.OrderBy.ToString().ToUpper()}) {{
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
        };

        return _cache.GetOrCreateAsync(key, async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            var resp = await _client.SendQueryAsync<Models.Icytools.Source.Data>(query);
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