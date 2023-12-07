using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class GetByIdTeachersCommandHandler : IRequestHandler<GetByIdTeachersCommand, Teacher>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdTeachersCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        async Task<Teacher> IRequestHandler<GetByIdTeachersCommand, Teacher>.Handle(GetByIdTeachersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Teachers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
