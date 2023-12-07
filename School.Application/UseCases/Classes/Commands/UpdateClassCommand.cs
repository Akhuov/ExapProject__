using MediatR;

namespace School.Application.UseCases.Classes.Commands
{
    public class UpdateClassCommand : IRequest<bool>
    {
        public int Id {  get; set; }

        public int SubjectId { get; set; }
        public int ClassRoomId { get; set; }
        public int TeacherId { get; set; }
        public int Period { get; set; }
        public string Time { get; set; }
    }
}
