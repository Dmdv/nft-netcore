using System.Text.Json.Serialization;

namespace Nft.Models.Icytools;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Edge(
    [property: JsonPropertyName("cursor")] string Cursor,
    [property: JsonPropertyName("node")] Node Nodes
);

public record Node(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("isVerified")] bool IsVerified,
    [property: JsonPropertyName("address")] string Address,
    [property: JsonPropertyName("tokenStandard")] string TokenStandard,
    [property: JsonPropertyName("circulatingSupply")] int CirculatingSupply,
    [property: JsonPropertyName("unsafeOpenseaBannerImageUrl")] string UnsafeOpenseaBannerImageUrl,
    [property: JsonPropertyName("unsafeOpenseaDescription")] string UnsafeOpenseaDescription,
    [property: JsonPropertyName("unsafeOpenseaImageUrl")] string UnsafeOpenseaImageUrl,
    [property: JsonPropertyName("unsafeOpenseaSlug")] string UnsafeOpenseaSlug,
    [property: JsonPropertyName("unsafeOpenseaExternalUrl")] string UnsafeOpenseaExternalUrl,
    [property: JsonPropertyName("stats")] TrendingStats Stats
);

public record PageInfo(
    [property: JsonPropertyName("hasNextPage")] bool HasNextPage,
    [property: JsonPropertyName("hasPreviousPage")] bool HasPreviousPage,
    [property: JsonPropertyName("startCursor")] string StartCursor,
    [property: JsonPropertyName("endCursor")] string EndCursor
);

public record TrendingCollectionsRoot(
    [property: JsonPropertyName("trendingCollections")] TrendingCollections TrendingCollections
);

public record TrendingStats(
    [property: JsonPropertyName("volume")] double Volume,
    [property: JsonPropertyName("average")] double Average,
    [property: JsonPropertyName("ceiling")] double Ceiling,
    [property: JsonPropertyName("floor")] double Floor,
    [property: JsonPropertyName("totalSales")] int TotalSales
);

public record TrendingCollections(
    [property: JsonPropertyName("edges")] IReadOnlyList<Edge> Collections,
    [property: JsonPropertyName("pageInfo")] PageInfo PageInfo
);

