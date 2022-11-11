using AutoMapper;

// ReSharper disable RedundantNameQualifier

namespace Nft.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Icytools common
        CreateMap<Models.Icytools.Source.Stats, Models.Icytools.Target.StatsVm>();
        CreateMap<Models.Icytools.Source.PageInfo, Models.Icytools.Target.PageInfoVm>();
        CreateMap<Models.Icytools.Source.ContractDetails, Models.Icytools.Target.ContractDetailsViewModel>();
        CreateMap<Models.Icytools.Source.Edge, Models.Icytools.Target.EdgeVm>()
            .ForMember(
                x => x.ContractDetailsViewModel,
                y => y.MapFrom(x => x.Details))
            ;

        // Icytools trending
        CreateMap<Models.Icytools.Source.Trending.TrendingCollections,
            Models.Icytools.Target.Trending.TrendingCollectionsVm>();
        CreateMap<Models.Icytools.Source.Trending.TrendingData,
            Models.Icytools.Target.Trending.TrendingDataViewModel>();
        CreateMap<Models.Icytools.Source.Edge, Models.Icytools.Target.Trending.TrendingDataViewModel>();

        // Opensea token
        CreateMap<Models.Opensea.Source.Token.TokenModel, Models.Opensea.Target.Token.TokenViewModel>();
        CreateMap<Models.Opensea.Source.Token.SaleAsset, Models.Opensea.Target.Token.SaleAsset>();
        CreateMap<Models.Opensea.Source.Token.Collection, Models.Opensea.Target.Token.Collection>();
        CreateMap<Models.Opensea.Source.Token.Creator, Models.Opensea.Target.Token.Creator>();
        CreateMap<Models.Opensea.Source.Token.Owner, Models.Opensea.Target.Token.Owner>();
        CreateMap<Models.Opensea.Source.Token.TokenStat, Models.Opensea.Target.Token.Stats>();
        CreateMap<Models.Opensea.Source.Token.Trait, Models.Opensea.Target.Token.Trait>();
        CreateMap<Models.Opensea.Source.Token.User, Models.Opensea.Target.Token.User>();
        CreateMap<Models.Opensea.Source.Token.AssetContract, Models.Opensea.Target.Token.AssetContract>();
        CreateMap<Models.Opensea.Source.Token.LastSale, Models.Opensea.Target.Token.LastSale>();
        CreateMap<Models.Opensea.Source.Token.PaymentToken, Models.Opensea.Target.Token.PaymentToken>();
        CreateMap<Models.Opensea.Source.Token.TopOwnership, Models.Opensea.Target.Token.TopOwnership>();

        // Opensea collection content

        // BlockdaemonID is updated in background from Blockdaemon
        // MintDate is updated in background from Blockdaemon
        CreateMap<Nft.Models.Opensea.Source.Collection.Asset, Models.Opensea.Target.Collection.AssetViewModel>()
            .ForMember(
                x => x.Name,
                y => y.MapFrom(x => x.Name))
            .ForMember(
                x => x.ContractAddress,
                y => y.MapFrom(x => x.AssetContract.Address))
            .ForMember(
                x => x.OpenseaId,
                y => y.MapFrom(x => x.Id))
            .ForMember(
                x => x.TokenId,
                y => y.MapFrom(x => x.TokenId))
            .ForMember(
                x => x.ImageUrl,
                y => y.MapFrom(x => x.ImageUrl))
            .ForMember(
                x => x.ImagePreviewUrl,
                y => y.MapFrom(x => x.ImagePreviewUrl))
            .ForMember(
                x => x.ImageThumbnailUrl,
                y => y.MapFrom(x => x.ImageThumbnailUrl))
            .ForMember(
                x => x.NumSales,
                y => y.MapFrom(x => x.NumSales))
            .ForMember(
                x => x.LastSaleDate,
                y => y.MapFrom(x => x.LastSale.EventTimestamp))
            ;

        CreateMap<Nft.Models.Opensea.Source.Collection.CollectionContentModel,
            Models.Opensea.Target.Collection.CollectionContentViewModel>();

        // Blockdaemon collection content

        CreateMap<Nft.Models.Blockdaemon.Source.Assets.AssetRoot,
                Nft.Models.Blockdaemon.Target.CollectionContentViewModel>()
            .ForMember(
                x => x.Next,
                y => y.MapFrom(x => x.Meta.Paging.NextPageToken))
            .ForMember(
                x => x.Tokens,
                y => y.MapFrom(x => x.Data))
            ;

        CreateMap<Nft.Models.Blockdaemon.Source.Assets.Datum, Nft.Models.Blockdaemon.Target.TokenViewModel>();

        // Icytools collection content

        CreateMap<Models.Icytools.Source.CollectionItems.ContractData,
                Models.Icytools.Target.CollectionItems.CollectionItemsViewModel>()
            .ForMember(x => x.Contract,
                y => y.MapFrom(x => x.ContractDetails))
            .ForMember(x => x.Tokens,
                y => y.MapFrom(x => x.ContractDetails.Tokens))
            ;
        CreateMap<Models.Icytools.Source.TokensPage, Models.Icytools.Target.CollectionItems.TokensPage>();
        CreateMap<Models.Icytools.Source.TokenDetailsPage, Models.Icytools.Target.CollectionItems.TokenDetailsPage>();
        CreateMap<Models.Icytools.Source.Image, Models.Icytools.Target.Image>();
        CreateMap<Models.Icytools.Source.TokenDetails, Models.Icytools.Target.CollectionItems.TokenDetailsViewModel>()
            .ForMember(x => x.ContractAddress,
                y => y.MapFrom(x => x.Contract.Address))
            ;

        // Icytools search

        CreateMap<Models.Icytools.Source.Search.Content, Models.Icytools.Target.Search.ContentViewModel>();
        CreateMap<Models.Icytools.Source.Search.Contracts, Models.Icytools.Target.Search.ContractsViewModel>()
            .ForMember(
                x => x.Contracts,
                y => y.MapFrom(x => x.Edges))
            .ForMember(
                x => x.PageInfo,
                y => y.MapFrom(x => x.PageInfo))
            ;
        CreateMap<Models.Icytools.Source.Edge, Models.Icytools.Target.Search.ContractViewModel>();
        CreateMap<Models.Icytools.Source.ContractDetails, Models.Icytools.Target.Search.ContractDetailsViewModel>();
    }
}