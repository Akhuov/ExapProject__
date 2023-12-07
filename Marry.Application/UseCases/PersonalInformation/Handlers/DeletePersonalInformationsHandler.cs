using Marry.Application.Absreactions;
using Marry.Application.UseCases.Person.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Person.Handlers
{
    public class DeletePersonalInformationsHandler : IRequestHandler<DeletePersonalInformationCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeletePersonalInformationsHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeletePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var personInfo = await _applicationDbContext.PersonalInformations.FirstOrDefaultAsync(x => x.Id == request.Id);
            try
            {
                if (personInfo == null)
                {
                    return false;
                }
                else
                {
                    _applicationDbContext.PersonalInformations.Remove(personInfo);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);

                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
    }
}
