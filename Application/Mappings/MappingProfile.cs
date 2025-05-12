using AutoMapper;
using Domain.Entities;
using Application.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserCreateUpdateDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();
        
    }
    
}
