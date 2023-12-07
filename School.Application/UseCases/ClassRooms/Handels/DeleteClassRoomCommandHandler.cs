using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Commands;

namespace School.Application.UseCases.ClassRooms.Handles
{
    public class DeleteClassRoomCommandHandler : IRequestHandler<DeleteClassRoomCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteClassRoomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteClassRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.ClassRooms.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    _applicationDbContext.ClassRooms.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
