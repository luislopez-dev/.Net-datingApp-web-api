﻿using AutoMapper;
using clone1.API.Extensions;
using clone1.Core.DTOs;
using clone1.Core.Entities;

namespace clone1.Core.Helpers;

/// <summary>
/// </summary>
/// <remarks>
/// Author: Luis López  
/// GitHub: https://github.com/luislopez-dev
/// Description: Training Project
/// </remarks>
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