using School.Domain.Enums;
using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class Teacher : Person
    {
        public string Title { get; set; }
        public string SubjectsTaught { get; set; }
        public Level Level { get; set; }
    }
}
