using MediatR;

namespace Marry.Application.UseCases.Witness.Commands
{
    public class DeleteWitnessCommand : IRequest<bool>
    {
        public int Id { get; set; } 
    }
}
