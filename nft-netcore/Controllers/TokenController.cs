using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Nft.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TokenController : ControllerBase, IDisposable
{
    private static readonly Microsoft.Net.Http.Headers.MediaTypeHeaderValue? ApplicationJson;
    private readonly ILogger<TokenController> _logger;
    private readonly IMemoryCache _cache;
    private readonly HttpClient _httpClient;
    private readonly int _minutesInCache;

    public TokenController(
        ILogger<TokenController> logger, 
        IHttpClientFactory clientFactory,
        IMemoryCache cache,
        IConfiguration configuration)
    {
        _logger = logger;
        _cache = cache;
        _httpClient = clientFactory.CreateClient("opensea");
        _logger.LogInformation("Started Token controller");
        _minutesInCache = Convert.ToInt32(configuration["MinutesInCache"]);
    }
    
    static TokenController()
    {
        ApplicationJson = Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
    }

    // GET: token/5/5
    [HttpGet("{assetContractAddress}/{tokenId}", Name = "GetToken")]
    public async Task<Root?> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);
        
        var key = $"{assetContractAddress}_{tokenId}";
        if (!_cache.TryGetValue(key, out string json))
        {
            _logger.LogInformation("Initializing cache");
            var url = $"api/v1/asset/{assetContractAddress}/{tokenId}/";
            json = await _httpClient.GetStringAsync(url);
            // Is it faster?
            // var data = await _httpClient.GetAsync(url);
            // json = await data.Content.ReadAsStringAsync();
            _cache.Set(key, json, TimeSpan.FromMinutes(_minutesInCache));
        }

        var token = JsonSerializer.Deserialize<Root>(json);

        return token;
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}