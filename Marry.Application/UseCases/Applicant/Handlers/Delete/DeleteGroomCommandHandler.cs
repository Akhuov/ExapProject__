using Marry.Application.Absreactions;
using Marry.Application.UseCases.Applicant.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Delete
{
    public class DeleteApplicantsGroomCommandHandler : IRequestHandler<DeleteGroomCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteApplicantsGroomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteGroomCommand request, CancellationToken cancellationToken)
        {
            var res = await _applicationDbContext.Grooms.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (res == null)
                {
                    return false;
                }
                else
                {
                    _applicationDbContext.Grooms.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}

