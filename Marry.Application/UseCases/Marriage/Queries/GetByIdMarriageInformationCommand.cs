using MediatR;

namespace Marry.Application.UseCases.Marriage.Queries
{
    public class GetByIdMarriageInformationCommand : IRequest<Domain.Entities.Marriage>
    {
        public int Id { get; set; }
    }
}
