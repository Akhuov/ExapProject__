using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class Student : Person
    {
        public int YearGroup { get; set; }
        public int DateOfBirth { get; set; }
        public string StudentImage { get; set; }
    }
}
