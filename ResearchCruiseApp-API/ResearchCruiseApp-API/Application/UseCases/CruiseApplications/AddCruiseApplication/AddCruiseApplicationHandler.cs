using FluentValidation;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using ResearchCruiseApp_API.Application.Common.Extensions;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.CruiseApplicationEvaluator;
using ResearchCruiseApp_API.Application.Services.Factories.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.FormsA;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.AddCruiseApplication;


public class AddCruiseApplicationHandler(
    IValidator<AddCruiseApplicationCommand> validator,
    IFormsAFactory formsAFactory,
    ICruiseApplicationsFactory cruiseApplicationsFactory,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    IUnitOfWork unitOfWork,
    ICruiseApplicationEvaluator cruiseApplicationEvaluator,
    IEmailSender emailSender,
    IIdentityService identityService)
    : IRequestHandler<AddCruiseApplicationCommand, Result>
{
    public async Task<Result> Handle(AddCruiseApplicationCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToApplicationResult();
        
        var newCruiseApplicationResult = await unitOfWork.ExecuteIsolated(
            () => AddCruiseApplication(request.FormADto, cancellationToken),
            cancellationToken);

        if (!newCruiseApplicationResult.IsSuccess)
            return newCruiseApplicationResult;
        var newCruiseApplication = newCruiseApplicationResult.Data!;
        
        await SendRequestToSupervisor(newCruiseApplication, request.FormADto.SupervisorEmail!);

        return Result.Empty;
    }

    private async Task<Result<CruiseApplication>> AddCruiseApplication(
        FormADto formADto, CancellationToken cancellationToken)
    {
        var newCruiseApplicationResult = await GetNewCruiseApplication(formADto, cancellationToken);
        if (!newCruiseApplicationResult.IsSuccess)
            return newCruiseApplicationResult;
        var newCruiseApplication = newCruiseApplicationResult.Data!;
        
        await cruiseApplicationEvaluator.Evaluate(newCruiseApplication, cancellationToken);
        
        await unitOfWork.Complete(cancellationToken);
        return newCruiseApplication;
    }

    private async Task<Result<CruiseApplication>> GetNewCruiseApplication(
        FormADto formADto, CancellationToken cancellationToken)
    {
        var newFormAResult = await formsAFactory.Create(formADto, cancellationToken);
        if (!newFormAResult.IsSuccess)
            return newFormAResult.Error!;
        
        var newFormA = newFormAResult.Data!;
        var newCruiseApplication = cruiseApplicationsFactory.Create(newFormA);
        
        await cruiseApplicationsRepository.Add(newCruiseApplication, cancellationToken);
        
        return newCruiseApplication;
    }

    private async Task SendRequestToSupervisor(CruiseApplication cruiseApplication, string supervisorEmail)
    {
        var cruiseManagerId = cruiseApplication.FormA?.CruiseManagerId ?? Guid.Empty;
        var supervisorCode = Base64UrlEncoder.Encode(cruiseApplication.SupervisorCode);
        var cruiseManager = (await identityService.GetUserDtoById(cruiseManagerId))!;
        
        await emailSender
            .SendRequestToSupervisorMessage(cruiseApplication.Id, supervisorCode, cruiseManager, supervisorEmail);
    }
}