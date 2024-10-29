using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;
using ResearchCruiseApp_API.Application.ExternalServices;
using ResearchCruiseApp_API.Application.ExternalServices.Persistence.Repositories;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.DeleteOwnPublication;

public class DeleteOwnPublicationHandler(
    ICurrentUserService currentUserService,
    IUserPublicationsRepository userPublicationsRepository) 
    : IRequestHandler<DeleteOwnPublicationQuery, Result>
{
    public async Task<Result> Handle(
        DeleteOwnPublicationQuery request, 
        CancellationToken cancellationToken)
    {
        var userId = currentUserService.GetId().GetValueOrDefault();
        var userPublications = await userPublicationsRepository.GetAllByUserId(userId, cancellationToken);
        if (userPublications.Count == 0)
            return Error.ResourceNotFound();

        var userPublication = userPublications.Find(publication => publication.Publication.Id == request.publicationId);
        if (userPublication is null)
            return Error.ResourceNotFound();
        
        userPublicationsRepository.Delete(userPublication);

        return Result.Empty;
    }
}