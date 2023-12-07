using School.Domain.Enums;

namespace School.Api.Dtos
{
    public class TeacherDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string SubjectsTaught { get; set; }
        public Level Level { get; set; }
    }
}
