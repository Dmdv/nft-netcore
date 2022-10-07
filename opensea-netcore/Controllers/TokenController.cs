using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Opensea.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TokenController : ControllerBase, IDisposable
{
    static TokenController()
    {
        ApplicationJson = Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json");
    }

    private static readonly Microsoft.Net.Http.Headers.MediaTypeHeaderValue? ApplicationJson;
    private readonly ILogger<TokenController> _logger;
    private readonly IMemoryCache _cache;
    private readonly HttpClient _httpClient;

    public TokenController(
        ILogger<TokenController> logger, 
        IHttpClientFactory clientFactory,
        IMemoryCache cache)
    {
        _logger = logger;
        _cache = cache;
        _httpClient = clientFactory.CreateClient("opensea");
        _logger.LogInformation("Started Token controller");
    }

    // GET: api/token/5/5
    [HttpGet("{assetContractAddress}/{tokenId}", Name = "Get")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Token))]
    public async Task<ContentResult> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);
        
        var key = $"{assetContractAddress}_{tokenId}";
        if (!_cache.TryGetValue(key, out string json))
        {
            _logger.LogInformation("Initializing cache");
            var url = $"api/v1/asset/{assetContractAddress}/{tokenId}/";
            json = await _httpClient.GetStringAsync(url);
            _cache.Set(key, json, TimeSpan.FromMinutes(10));
        }

        return Content(json, ApplicationJson);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}