using AutoMapper;
using clone1.DTOs;
using clone1.Entities;
using clone1.Extensions;

namespace clone1.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(photo => photo.IsMain).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(
                src => src.DateOfBirth.CalculateAge()));
        CreateMap<Photo, PhotoDto>();
        CreateMap<UpdateMemberDto, AppUser>();
        CreateMap<RegisterDto, AppUser>();
    }
}