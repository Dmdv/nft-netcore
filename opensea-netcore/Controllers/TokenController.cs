using Models;
using Microsoft.AspNetCore.Mvc;

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
    private readonly HttpClient _httpClient;

    public TokenController(ILogger<TokenController> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _httpClient = clientFactory.CreateClient("opensea");
        _logger.LogInformation("Started Token controller");
    }

    // GET: api/token/5/5
    [HttpGet("{assetContractAddress}/{tokenId}", Name = "Get")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Token))]
    public async Task<ContentResult> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);

        var url = $"api/v1/asset/{assetContractAddress}/{tokenId}/";
        var json = await _httpClient.GetStringAsync(url);

        return Content(json, ApplicationJson);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}