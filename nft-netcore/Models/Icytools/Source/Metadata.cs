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

public class Metadata
{
    [JsonPropertyName("animation_url")]
    public object AnimationUrl { get; set; }

    [JsonPropertyName("description")]
    public object Description { get; set; }

    [JsonPropertyName("external_url")]
    public object ExternalUrl { get; set; }

    [JsonPropertyName("youtube_url")]
    public object YoutubeUrl { get; set; }
}