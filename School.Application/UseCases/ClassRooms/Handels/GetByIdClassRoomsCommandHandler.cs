using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.ClassRooms.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.ClassRooms.Handels
{
    public class GetByIdClassRoomsCommandHandler : IRequestHandler<GetByIdClassRoomsCommand,ClassRoom>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdClassRoomsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ClassRoom> Handle(GetByIdClassRoomsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.ClassRooms.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
