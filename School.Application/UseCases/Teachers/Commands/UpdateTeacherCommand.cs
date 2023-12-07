using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.Teachers.Commands
{
    public class UpdateTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string SubjectsTaught { get; set; }
        public Level Level { get; set; }
    }
}
