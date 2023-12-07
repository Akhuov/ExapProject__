using MediatR;

namespace Marry.Application.UseCases.Applicant.Commands
{
    public class CreateBrideCommand : IRequest
    {
        public int PersonalInformationId { get; set; }
        public int WitnessId { get; set; }
    }
}
