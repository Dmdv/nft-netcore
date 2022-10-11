using System.Text.Json.Serialization;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class Data
{
    [JsonPropertyName("trendingCollections")]
    public TrendingCollections TrendingCollections { get; set; }
}

public class Edge
{
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; }

    [JsonPropertyName("collection")]
    public Node Node { get; set; }
}

public class Node
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }

    [JsonPropertyName("isVerified")]
    public bool IsVerified { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("tokenStandard")]
    public string TokenStandard { get; set; }

    [JsonPropertyName("circulatingSupply")]
    public int CirculatingSupply { get; set; }

    [JsonPropertyName("unsafeOpenseaBannerImageUrl")]
    public string UnsafeOpenseaBannerImageUrl { get; set; }

    [JsonPropertyName("unsafeOpenseaDescription")]
    public string UnsafeOpenseaDescription { get; set; }

    [JsonPropertyName("unsafeOpenseaImageUrl")]
    public string UnsafeOpenseaImageUrl { get; set; }

    [JsonPropertyName("unsafeOpenseaSlug")]
    public string UnsafeOpenseaSlug { get; set; }

    [JsonPropertyName("unsafeOpenseaExternalUrl")]
    public string UnsafeOpenseaExternalUrl { get; set; }

    [JsonPropertyName("stats")]
    public Stats Stats { get; set; }
}

public class PageInfo
{
    [JsonPropertyName("hasNextPage")]
    public bool HasNextPage { get; set; }

    [JsonPropertyName("hasPreviousPage")]
    public bool HasPreviousPage { get; set; }

    [JsonPropertyName("startCursor")]
    public string StartCursor { get; set; }

    [JsonPropertyName("endCursor")]
    public string EndCursor { get; set; }
}

public class Root
{
    [JsonPropertyName("data")]
    public Data Data { get; set; }
}

public class Stats
{
    [JsonPropertyName("volume")]
    public double Volume { get; set; }

    [JsonPropertyName("average")]
    public double Average { get; set; }

    [JsonPropertyName("ceiling")]
    public double Ceiling { get; set; }

    [JsonPropertyName("floor")]
    public double Floor { get; set; }

    [JsonPropertyName("totalSales")]
    public int TotalSales { get; set; }
}

public class TrendingCollections
{
    [JsonPropertyName("collections")]
    public List<Edge> Edges { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }
}