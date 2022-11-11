// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target.Search;

public class ContentViewModel
{
    public ContractsViewModel Contracts { get; set; }
}

public class ContractsViewModel
{
    public List<ContractViewModel> Contracts { get; set; }
    public PageInfoVm PageInfo { get; set; }
    public int Count { get; set; }
}

public class ContractViewModel
{
    public string Cursor { get; set; }
    public ContractDetailsViewModel Details { get; set; }
}

public class ContractDetailsViewModel
{
    public string Address { get; set; }
    public bool IsVerified { get; set; }
    public string TokenStandard { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public StatsVm Stats { get; set; }
    public string CirculatingSupply { get; set; }
    public string OpenseaDescription { get; set; }
    public string OpenseaImageUrl { get; set; }
    public string OpenseaSlug { get; set; }
    public string OpenseaExternalUrl { get; set; }
    public string OpenseaBannerImageUrl { get; set; }
}