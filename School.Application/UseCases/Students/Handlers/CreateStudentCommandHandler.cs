using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Students.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Students.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateStudentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var student = new Student
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    YearGroup = request.YearGroup,
                    DateOfBirth = request.DateOfBirth,
                    StudentImage = request.StudentImage,
                };

                await _applicationDbContext.Students.AddAsync(student);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
