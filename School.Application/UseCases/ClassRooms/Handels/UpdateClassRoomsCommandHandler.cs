using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Commands;
using School.Application.UseCases.ClassRooms.Commands;

namespace School.Application.UseCases.ClassRooms.Handles
{
    public class UpdateClassRoomsCommandHandler : IRequestHandler<UpdateClassRoomCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateClassRoomsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateClassRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.ClassRooms.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res != null)
                {
                    res.Capacity = request.Capacity;
                    res.Facilities = request.Facilities;
                    res.RoomType = request.RoomType;

                    _applicationDbContext.ClassRooms.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
