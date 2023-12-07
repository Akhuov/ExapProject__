using MediatR;

namespace Marry.Application.UseCases.Witness.Queries
{
    public class GetByIdWitnessCommand : IRequest<Domain.Entities.Witness>
    {
        public int Id { get; set; }
    }
}
