using AutoMapper;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.ContractDtos;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormCDtos;


public class FormCDtosFactory(
    IMapper mapper,
    IContractDtosFactory contractDtosFactory)
    : IFormCDtosFactory
{
    public async Task<FormCDto> Create(FormC formC)
    {
        var formCDto = mapper.Map<FormCDto>(formC);

        await AddContracts(formC, formCDto);

        return formCDto;
    }


    private async Task AddContracts(FormC formC, FormCDto formCDto)
    {
        foreach (var contract in formC.Contracts)
        {
            var contractDto = await contractDtosFactory.Create(contract);
            formCDto.Contracts.Add(contractDto);
        }
    }
}