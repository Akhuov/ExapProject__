using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;

namespace School.Application.UseCases.Students.Handlers
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateStudentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res != null)
                {
                    res.FirstName = request.FirstName;
                    res.LastName = request.LastName;
                    res.DateOfBirth = request.DateOfBirth;
                    res.YearGroup = request.YearGroup;
                    res.StudentImage = request.StudentImage;

                    _applicationDbContext.Students.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
