using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.ClassRooms.Querries
{
    public class GetByIdClassRoomsCommand : IRequest<ClassRoom>
    {
        public int Id {  get; set; }
    }
}
