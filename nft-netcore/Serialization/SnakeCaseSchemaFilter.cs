using GraphQL.Client.Abstractions.Utilities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nft.Serialization;

// ReSharper disable once UnusedType.Global
public class SnakeCaseSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (schema.Properties == null) return;
        if (schema.Properties.Count == 0) return;

        var newProperties = new Dictionary<string, OpenApiSchema>();
        foreach (var key in schema.Properties.Keys)
        {
            newProperties[key.ToSnakeCase()] = schema.Properties[key];
        }

        schema.Properties = newProperties;
    }
}