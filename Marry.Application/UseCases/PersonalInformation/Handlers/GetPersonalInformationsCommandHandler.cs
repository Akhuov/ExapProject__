using Marry.Application.Absreactions;
using Marry.Application.UseCases.Person.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Person.Handlers
{
    public class GetPersonalInformationsCommandHandler : IRequestHandler<GetPersonalInformationsCommand, List<Domain.Entities.PersonalInformation>>
    {
        private readonly IApplicationDbContext _appplicationDbContext;

        public GetPersonalInformationsCommandHandler(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }

        public async Task<List<Domain.Entities.PersonalInformation>> Handle(GetPersonalInformationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _appplicationDbContext.PersonalInformations.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
