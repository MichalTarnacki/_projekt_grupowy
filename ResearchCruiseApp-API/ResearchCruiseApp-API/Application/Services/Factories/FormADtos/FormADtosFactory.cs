using AutoMapper;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.ContractDtos;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormADtos;


internal class FormADtosFactory(IMapper mapper, IContractDtosFactory contractDtosFactory) : IFormADtosFactory
{
    public Task<FormADto> Create(FormA formA)
    {
        throw new NotImplementedException();
        // var formADto = mapper.Map<FormADto>(formA);
        //
        // foreach (var contract in formA.FormAContracts)
        // {
        //     formADto.Contracts.Add(await contractDtosFactory.Create(contract));
        // }
        //
        // return formADto;
    }
}