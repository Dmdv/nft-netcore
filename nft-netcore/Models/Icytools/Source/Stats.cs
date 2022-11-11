// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Source;

public class Stats
{
    [JsonPropertyName("volume")]
    public double? Volume { get; set; }

    [JsonPropertyName("average")]
    public double? Average { get; set; }

    [JsonPropertyName("ceiling")]
    public double? Ceiling { get; set; }

    [JsonPropertyName("floor")]
    public double? Floor { get; set; }

    [JsonPropertyName("totalSales")]
    public int? TotalSales { get; set; }
}