using MediatR;

namespace School.Application.UseCases.ClassRooms.Commands
{
    public class DeleteClassRoomCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
