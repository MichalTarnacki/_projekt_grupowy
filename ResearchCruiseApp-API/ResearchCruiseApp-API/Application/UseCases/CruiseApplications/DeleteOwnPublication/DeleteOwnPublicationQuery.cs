using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.DeleteOwnPublication;

public record DeleteOwnPublicationQuery(Guid publicationId) : IRequest<Result>;