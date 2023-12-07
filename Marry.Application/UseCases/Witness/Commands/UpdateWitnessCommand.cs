using MediatR;

namespace Marry.Application.UseCases.Witness.Commands
{
    public class UpdateWitnessCommand: IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
