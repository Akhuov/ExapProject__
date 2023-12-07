using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;
using System.Reflection.Metadata.Ecma335;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand,bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateTeacherCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Teachers.FirstOrDefaultAsync(x=>x.Id == request.Id);
                if (res != null)
                {
                    res.FirstName = request.FirstName;
                    res.LastName = request.LastName;
                    res.Title = request.Title;
                    res.Level = request.Level;
                    res.SubjectsTaught = request.SubjectsTaught;

                    _applicationDbContext.Teachers.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                    return false;

            }
            catch (Exception ex) { return false; }
        }
    }
}
