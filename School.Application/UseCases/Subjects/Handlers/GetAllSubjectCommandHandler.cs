using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Subjects.Handlers
{
    public class GetAllSubjectCommandHandler : IRequestHandler<GetAllSubjectCommand, List<Subject>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllSubjectCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Subject>> Handle(GetAllSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Subjects.AsNoTracking().ToListAsync(cancellationToken);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
