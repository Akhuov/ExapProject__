using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteTeacherCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Teachers.FirstOrDefaultAsync(x=>x.Id == request.Id);

                if (res != null)
                {
                    _applicationDbContext.Teachers.Remove(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
