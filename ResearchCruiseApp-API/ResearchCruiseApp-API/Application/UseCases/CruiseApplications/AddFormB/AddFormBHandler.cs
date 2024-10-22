﻿using System.Data;
using FluentValidation;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Extensions;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Services.Factories.FormsB;
using ResearchCruiseApp_API.Application.Services.Forms;
using ResearchCruiseApp_API.Application.Services.UserPermissionVerifier;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.AddFormB;


public class AddFormBHandler(
    IValidator<AddFormBCommand> validator,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    IUserPermissionVerifier userPermissionVerifier,
    IFormsBFactory formsBFactory,
    IUnitOfWork unitOfWork,
    IFormsService formsService)
    : IRequestHandler<AddFormBCommand, Result>
{
    public async Task<Result> Handle(AddFormBCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return validationResult.ToApplicationResult();
        
        var cruiseApplication = await cruiseApplicationsRepository
            .GetByIdWithFormAAndFormBContent(request.CruiseApplicationId, cancellationToken);
        
        if (cruiseApplication is null)
            return Error.ResourceNotFound();
        if (!await userPermissionVerifier.CanCurrentUserAddForm(cruiseApplication))
            return Error.ResourceNotFound(); // Forbidden may give to much information
        //if (cruiseApplication.Status != CruiseApplicationStatus.FormBRequired)
           // return Error.ForbiddenOperation("Obecnie nie można przesłać formularza B.");

        await unitOfWork.ExecuteIsolated(
            () => AddNewFormB(request.FormBDto, cruiseApplication, cancellationToken),
            IsolationLevel.Serializable,
            cancellationToken);
        
        cruiseApplication.Status = cruiseApplication.Cruise?.Status is CruiseStatus.Ended or CruiseStatus.Archive
            ? CruiseApplicationStatus.Undertaken
            : CruiseApplicationStatus.FormBFilled;
        
        await unitOfWork.Complete(cancellationToken);
        return Result.Empty;
    }


    private async Task AddNewFormB(
        FormBDto formBDto, CruiseApplication cruiseApplication, CancellationToken cancellationToken)
    {
        var oldFormB = cruiseApplication.FormB;
        var newFormB = await formsBFactory.Create(formBDto, cancellationToken);
        
        cruiseApplication.FormB = newFormB;
        await unitOfWork.Complete(cancellationToken);

        if (oldFormB is not null)
            await formsService.DeleteFormB(oldFormB, cancellationToken);
    }
}