using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Client.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Opensea.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TrendingController : ControllerBase
    {
        private static readonly Microsoft.Net.Http.Headers.MediaTypeHeaderValue? ApplicationJson;
        private readonly IGraphQLClient _client;
        private readonly ILogger<TrendingController> _logger;

        static TrendingController()
        {
            ApplicationJson = Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
        }

        // GET: Trending
        public TrendingController(IGraphQLClient client, ILogger<TrendingController> logger)
        {
            _client = client;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ContentResult> Get()
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

            var json = await _client.SendQueryAsync<object>(query);

            return Content(json.Data.ToJson(), ApplicationJson);
        }

        // // GET: Trending/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
    }
}