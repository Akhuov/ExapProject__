using Marry.Application.Absreactions;
using Marry.Application.UseCases.Witness.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Witness.Handlers
{
    public class GetByIdWitnessCommandHandler : IRequestHandler<GetByIdWitnessCommand, Domain.Entities.Witness>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetByIdWitnessCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<Domain.Entities.Witness> Handle(GetByIdWitnessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Witnesses.FirstOrDefaultAsync(x => x.Id == request.Id);
                return res;
            }
            catch (Exception ex) { return null; }
        }
    }
}
