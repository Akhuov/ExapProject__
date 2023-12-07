using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.Teachers.Commands
{
    public class CreateTeacherCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastNameName { get; set; }
        public string Title { get; set; }
        public string SubjectsTaught { get; set; }
        public Level Level { get; set; }
    }
}
