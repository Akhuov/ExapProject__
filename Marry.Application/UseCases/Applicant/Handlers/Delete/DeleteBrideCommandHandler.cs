using Marry.Application.Absreactions;
using Marry.Application.UseCases.Applicant.Commands;
using Marry.Application.UseCases.Person.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Delete
{
    public class DeleteBrideCommandHandler : IRequestHandler<DeleteBradeCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteBrideCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteBradeCommand request, CancellationToken cancellationToken)
        {
            var res = await _applicationDbContext.Brides.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (res == null)
                {
                    return false;
                }
                else
                {
                    _applicationDbContext.Brides.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
