using MediatR;

namespace Marry.Application.UseCases.Witness.Queries
{
    public class GetWitnessCommand : IRequest<List<Domain.Entities.Witness>>
    {
    }
}
