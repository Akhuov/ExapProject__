using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Teachers.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Teachers.Handlers
{
    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateTeacherCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Title = request.Title,
                    SubjectsTaught = request.SubjectsTaught,
                    Level = request.Level,

                };

                await _applicationDbContext.Teachers.AddAsync(teacher);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
