// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target;

public class StatsVm
{
    public double Volume { get; set; }
    
    public double Average { get; set; }
    
    public double Ceiling { get; set; }
    
    public double Floor { get; set; }
    
    public int TotalSales { get; set; }
}