// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target;

public class PageInfoVm
{
    public bool HasNextPage { get; set; }
    
    public bool HasPreviousPage { get; set; }
    
    public string StartCursor { get; set; }
    
    public string EndCursor { get; set; }
}