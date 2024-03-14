using AutoMapper;
using Backend.DTO;
using Backend.Models;

namespace Backend.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BeerInsertDTO, Beer>();
            CreateMap<Beer, BeerDTO>()
                .ForMember(dto => dto.Id,
                            m => m.MapFrom(b => b.BeerId));
            CreateMap<BeerUpdateDTO, Beer>();
        }
    }
}
