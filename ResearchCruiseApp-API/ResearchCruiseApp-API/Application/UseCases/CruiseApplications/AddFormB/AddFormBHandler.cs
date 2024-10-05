using MediatR;
using ResearchCruiseApp_API.Application.Common.Models.ServiceResult;

namespace ResearchCruiseApp_API.Application.UseCases.CruiseApplications.AddFormB;


public class AddFormBHandler : IRequestHandler<AddFormBCommand, Result>
{
    public Task<Result> Handle(AddFormBCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}