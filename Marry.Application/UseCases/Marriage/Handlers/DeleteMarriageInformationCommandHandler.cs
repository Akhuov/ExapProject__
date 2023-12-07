using Marry.Application.Absreactions;
using Marry.Application.UseCases.Marriage.Commands;
using Marry.Application.UseCases.Person.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Marry.Application.UseCases.Marriage.Handlers
{
    public class DeleteMarriageInformationCommandHandler : IRequestHandler<DeleteMarriageInformationCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteMarriageInformationCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(DeleteMarriageInformationCommand request, CancellationToken cwancellationToken)
        {
            var res = await _applicationDbContext.Marriages.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (res == null)
                {
                    return false;
                }
                else
                {
                    _applicationDbContext.Marriages.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cwancellationToken);

                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
