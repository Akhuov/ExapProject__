using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.ClassRooms.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.ClassRooms.Handels
{
    public class GetAllClassRoomsCommandHandler : IRequestHandler<GetAllClassRoomsCommand, List<ClassRoom>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllClassRoomsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<ClassRoom>> Handle(GetAllClassRoomsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.ClassRooms.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
