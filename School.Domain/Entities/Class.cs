using School.Domain.GlobalModels;

namespace School.Domain.Entities
{
    public class Class : BaseModel
    {
        public int SubjectId {  get; set; }
        public Subject Subject {  get; set; }
        public int ClassRoomId {  get; set; }
        public ClassRoom ClassRoom {  get; set; }
        public int TeacherId {  get; set; }
        public Teacher Teacher {  get; set; }
        public int Period { get; set; }
        public string Time { get; set;}

    }
}
