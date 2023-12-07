using Marry.Application.Absreactions;
using Marry.Application.UseCases.Witness.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Witness.Handlers
{
    public class DeleteWitnessCommandHandler : IRequestHandler<DeleteWitnessCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteWitnessCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(DeleteWitnessCommand request, CancellationToken cancellationToken)
        {
            var res = await _applicationDbContext.Witnesses.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (res == null)
                {
                    return false;
                }
                else
                {
                    _applicationDbContext.Witnesses.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
