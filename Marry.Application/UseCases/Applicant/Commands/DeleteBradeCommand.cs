using MediatR;

namespace Marry.Application.UseCases.Applicant.Commands
{
    public class DeleteBradeCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
