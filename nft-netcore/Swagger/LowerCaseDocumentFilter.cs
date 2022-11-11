// ReSharper disable ClassNeverInstantiated.Global

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nft.Swagger;

/// <summary>
/// Swagger documentation posted in lowercase
/// </summary>
public class LowerCaseDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var paths = swaggerDoc
            .Paths
            .ToDictionary(
                entry => LowercaseEverythingButParameters(entry.Key),
                entry => entry.Value);
        
        swaggerDoc.Paths = new OpenApiPaths();
        
        foreach (var (key, value) in paths)
        {
            swaggerDoc.Paths.Add(key, value);
        }
    }

    private static string LowercaseEverythingButParameters(string key) =>
        string
            .Join('/', key.Split('/')
            .Select(x => x.Contains('{') ? x : x.ToLower()));
}