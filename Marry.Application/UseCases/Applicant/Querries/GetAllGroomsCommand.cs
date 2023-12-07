using MediatR;

namespace Marry.Application.UseCases.Applicant.Querries
{
    public class GetAllGroomsCommand : IRequest<List<Domain.Entities.Groom>>
    {
    
    }
}
