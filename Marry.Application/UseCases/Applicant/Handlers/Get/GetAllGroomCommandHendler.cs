using Marry.Application.Absreactions;
using Marry.Application.UseCases.Applicant.Querries;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Get
{
    public class GetAllGroomCommandHendler : IRequestHandler<GetAllGroomsCommand, List<Domain.Entities.Groom>>
    {

        private readonly IApplicationDbContext _appplicationDbContext;

        public GetAllGroomCommandHendler(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }

        async Task<List<Groom>> IRequestHandler<GetAllGroomsCommand, List<Groom>>.Handle(GetAllGroomsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _appplicationDbContext.Grooms.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
