using AutoMapper;
using SiteManagement.Application.Apartment.Command.CreateApartment;
using SiteManagement.Application.Apartment.Queries;
using SiteManagement.Application.ApartmentType.Command.CreateApartmentType;
using SiteManagement.Application.ApartmentType.Queries.GetAllApartmentTypes;
using SiteManagement.Application.Block.Queries.GetAllBlocks;
using SiteManagement.Application.Site.Command.CreateSite;
using SiteManagement.Application.Site.Queries.GetAllSites;

namespace SiteManagement.Application.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Block, GetAllBlocksResponseDto>();
            CreateMap<CreateApartmentTypeDto, Domain.ApartmentType>();
            CreateMap<Domain.ApartmentType, GetAllApartmentTypeResponseDto>();
            CreateMap<CreateApartmentDto, Domain.Apartment>();

            CreateMap<Domain.Apartment, GetApartmentListResponseDto>()
                .ForMember(d => d.ApartmentType, o => o.MapFrom(s => s.ApartmentType.Name))
                .ForMember(d => d.Block, o => o.MapFrom(s => s.Block.Name));

            CreateMap<CreateSiteDto, Domain.Site>();
            CreateMap<Domain.Site, GetAllSiteResponseDto>();
            

        }
    }
}
