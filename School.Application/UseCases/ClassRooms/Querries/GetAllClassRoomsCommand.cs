using MediatR;
using School.Domain.Entities;

namespace School.Application.UseCases.ClassRooms.Querries
{
    public class GetAllClassRoomsCommand : IRequest<List<ClassRoom>>
    {
    }
}
