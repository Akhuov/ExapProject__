using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class StudentClass : BaseModel
    {
        public int ClassId { get; set; }
        public int StudentId { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Class> Classes { get; set; }

    }
}
