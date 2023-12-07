using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class Subject : BaseModel
    {
        public string Requirements { get; set; }
        public int MaxCampacity { get; set; }
    }
}
