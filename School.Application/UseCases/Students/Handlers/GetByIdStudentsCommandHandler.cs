using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Handlers
{
    public class GetByIdStudentsCommandHandler : IRequestHandler<GetByIdStudentsCommand, Student>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdStudentsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Student> Handle(GetByIdStudentsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
