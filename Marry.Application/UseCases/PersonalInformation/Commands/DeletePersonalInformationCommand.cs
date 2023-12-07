using MediatR;

namespace Marry.Application.UseCases.Person.Commands
{
    public class DeletePersonalInformationCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
