using Marry.Application.Absreactions;
using Marry.Application.UseCases.Witness.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Witness.Handlers
{
    public class GetWitnessCommandHandler : IRequestHandler<GetWitnessCommand, List<Domain.Entities.Witness>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetWitnessCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Domain.Entities.Witness>> Handle(GetWitnessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Witnesses.ToListAsync();
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
