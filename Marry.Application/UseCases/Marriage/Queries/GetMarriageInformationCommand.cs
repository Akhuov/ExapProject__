using MediatR;

namespace Marry.Application.UseCases.Marriage.Queries
{
    public class GetMarriageInformationCommand : IRequest<List<Domain.Entities.Marriage>>
    {
    }
}
