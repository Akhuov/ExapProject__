using MediatR;

namespace Marry.Application.UseCases.Applicant.Querries
{
    public class GetAllBridesCommand : IRequest<List<Domain.Entities.Bride>>
    {
    }
}
