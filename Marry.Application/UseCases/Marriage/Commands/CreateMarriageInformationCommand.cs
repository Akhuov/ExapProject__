using MediatR;

namespace Marry.Application.UseCases.Marriage.Commands
{
    public class CreateMarriageInformationCommand : IRequest
    {
        public int BrideId { get; set; }
        public int GroomId { get; set; }
    }
}
