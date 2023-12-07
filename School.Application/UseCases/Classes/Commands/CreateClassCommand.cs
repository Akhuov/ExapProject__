using MediatR;

namespace School.Application.UseCases.Classes.Commands
{
    public class CreateClassCommand : IRequest<bool>
    {
        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public int Period { get; set; }
        public string Time { get; set; }
    }
}
