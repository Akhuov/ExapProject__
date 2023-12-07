using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;

namespace School.Application.UseCases.Students.Handlers
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteStudentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    _applicationDbContext.Students.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
