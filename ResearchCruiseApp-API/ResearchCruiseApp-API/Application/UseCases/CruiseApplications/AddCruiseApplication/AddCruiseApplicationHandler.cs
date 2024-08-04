using System.Data;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.ServicesInterfaces;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence;
using ResearchCruiseApp_API.Application.ServicesInterfaces.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Entities;
using ResearchCruiseApp_API.Infrastructure.Persistence;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.AddCruiseApplication;


public class AddCruiseApplicationHandler(
    IYearBasedKeyGenerator yearBasedKeyGenerator,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IFormsARepository formsARepository,
    ICruiseApplicationsRepository cruiseApplicationsRepository,
    UserManager<User> userManager)
    : IRequestHandler<AddCruiseApplicationCommand, Result>
{
    public async Task<Result> Handle(AddCruiseApplicationCommand request, CancellationToken cancellationToken)
    {
        var formAResult = await CreateFormA(request.FormADto);
        if (formAResult.Error is not null)
            return formAResult.Error;
        
        var formA = formAResult.Data!;
        await formsARepository.AddFormA(formA, cancellationToken);
        
        //var evaluatedCruiseApplication = cruiseApplicationEvaluator.EvaluateCruiseApplication(formA, []);
            
        //await researchCruiseContext.EvaluatedCruiseApplications.AddAsync(evaluatedCruiseApplication);
        //await researchCruiseContext.SaveChangesAsync();

        //var calculatedPoints = cruiseApplicationEvaluator.CalculateSumOfPoints(evaluatedCruiseApplication);

        await unitOfWork.ExecuteIsolated(async () =>
            {
                var newCruiseApplication = await CreateCruiseApplication(formA, cancellationToken);

                await cruiseApplicationsRepository.AddCruiseApplication(newCruiseApplication, cancellationToken);
                await unitOfWork.Complete(cancellationToken);
            },
            IsolationLevel.Serializable,
            cancellationToken
        );
        

        return Result.Empty;
    }
    
    
    private async Task<Result<FormA>> CreateFormA(FormADto formADto)
    {
        var formA = mapper.Map<FormA>(formADto);
        var cruiseManager = await userManager.FindByIdAsync(formADto.CruiseManagerId.ToString());
        var deputyManager = await userManager.FindByIdAsync(formADto.DeputyManagerId.ToString());

        if (cruiseManager is null || deputyManager is null)
            return Error.BadRequest("Cruise manager and deputy manager have to be defined");

        formA.CruiseManager = cruiseManager;
        formA.DeputyManager = deputyManager;

        return formA;
    }

    private async Task<CruiseApplication> CreateCruiseApplication(FormA formA, CancellationToken cancellationToken)
    {
        var newCruiseApplication = new CruiseApplication
        {
            Number = await yearBasedKeyGenerator.GenerateKey(cruiseApplicationsRepository, cancellationToken),
            Date = DateOnly.FromDateTime(DateTime.Now),
            FormA = formA,
            FormB = null,
            FormC = null,
            //EvaluatedApplication = evaluatedCruiseApplication,
            Points = 0,
            Status = CruiseApplicationStatus.New
        };

        return newCruiseApplication;
    }
}