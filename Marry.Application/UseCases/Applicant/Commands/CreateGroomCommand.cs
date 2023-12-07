using MediatR;

namespace Marry.Application.UseCases.Couples.Commands
{
    public class CreateGroomCommand : IRequest
    {
        public int PersonalInformationId { get; set; }
        public int WitnessId { get; set; }
    }
}
