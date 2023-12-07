using MediatR;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Commands;
using School.Domain.Entities;

namespace School.Application.UseCases.Classes.Handles
{
    public class CreateClassCommandHandler : IRequestHandler<CreateClassCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateClassCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var Class = new Class
                {
                    SubjectId = request.SubjectId,
                    TeacherId = request.TeacherId,
                    ClassRoomId = request.ClassRoomId,
                    Period = request.Period,
                    Time = request.Time,
                };

                await _applicationDbContext.Classes.AddAsync(Class);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex) { return false; }
        }
    }
}
