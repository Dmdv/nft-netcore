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

namespace Nft.Models.Blockdaemon.Target;

public class CollectionContentViewModel
{
    public string Next  { get; set; }
    public List<TokenViewModel> Tokens  { get; set; }
}

public class TokenViewModel
{
    public string Name { get; set; }
    public string ContractAddress { get; set; }
    public string TokenId { get; set; }
    public string BlockdaemonId { get; set; }
    public bool? Burned { get; set; }
    
    // Postprocess
    
    public string Image100Url { get; set; }       // filled from IcyTools
    public string Image200Url { get; set; }       // filled from IcyTools
    public string Image400Url { get; set; }       // filled from IcyTools
    public string Image800Url { get; set; }       // filled from IcyTools
    public string Image1200Url { get; set; }      // filled from IcyTools
    
    // Exchange postprocess
    
    public string? OpenseaId { get; set; }
    public int? NumSales { get; set; }                  // filled from Opensea
    public DateTime? LastSaleDate { get; set; }         // filled from Blockdaemon
    public DateTime? MintDate { get; set; }             // filled from Blockdaemon
}