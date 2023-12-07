using Marry.Application.Absreactions;
using Marry.Application.UseCases.PersonalInformation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.PersonalInformation.Handlers
{
    public class GetByIdPersonalInformationsCommandHandler : IRequestHandler<GetByIdPersonalInformationsCommand, Domain.Entities.PersonalInformation>
    {
        private readonly IApplicationDbContext _appplicationDbContext;

        public GetByIdPersonalInformationsCommandHandler(IApplicationDbContext appplicationDbContext)
        {
            _appplicationDbContext = appplicationDbContext;
        }

        public async Task<Domain.Entities.PersonalInformation> Handle(GetByIdPersonalInformationsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _appplicationDbContext.PersonalInformations.FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
