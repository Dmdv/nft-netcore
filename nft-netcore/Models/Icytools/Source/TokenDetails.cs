// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Source;

public class TokenDetails
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("tokenId")]
    public string TokenId { get; set; }

    [JsonPropertyName("contract")]
    public TokenContract Contract { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("images")]
    public List<Image> Images { get; set; }
}

public class TokenContract
{
    [JsonPropertyName("address")]
    public string Address { get; set; }
}