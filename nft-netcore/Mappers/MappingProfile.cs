using AutoMapper;

namespace Nft.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Icytools.Source.Data, Models.Icytools.Target.Data>();
        CreateMap<Models.Icytools.Source.Root, Models.Icytools.Target.Root>();
        CreateMap<Models.Icytools.Source.TrendingCollections, Models.Icytools.Target.TrendingCollections>();
        CreateMap<Models.Icytools.Source.Stats, Models.Icytools.Target.Stats>();
        CreateMap<Models.Icytools.Source.PageInfo, Models.Icytools.Target.PageInfo>();
        CreateMap<Models.Icytools.Source.Edge, Models.Icytools.Target.Edge>();
        CreateMap<Models.Icytools.Source.Node, Models.Icytools.Target.Node>();
    }
}