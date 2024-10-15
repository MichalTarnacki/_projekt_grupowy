using ResearchCruiseApp_API.Application.Models.DTOs.Forms;

namespace ResearchCruiseApp_API.Application.Services.Factories.FormAInitValuesDtos;


public interface IFormAInitValuesDtosFactory
{
    Task<FormAInitValuesDto> Create(CancellationToken cancellationToken);
}