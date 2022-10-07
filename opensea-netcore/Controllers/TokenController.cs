using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Opensea.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase, IDisposable
{
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
    [ProducesResponseType(StatusCodes.Status200OK , Type = typeof(Token))]
    public async Task<IResult> Get(string assetContractAddress, string tokenId)
    {
        _logger.LogInformation("Token: {AssetContractAddress} and {TokenId}", assetContractAddress, tokenId);
        
        var url = $"api/v1/asset/{assetContractAddress}/{tokenId}/";
        var json = await _httpClient.GetStringAsync(url);
        
        return Results.Json(json);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}