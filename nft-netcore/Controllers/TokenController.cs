using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nft.Models.Opensea.Source.Token;
using CommonSerializationContext = Nft.Serialization.CommonSerializationContext;

namespace Nft.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TokenController : ControllerBase, IDisposable
{
    private readonly ILogger<TokenController> _logger;
    private readonly IMemoryCache _cache;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;
    private readonly int _minutesInCache;

    public TokenController(
        ILogger<TokenController> logger,
        IHttpClientFactory clientFactory,
        IMemoryCache cache,
        IMapper mapper,
        IConfiguration configuration)
    {
        _logger = logger;
        _cache = cache;
        _mapper = mapper;
        _httpClient = clientFactory.CreateClient("opensea");
        _logger.LogInformation("Started Token controller");
        _minutesInCache = Convert.ToInt32(configuration["MinutesInCache"]);
    }

    // GET: token/5/5
    [HttpGet("{assetContractAddress}/{tokenId}", Name = "GetToken")]
    public async Task<Models.Opensea.Target.Token.TokenViewModel?> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);
        
        var requestUri = $"api/v1/asset/{assetContractAddress}/{tokenId}/";
        if (!_cache.TryGetValue(requestUri, out Models.Opensea.Target.Token.TokenViewModel? token) || token == null)
        {
            TokenModel? model;
            using (var resp = await _httpClient.GetAsync(requestUri))
            {
                resp.EnsureSuccessStatusCode();
                model = await resp.Content.ReadFromJsonAsync(CommonSerializationContext.Default.TokenModel);
            }

            token = _mapper.Map<Models.Opensea.Target.Token.TokenViewModel>(model);
            
            _cache.Set(requestUri, token, TimeSpan.FromMinutes(_minutesInCache));
        }
        
        return token;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}