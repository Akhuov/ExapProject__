using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Commands;

namespace School.Application.UseCases.Classes.Handles
{
    public class DeleteClassCommandHandler : IRequestHandler<DeleteClassCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteClassCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Classes.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    _applicationDbContext.Classes.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
