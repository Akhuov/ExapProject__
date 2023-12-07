using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Subjects.Handlers
{
    public class GetByIdSubjectCommandHandler : IRequestHandler<GetByIdSubjectCommand, Subject>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdSubjectCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Subject> Handle(GetByIdSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Subjects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
