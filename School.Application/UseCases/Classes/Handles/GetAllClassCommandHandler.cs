using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Querries;
using School.Domain.Entities;

namespace School.Application.UseCases.Classes.Handles
{
    public class GetAllClassCommandHandler : IRequestHandler<GetAllClassCommand, List<Class>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllClassCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Class>> Handle(GetAllClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Classes.AsNoTracking().ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
