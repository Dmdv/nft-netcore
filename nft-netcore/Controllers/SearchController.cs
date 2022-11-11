using System.Text;
using AutoMapper;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nft.ArgumentsBinding;
using Nft.Models.Icytools.Target.Search;

namespace Nft.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly IGraphQLClient _client;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ILogger<SearchController> _logger;

        public SearchController(
            IGraphQLClient client,
            IMapper mapper,
            IMemoryCache cache,
            ILogger<SearchController> logger)
        {
            _client = client;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        // GET: search?symbol=[in]abc&address=[eq]0xabc&name=[icontains]abc
        [HttpGet(Name = "FindCollection")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ContractsViewModel))]
        public async Task<ContractsViewModel> Get([FromQuery] SearchArgs query)
        {
            _logger.LogInformation(@"Searching for collection {Name}", query.ToString());

            List<string> paramArr = new();

            if (!string.IsNullOrWhiteSpace(query.After))
            {
                paramArr.Add($"after: \"{query.After}\"");
            }

            if (query.First != null && query.First != 0)
            {
                paramArr.Add($"first: {query.First}");
            }

            // Filter
            List<string> filters = new();
            if (query.Name != null)
            {
                filters.Add($"name:  {{ {query.Name.Op.String().ToLower()} : \"{query.Name.Value}\" }}");
            }

            if (query.Address != null)
            {
                filters.Add($"address:  {{ eq : \"{query.Address}\" }}");
            }

            if (query.Symbol != null)
            {
                filters.Add($"symbol:  {{ {query.Symbol.Op.String().ToLower()} : \"{query.Symbol.Value}\" }}");
            }

            if (filters.Count != 0)
            {
                var sb = new StringBuilder().AppendJoin(", ", filters);
                var filter = @$"filter: {{ {sb} }}";
                paramArr.Add(filter);
            }

            var param = string.Empty;
            if (paramArr.Count > 0)
            {
                var sb = new StringBuilder().AppendJoin(", ", paramArr);
                param = $"({sb})";
            }

            _logger.LogInformation(@"Filter applied: {Param}", param);

            var qlRequest = new GraphQLRequest
            {
                Query = $@"
                            query SearchCollections {{
                              contracts {param} {{
                                edges {{
                                  node {{
                                    address
                                    isVerified
                                    tokenStandard
                                    ... on ERC721Contract {{
                                      stats {{
                                        average
                                        ceiling
                                        floor
                                        totalSales
                                        volume
                                      }}
                                      name
                                      symbol
                                      unsafeOpenseaDescription
                                      unsafeOpenseaImageUrl
                                      unsafeOpenseaSlug
                                      unsafeOpenseaExternalUrl
                                      unsafeOpenseaBannerImageUrl
                                      circulatingSupply
                                    }}
                                  }}
                                  cursor
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

            var resp = await _client.SendQueryAsync<Models.Icytools.Source.Search.Content>(qlRequest);
            if (resp.Errors?.Length > 0)
            {
                var httpResp = resp.AsGraphQLHttpResponse();
                var msg = resp.Errors.First().Message;
                var error = $"GraphQL query was not success, Status code: {httpResp.StatusCode}, Reason: {msg}";
                throw new HttpRequestException(error, inner: null, httpResp.StatusCode);
            }

            var dto = _mapper.Map<ContractsViewModel>(resp.Data.Contracts);
            dto.Count = dto.Contracts.Count;

            return dto;
        }
    }
}