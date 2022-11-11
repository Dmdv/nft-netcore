// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Source.Images;

public class ImageData
{
    [JsonPropertyName("token")]
    public TokenDetails TokenDetails { get; set; }
}

public class ImageModel
{
    [JsonPropertyName("data")]
    public ImageData Data { get; set; }
}