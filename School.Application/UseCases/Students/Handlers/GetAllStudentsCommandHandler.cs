using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Handlers
{
    public class GetAllStudentsCommandHandler : IRequestHandler<GetAllStudentsCommand, List<Student>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllStudentsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Student>> Handle(GetAllStudentsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Students.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
