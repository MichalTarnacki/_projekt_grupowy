using Microsoft.AspNetCore.Identity;
using ResearchCruiseApp_API.Application.Models.Common.ServiceResult;

namespace ResearchCruiseApp_API.Infrastructure.Services.Identity;


public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult identityResult)
    {
        if (identityResult.Succeeded)
            return Result.Empty;

        var errorMessage = string.Join(" ",
            identityResult.Errors
                .Select(e => e.Description)
                .ToList());

        return Error.InvalidArgument(errorMessage);
    }
}