using System.Text.Json.Serialization;

namespace Nft.Serialization;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Models.Opensea.Source.Token.TokenModel))]
[JsonSerializable(typeof(Models.Opensea.Source.Collection.CollectionContentModel))]
[JsonSerializable(typeof(Models.Icytools.Source.Trending.TrendingData))]
[JsonSerializable(typeof(Models.Icytools.Source.Search.Content))]
[JsonSerializable(typeof(Models.Icytools.Source.Search.Contracts))]
[JsonSerializable(typeof(Models.Icytools.Source.Images.ImageModel))]
[JsonSerializable(typeof(Models.Icytools.Source.CollectionItems.CollectionItems))]
[JsonSerializable(typeof(Models.Blockdaemon.Source.Assets.AssetRoot))]
[JsonSerializable(typeof(Models.Icytools.Target.Trending.TrendingDataViewModel))]
internal partial class CommonSerializationContext : JsonSerializerContext
{
}