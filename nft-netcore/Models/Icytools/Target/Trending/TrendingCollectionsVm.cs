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

namespace Nft.Models.Icytools.Target.Trending;

public class TrendingDataViewModel
{
    public TrendingCollectionsVm? TrendingCollections { get; set; }
}

public class TrendingCollectionsVm
{
    [JsonPropertyName("collections")]
    public List<EdgeVm> Edges { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfoVm PageInfo { get; set; }
}