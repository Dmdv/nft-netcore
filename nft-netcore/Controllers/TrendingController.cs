using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Nft.Models.Icytools;

namespace Nft.Controllers;

[Route("[controller]")]
[ApiController]
[Produces("application/json")]
public class TrendingController : ControllerBase
{
    private readonly IGraphQLClient _client;
    private readonly ILogger<TrendingController> _logger;

    // GET: Trending
    public TrendingController(IGraphQLClient client, ILogger<TrendingController> logger)
    {
        _client = client;
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

        var json = await _client.SendQueryAsync<TrendingCollectionsRoot>(query);

        return json.Data.TrendingCollections;
    }

    // // GET: Trending/5
    // [HttpGet("{id}", Name = "Get")]
    // public string Get(int id)
    // {
    //     return "value";
    // }
}