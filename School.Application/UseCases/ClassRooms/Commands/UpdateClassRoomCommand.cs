using MediatR;
using School.Domain.Enums;

namespace School.Application.UseCases.ClassRooms.Commands
{
    public class UpdateClassRoomCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public int Capacity { get; set; }
        public RoomType RoomType { get; set; }
        public Facilities Facilities { get; set; }
    }
}
