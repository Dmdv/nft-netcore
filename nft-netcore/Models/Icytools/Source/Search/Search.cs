// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Source.Search;

public class Content
{
    [JsonPropertyName("contracts")]
    public Contracts Contracts { get; set; }
}

public class Contracts
{
    [JsonPropertyName("edges")]
    public List<Edge> Edges { get; set; }

    [JsonPropertyName("pageInfo")]
    public PageInfo PageInfo { get; set; }
}