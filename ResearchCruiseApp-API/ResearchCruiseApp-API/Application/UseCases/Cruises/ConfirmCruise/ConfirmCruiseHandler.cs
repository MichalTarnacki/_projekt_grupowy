using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Domain.Common.Enums;
using ResearchCruiseApp_API.Domain.Entities;

namespace ResearchCruiseApp_API.Application.UseCases.Cruises.ConfirmCruise;


public class ConfirmCruiseHandler(
    ICruisesRepository cruisesRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<ConfirmCruiseCommand, Result>
{
    public async Task<Result> Handle(ConfirmCruiseCommand request, CancellationToken cancellationToken)
    {
        var cruise = await cruisesRepository.GetByIdWithCruiseApplications(request.Id, cancellationToken);
        if (cruise is null)
            return Error.NotFound();

        var result = UpdateCruiseStatus(cruise);
            ;
        if (result.IsSuccess)
            await unitOfWork.Complete(cancellationToken);
        
        return result;
    }
    
    private static Result UpdateCruiseStatus(Cruise cruise)
    {
        if (cruise.Status != CruiseStatus.New)
            return Error.BadRequest("Rejs został już potwierdzony");

        cruise.Status = CruiseStatus.Confirmed;

        return Result.Empty;
    }
}