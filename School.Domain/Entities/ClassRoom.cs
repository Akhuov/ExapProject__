using School.Domain.Enums;
using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class ClassRoom : BaseModel
    {
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public Facilities Facilities { get; set; }
    }
}
