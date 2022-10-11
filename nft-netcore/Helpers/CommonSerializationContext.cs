using System.Text.Json.Serialization;

namespace Nft.Helpers;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Models.Opensea.Source.OpenseaRoot))]
[JsonSerializable(typeof(Models.Icytools.Source.IcytoolsRoot))]
internal partial class CommonSerializationContext : JsonSerializerContext
{
}