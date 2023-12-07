using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Commands;

namespace School.Application.UseCases.Subjects.Handlers
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateSubjectCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Subjects.FirstOrDefaultAsync(x=>x.Id == request.Id);

                if (res != null)
                {
                    res.Requirements = request.Requirements;
                    res.MaxCampacity = request.MaxCampacity;

                    _applicationDbContext.Subjects.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch(Exception ex) { return false; }
        }
    }
}
