using Marry.Application.Absreactions;
using Marry.Application.UseCases.Applicant.Querries;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Get
{
    public class GetAllBridesCommandHendler : IRequestHandler<GetAllBridesCommand, List<Domain.Entities.Bride>>
    {

        private readonly IApplicationDbContext _appplicationDbContext;

        public GetAllBridesCommandHendler(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }
        public async Task<List<Bride>> Handle(GetAllBridesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _appplicationDbContext.Brides.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
