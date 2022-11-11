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

namespace Nft.Models.Icytools.Target.CollectionItems;

public class TokenDetailsViewModel
{
    public string Name { get; set; }
    public string ContractAddress { get; set; }
    public string TokenId { get; set; }
    public List<Image> Images { get; set; }

    // From Blockdaemon or IcyTools logs
    
    public int? NumSales { get; set; }
    public decimal LastSalePrice { get; set; }
    public DateTime? LastSaleDate { get; set; }
    public DateTime? MintDate { get; set; }
}