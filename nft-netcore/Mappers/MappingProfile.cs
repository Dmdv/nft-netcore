using AutoMapper;

namespace Nft.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Icytools
        CreateMap<Models.Icytools.Source.Data, Models.Icytools.Target.Data>();
        CreateMap<Models.Icytools.Source.IcytoolsRoot, Models.Icytools.Target.Root>();
        CreateMap<Models.Icytools.Source.TrendingCollections, Models.Icytools.Target.TrendingCollections>();
        CreateMap<Models.Icytools.Source.Stats, Models.Icytools.Target.Stats>();
        CreateMap<Models.Icytools.Source.PageInfo, Models.Icytools.Target.PageInfo>();
        CreateMap<Models.Icytools.Source.Edge, Models.Icytools.Target.Edge>();
        CreateMap<Models.Icytools.Source.Node, Models.Icytools.Target.Node>();
        
        // Opensea
        CreateMap<Models.Opensea.Source.Asset, Models.Opensea.Target.Asset>();
        CreateMap<Models.Opensea.Source.Collection, Models.Opensea.Target.Collection>();
        CreateMap<Models.Opensea.Source.Creator, Models.Opensea.Target.Creator>();
        CreateMap<Models.Opensea.Source.Fees, Models.Opensea.Target.Fees>();
        CreateMap<Models.Opensea.Source.Owner, Models.Opensea.Target.Owner>();
        CreateMap<Models.Opensea.Source.TokenStat, Models.Opensea.Target.Stats>();
        CreateMap<Models.Opensea.Source.Trait, Models.Opensea.Target.Trait>();
        CreateMap<Models.Opensea.Source.User, Models.Opensea.Target.User>();
        CreateMap<Models.Opensea.Source.AssetContract, Models.Opensea.Target.AssetContract>();
        CreateMap<Models.Opensea.Source.DisplayData, Models.Opensea.Target.DisplayData>();
        CreateMap<Models.Opensea.Source.LastSale, Models.Opensea.Target.LastSale>();
        CreateMap<Models.Opensea.Source.OpenseaFees, Models.Opensea.Target.OpenseaFees>();
        CreateMap<Models.Opensea.Source.OpenseaRoot, Models.Opensea.Target.OpenseaRoot>();
        CreateMap<Models.Opensea.Source.PaymentToken, Models.Opensea.Target.PaymentToken>();
        CreateMap<Models.Opensea.Source.SellerFees, Models.Opensea.Target.SellerFees>();
        CreateMap<Models.Opensea.Source.TopOwnership, Models.Opensea.Target.TopOwnership>();
    }
}