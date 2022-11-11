// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target;

public class ContractDetailsViewModel
{
    public string Name { get; set; }
    
    public string Symbol { get; set; }
    
    public bool IsVerified { get; set; }
    
    public int CirculatingSupply { get; set; }
    
    public string Address { get; set; }
    
    public string TokenStandard { get; set; }

    public StatsVm Stats { get; set; }
    
    public string OpenseaBannerImageUrl { get; set; }
    
    public string OpenseaDescription { get; set; }
    
    public string OpenseaImageUrl { get; set; }
    
    public string OpenseaSlug { get; set; }
    
    public string OpenseaExternalUrl { get; set; }
}