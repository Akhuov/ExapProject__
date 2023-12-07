using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Commands;

namespace School.Application.UseCases.Subjects.Handlers
{
    public class DeleteSubjectCommandHandle : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteSubjectCommandHandle(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Subjects.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (res != null)
                {
                    _applicationDbContext.Subjects.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
