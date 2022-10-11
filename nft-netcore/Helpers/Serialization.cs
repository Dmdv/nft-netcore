using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nft.Helpers;

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

internal class SerializationExample
{
    public void Do()
    {
        WeatherForecast wf = new() { Data = true, DataList = new List<object> { true, 1 } };
        
        var jsonString = JsonSerializer.Serialize(wf, WeatherForecastContext.Default.WeatherForecast);
        
        jsonString = JsonSerializer.Serialize(
            wf,
            typeof(WeatherForecast),
            new WeatherForecastContext(
                new JsonSerializerOptions(JsonSerializerDefaults.Web)));
        
        var weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(
            jsonString, WeatherForecastContext.Default.WeatherForecast);
    }
}