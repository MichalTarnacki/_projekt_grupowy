﻿using AutoMapper;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.ContractDtos;
using ResearchCruiseApp_API.Application.Services.Factories.PermissionDtos;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormADtos;


internal class FormADtosFactory(
    IMapper mapper,
    IPermissionDtosFactory permissionDtosFactory,
    IContractDtosFactory contractDtosFactory)
    : IFormADtosFactory
{
    public async Task<FormADto> Create(FormA formA)
    {
        var formADto = mapper.Map<FormADto>(formA);

        await AddPermissions(formA, formADto);
        await AddContracts(formA, formADto);
        
        return formADto;
    }


    private async Task AddPermissions(FormA formA, FormADto formADto)
    {
        foreach (var permission in formA.Permissions)
        {
            var permissionDto = await permissionDtosFactory.Create(permission);
            formADto.Permissions.Add(permissionDto);
        }
    }
    
    private async Task AddContracts(FormA formA, FormADto formADto)
    {
        foreach (var formAContract in formA.FormAContracts)
        {
            var contractDto = await contractDtosFactory.Create(formAContract.Contract);
            formADto.Contracts.Add(contractDto);
        }
    }
}