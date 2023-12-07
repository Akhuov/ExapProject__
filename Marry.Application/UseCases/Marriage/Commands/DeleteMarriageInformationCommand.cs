using MediatR;

namespace Marry.Application.UseCases.Marriage.Commands
{
    public class DeleteMarriageInformationCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
