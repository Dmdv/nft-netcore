using System.Text.Json.Serialization;

namespace Nft.Helpers;

[JsonSourceGenerationOptions(
    GenerationMode = JsonSourceGenerationMode.Default,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(Token))]
[JsonSerializable(typeof(Owner))]
[JsonSerializable(typeof(Collection))]
[JsonSerializable(typeof(Creator))]
[JsonSerializable(typeof(Stats))]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(LastSale))]
[JsonSerializable(typeof(PaymentToken))]
[JsonSerializable(typeof(AssetContract))]
[JsonSerializable(typeof(Asset))]
[JsonSerializable(typeof(TopOwnership))]
[JsonSerializable(typeof(Trait))]
internal partial class SerializationContext : JsonSerializerContext
{
}