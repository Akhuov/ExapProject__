using MediatR;

namespace School.Application.UseCases.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<bool>
    {
        public string Requirements { get; set; }
        public int MaxCampacity { get; set; }
    }
}
