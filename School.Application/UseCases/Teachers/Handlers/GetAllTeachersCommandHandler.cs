using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class GetAllTeachersCommandHandler : IRequestHandler<GetAllTeachersCommand, List<Teacher>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllTeachersCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Teacher>> Handle(GetAllTeachersCommand request, CancellationToken cancellationToken)
        {
            try 
            {
                var res = await _applicationDbContext.Teachers.AsNoTracking().ToListAsync(cancellationToken);

                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
