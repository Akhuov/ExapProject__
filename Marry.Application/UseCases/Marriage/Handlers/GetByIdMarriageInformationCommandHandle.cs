using Marry.Application.Absreactions;
using Marry.Application.UseCases.Marriage.Queries;
using Marry.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Marriage.Handlers
{
    public class GetByIdMarriageInformationCommandHandle : IRequestHandler<GetByIdMarriageInformationCommand, Domain.Entities.Marriage>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdMarriageInformationCommandHandle(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Domain.Entities.Marriage> Handle(GetByIdMarriageInformationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Marriages.FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
