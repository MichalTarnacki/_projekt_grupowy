using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.DTOs.CruiseApplications;
using ResearchCruiseApp_API.Application.Models.DTOs.Cruises;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Entities;
using ResearchCruiseApp_API.Infrastructure.Services.Identity;

namespace ResearchCruiseApp_API.Application.UseCases.Cruises.ConfirmCruise;


public class ConfirmCruiseHandler(
    ICruisesRepository cruisesRepository,
    IEmailSender emailSender,
    IUnitOfWork unitOfWork,
    IIdentityService identityService,
    IMapper mapper)
    : IRequestHandler<ConfirmCruiseCommand, Result>
{
    public async Task<Result> Handle(ConfirmCruiseCommand request, CancellationToken cancellationToken)
    {
        var cruise = await cruisesRepository.GetByIdWithCruiseApplicationsWithForm(request.Id, cancellationToken);
        if (cruise is null)
            return Error.NotFound();

        var result = UpdateCruiseStatus(cruise);
        if (!result.IsSuccess)
            return result;
            
        var cruiseDto = mapper.Map<CruiseDto>(cruise);

        foreach (var cruiseApplication in cruise.CruiseApplications)
        {
            if (cruiseApplication.FormA is null)
                return Error.InternalServerError("Formularz nie istnieje");
            
            cruiseApplication.Status = CruiseApplicationStatus.FormBRequired;

            var deputyManager = await identityService.GetUserDtoById(cruiseApplication.FormA.DeputyManagerId);
            var cruiseManager = await identityService.GetUserDtoById(cruiseApplication.FormA.CruiseManagerId);
            
            if(deputyManager is not null)
                await emailSender
                    .SendCruiseConfirmMessage(cruiseDto, deputyManager, deputyManager.Email);
            
            if(cruiseManager is not null)
                await emailSender
                    .SendCruiseConfirmMessage(cruiseDto, cruiseManager, cruiseManager.Email);
        }
        
        await unitOfWork.Complete(cancellationToken);
        
        return Result.Empty;
    }
    
    private static Result UpdateCruiseStatus(Cruise cruise)
    {
        if (cruise.Status != CruiseStatus.New)
            return Error.BadRequest("Rejs został już potwierdzony");

        cruise.Status = CruiseStatus.Confirmed;

        return Result.Empty;
    }
}