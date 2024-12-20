﻿using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormCDtos;


public interface IFormCDtosFactory
{
    Task<FormCDto> Create(FormC formC);
}