using School.Domain.Entities;

namespace School.Api.Dtos
{
    public class ClassDto
    {
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public int Period { get; set; }
        public string Time { get; set; }
    }
}
