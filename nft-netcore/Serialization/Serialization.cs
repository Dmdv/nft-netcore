using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nft.Serialization;

internal class WeatherForecast
{
    public object? Data { get; set; }
    public List<object>? DataList { get; set; }
}

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(WeatherForecast))]
internal partial class WeatherForecastContext : JsonSerializerContext
{
}

// ReSharper disable once UnusedType.Global
internal class SerializationExample
{
    // ReSharper disable once UnusedMember.Global
    public static void Do()
    {
        WeatherForecast wf = new() { Data = true, DataList = new List<object> { true, 1 } };
        
        // NOTE: This is default serialization
        // var jsonString = JsonSerializer.Serialize(wf, WeatherForecastContext.Default.WeatherForecast);
        
        var jsonString = JsonSerializer.Serialize(
            wf,
            typeof(WeatherForecast),
            new WeatherForecastContext(
                new JsonSerializerOptions(JsonSerializerDefaults.Web)));
        
        _ = JsonSerializer.Deserialize(jsonString, WeatherForecastContext.Default.WeatherForecast);
    }
}