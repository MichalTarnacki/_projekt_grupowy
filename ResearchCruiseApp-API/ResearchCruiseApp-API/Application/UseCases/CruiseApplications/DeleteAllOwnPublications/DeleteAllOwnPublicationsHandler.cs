using MediatR;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.DeleteAllOwnPublications;

public class DeleteAllOwnPublicationHandler(
    ICurrentUserService currentUserService,
    IUserPublicationsRepository userPublicationsRepository,
    IPublicationsRepository publicationsRepository,
    IUnitOfWork unitOfWork) 
    : IRequestHandler<DeleteAllOwnPublicationsCommand, Result>
{
    public async Task<Result> Handle(
        DeleteAllOwnPublicationsCommand request, 
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetId();
        if (userId is null)
            return Error.ResourceNotFound();
        var userPublications = await userPublicationsRepository.GetAllByUserId((Guid)userId, cancellationToken);
        
        foreach (var userPublication in userPublications)
        {
            var publication = userPublication.Publication;
            userPublicationsRepository.Delete(userPublication);

            if (await publicationsRepository.CountFormAPublications(publication, cancellationToken) == 0 &&
                await publicationsRepository.CountUserPublications(publication, cancellationToken) == 1)
            {
                publicationsRepository.Delete(publication);
            }
        }
        await unitOfWork.Complete(cancellationToken);

        return Result.Empty;
    }
}