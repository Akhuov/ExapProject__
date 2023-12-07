using MediatR;

namespace Marry.Application.UseCases.Applicant.Commands
{
    public class DeleteGroomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
