using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Classes.Handles
{
    public class GetByIdClassCommandHandle : IRequestHandler<GetByIdClassCommand,Class>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdClassCommandHandle(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Student> Handle(GetByIdClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Classes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
