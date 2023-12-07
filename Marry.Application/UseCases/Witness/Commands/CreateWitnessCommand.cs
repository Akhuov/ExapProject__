using MediatR;

namespace Marry.Application.UseCases.Witness.Commands
{
    public class CreateWitnessCommand: IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
