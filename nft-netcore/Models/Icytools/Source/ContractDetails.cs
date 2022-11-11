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

public class ContractDetails
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
    
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("isVerified")]
    public bool? IsVerified { get; set; }
    
    [JsonPropertyName("tokenStandard")]
    public string? TokenStandard { get; set; }

    [JsonPropertyName("circulatingSupply")]
    public int? CirculatingSupply { get; set; }
    
    [JsonPropertyName("stats")]
    public Stats? Stats { get; set; }
    
    // Opensea data

    [JsonPropertyName("unsafeOpenseaBannerImageUrl")]
    public string OpenseaBannerImageUrl { get; set; }

    [JsonPropertyName("unsafeOpenseaDescription")]
    public string OpenseaDescription { get; set; }

    [JsonPropertyName("unsafeOpenseaImageUrl")]
    public string OpenseaImageUrl { get; set; }

    [JsonPropertyName("unsafeOpenseaSlug")]
    public string OpenseaSlug { get; set; }

    [JsonPropertyName("unsafeOpenseaExternalUrl")]
    public string OpenseaExternalUrl { get; set; }
    
    // Tokens
    [JsonPropertyName("tokens")]
    public TokensPage Tokens { get; set; }
}