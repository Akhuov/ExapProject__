using MediatR;

namespace Marry.Application.UseCases.Marriage.Commands
{
    public class UpdateMarriageInformationCommand : IRequest
    {
        public int Id { get; set; }
        public int BrideId { get; set; }
        public int GroomId { get; set; }
    }
}
