using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Nft.Helpers;
using Nft.Models.Opensea.Source;

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
    public async Task<Token?> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);
        
        var key = $"{assetContractAddress}/{tokenId}";
        if (!_cache.TryGetValue(key, out Token? token) || token == null)
        {
            var url = $"api/v1/asset/{key}/";
            var resp = await _httpClient.GetAsync(url);
            resp.EnsureSuccessStatusCode();

            token = await resp.Content.ReadFromJsonAsync(SerializationContext.Default.Token);
            
            _cache.Set(key, token, TimeSpan.FromMinutes(_minutesInCache));
        }
        
        return token;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}