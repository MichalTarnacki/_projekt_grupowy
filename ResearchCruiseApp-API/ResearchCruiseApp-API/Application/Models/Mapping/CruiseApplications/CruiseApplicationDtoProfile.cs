﻿using AutoMapper;
using ResearchCruiseApp_API.Application.Common.Extensions;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Models.Mapping.CruiseApplications;


internal class CruiseApplicationDtoProfile : Profile
{
    public CruiseApplicationDtoProfile()
    {
        CreateMap<CruiseApplication, CruiseApplicationDto>()
            .ForMember(
                dest => dest.Year,
                options =>
                    options.MapFrom(src =>
                        src.FormA != null ? src.FormA.Year : default))
            .ForMember(
                dest => dest.CruiseManagerId,
                options =>
                    options.MapFrom(src =>
                        src.FormA != null ? src.FormA.CruiseManagerId : Guid.Empty))
            .ForMember(
                dest => dest.DeputyManagerId,
                options =>
                    options.MapFrom(src =>
                        src.FormA != null ? src.FormA.DeputyManagerId : Guid.Empty))
            .ForMember(
                dest => dest.HasFormA,
                options =>
                    options.MapFrom(src =>
                        src.FormA != null))
            .ForMember(
                dest => dest.HasFormB,
                options =>
                    options.MapFrom(src =>
                        src.FormB != null))
            .ForMember(
                dest => dest.HasFormC,
                options =>
                    options.MapFrom(src =>
                        src.FormC != null))
            .ForMember(
                dest => dest.Status,
                options =>
                    options.MapFrom(src => 
                        src.Status.GetStringValue()
                    ));
    }
}