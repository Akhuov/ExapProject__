using MediatR;

namespace School.Application.UseCases.Students.Commands
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearGroup { get; set; }
        public int DateOfBirth { get; set; }
        public string StudentImage { get; set; }
    }
}
