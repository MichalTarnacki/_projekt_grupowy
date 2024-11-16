using MediatR;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;
using ResearchCruiseApp_API.Application.Services.CruisesService;
using ResearchCruiseApp_API.Application.Services.Factories.Cruises;
using ResearchCruiseApp_API.Domain.Common.Enums;

namespace ResearchCruiseApp_API.Application.UseCases.Cruises.AddCruise;


public class AddCruiseHandler(
    ICruisesFactory cruisesFactory,
    ICruisesService cruisesService,
    ICruisesRepository cruisesRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<AddCruiseCommand, Result>
{
    public async Task<Result> Handle(AddCruiseCommand request, CancellationToken cancellationToken)
    {
        var newCruise = await cruisesFactory.Create(request.CruiseFormDto, cancellationToken);

        if (newCruise.CruiseApplications.Any(application => application.Status != CruiseApplicationStatus.Accepted))
            return Error.InvalidArgument("Można dodać do rejsu jedynie zgłoszenia w stanie \"Zaakceptowane\"");
        
        // Cruises that already contain any of newCruise applications. The application will be deleted from them
        // since an application cannot be assigned to more than one cruise
        var affectedCruises = await cruisesRepository
            .GetByCruiseApplicationsIds(request.CruiseFormDto.CruiseApplicationsIds, cancellationToken);
        
        await cruisesService.PersistCruiseWithNewNumber(newCruise, cancellationToken);

        await cruisesService.CheckEditedCruisesManagersTeams(affectedCruises, cancellationToken);
        await unitOfWork.Complete(cancellationToken);

        return Result.Empty;
    }
}