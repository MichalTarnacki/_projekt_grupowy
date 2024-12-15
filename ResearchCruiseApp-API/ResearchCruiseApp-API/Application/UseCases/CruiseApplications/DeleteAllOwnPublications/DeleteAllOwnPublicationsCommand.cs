using MediatR;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.DeleteAllOwnPublications;

public record DeleteAllOwnPublicationsCommand : IRequest<Result>;