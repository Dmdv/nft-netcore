// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable NotAccessedPositionalProperty.Global
// ReSharper disable CheckNamespace
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global
// ReSharper disable CollectionNeverUpdated.Global
#pragma warning disable CS8618

namespace Nft.Models.Icytools.Target.CollectionItems;

public class TokensPage
{
    public List<TokenDetailsPage> Items  { get; set; }
    public PageInfoVm PageInfo { get; set; }
}