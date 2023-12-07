using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.ClassRooms.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.ClassRooms.Handles
{
    public class CreateClassRoomsCommandHandler : IRequestHandler<CreateClassRoomCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateClassRoomsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateClassRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var classRoom = new ClassRoom
                {
                    Capacity = request.Capacity,
                    Facilities = request.Facilities,
                    RoomType = request.RoomType,
                };

                await _applicationDbContext.ClassRooms.AddAsync(classRoom);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
