using System.Security.Claims;
using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.DTOs;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;

namespace ResearchCruiseApp_API.Application.UseCases.Users.GetUserById;


public record GetUserByIdQuery(Guid Id, ClaimsPrincipal CurrentUser) : IRequest<Result<UserDto>>;