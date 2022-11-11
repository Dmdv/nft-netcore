// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Opensea.Target.Collection;

public class CollectionContentViewModel
{
    public string Next  { get; set; }
    public string Previous { get; set; }
    public List<AssetViewModel> Assets  { get; set; }
}

public class AssetViewModel
{
    public string Name { get; set; }
    public string ContractAddress { get; set; }
    public string OpenseaId { get; set; }
    public string TokenId { get; set; }
    public string BlockdaemonId { get; set; }
    public string ImageUrl { get; set; }
    public string ImagePreviewUrl { get; set; }
    public string ImageThumbnailUrl { get; set; }
    public int NumSales { get; set; }
    public DateTime? LastSaleDate { get; set; }
    public bool Burned { get; set; }
    public DateTime? MintDate { get; set; }
}