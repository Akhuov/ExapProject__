using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Subjects.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Subjects.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand,bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateSubjectCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var subject = new Subject
                {
                    Requirements = request.Requirements,
                    MaxCampacity = request.MaxCampacity,
                };

                await _applicationDbContext.Subjects.AddAsync(subject);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
