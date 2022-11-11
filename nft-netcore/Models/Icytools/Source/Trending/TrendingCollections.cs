// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Source.Trending;

public class TrendingData
{
    [JsonPropertyName("trendingCollections")]
    public TrendingCollections TrendingCollections { get; set; }
}

public class TrendingCollections
{
    [JsonPropertyName("edges")]
    public List<Edge> Edges { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }
}