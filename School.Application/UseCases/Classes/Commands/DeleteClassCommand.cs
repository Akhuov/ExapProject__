using MediatR;

namespace School.Application.UseCases.Classes.Commands
{
    public class DeleteClassCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
