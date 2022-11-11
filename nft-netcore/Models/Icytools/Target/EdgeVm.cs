// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

using System.Text.Json.Serialization;

namespace Nft.Models.Icytools.Target;

public class EdgeVm
{
    [JsonPropertyName("cursor")]
    public string Cursor { get; set; }

    [JsonPropertyName("collection")]
    public ContractDetailsViewModel ContractDetailsViewModel { get; set; }
}