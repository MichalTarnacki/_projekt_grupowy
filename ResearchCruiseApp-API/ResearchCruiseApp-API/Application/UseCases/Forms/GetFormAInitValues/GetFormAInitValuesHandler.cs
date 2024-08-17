﻿using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.DTOs.Forms;

namespace ResearchCruiseApp_API.Application.UseCases.Forms.GetFormAInitValues;


public class GetFormAInitValuesHandler(
    IIdentityService identityService)
    : IRequestHandler<GetFormAInitValuesQuery, Result<FormAInitValuesDto>>
{
    public async Task<Result<FormAInitValuesDto>> Handle(GetFormAInitValuesQuery request, CancellationToken cancellationToken)
    {
        var model = await CreateFormAInitValuesDto(cancellationToken);
        return model;
    }
    
    
    private async Task<FormAInitValuesDto> CreateFormAInitValuesDto(CancellationToken cancellationToken)
    {
        
        var userDtos = await identityService.GetAllUsersDtos(cancellationToken);
            
        var cruiseManagers = userDtos
            .Select(CreateFormUserDto)
            .ToList();

        var deputyManagers = userDtos
            .Select(CreateFormUserDto)
            .ToList();

        var years = new List<int>
        {
            DateTime.Now.Year,
            DateTime.Now.Year + 1
        };

        var shipUsages = new List<string>
        {
            "całą dobę",
            "jedynie w ciągu dnia (maks. 8–12 h)",
            "jedynie w nocy (maks. 8–12 h)",
            "8–12 h w ciągu doby rejsowej, ale bez znaczenia o jakiej porze albo z założenia" +
            "o różnych porach",
            "w inny sposób"
        };

        var researchAreas = new List<ResearchAreaDto>
        {
            new(
                "Gdynia",
                [301, 263, 294, 370, 472, 565, 541, 407],
                [316, 392, 435, 408, 407, 311, 290, 272]),
            new(
                "Gdańsk",
                [479, 392, 374, 300, 304, 356, 400, 464, 522, 582, 653, 566],
                [409, 415, 456, 437, 549, 540, 598, 523, 538, 598, 384, 314]
            )
        };
        
        var cruiseGoals = new List<string>
        {
            "Naukowy",
            "Komercyjny",
            "Dydaktyczny"
        };

        var historicalTasks = new List<ResearchTaskDto>();
        
        var model = new FormAInitValuesDto
        {
            CruiseManagers = cruiseManagers,
            DeputyManagers = deputyManagers,
            Years = years,
            ShipUsages = shipUsages,
            ResearchAreas = researchAreas,
            CruiseGoals = cruiseGoals,
            HistoricalTasks = historicalTasks,
        };

        return model;
    }
    
    private static FormUserDto CreateFormUserDto(UserDto userDto)
    { 
        var userModel = new FormUserDto
        {
            Id = userDto.Id,
            Email = userDto.Email!,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
        };

        return userModel;
    }
}