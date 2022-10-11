using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Nft.Models.Icytools.Target;

namespace Nft.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class TrendingController : ControllerBase
{
    private readonly IGraphQLClient _client;
    private readonly IMapper _mapper;
    private readonly ILogger<TrendingController> _logger;

    // GET: Trending
    public TrendingController(IGraphQLClient client, IMapper mapper, ILogger<TrendingController> logger)
    {
        _client = client;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TrendingCollections> Get()
    {
        _logger.LogInformation("Fetching trending collection");
            
        var query = new GraphQLRequest
        {
            Query = @"
                        query Contracts($timePeriod: TrendingCollectionsTimePeriodEnum) {
                            trendingCollections(timePeriod: $timePeriod, orderBy: SALES) {
                                edges {
                                    cursor
                                    node {
                                        ... on ERC721Contract {
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
                                            stats {
                                                volume
                                                average
                                                ceiling
                                                floor
                                                totalSales                        
                                            }
                                        }
                                    }
                                }
                                pageInfo {
                                    hasNextPage
                                    hasPreviousPage
                                    startCursor
                                    endCursor
                                }
                            }
                        }
                        "
        };

        var resp = await _client.SendQueryAsync<Nft.Models.Icytools.Source.Data>(query);
        var dto = _mapper.Map<Data>(resp.Data);
        return dto.TrendingCollections;
    }

    // // GET: Trending/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }
}