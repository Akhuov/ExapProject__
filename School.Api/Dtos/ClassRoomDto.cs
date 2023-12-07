using School.Domain.Enums;

namespace School.Api.Dtos
{
    public class ClassRoomDto
    {
        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public Facilities Facilities { get; set; }
    }
}
