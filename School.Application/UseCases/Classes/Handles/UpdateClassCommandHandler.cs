using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Absreactions;
using School.Application.UseCases.Classes.Commands;

namespace School.Application.UseCases.Classes.Handles
{
    public class UpdateClassCommandHandler : IRequestHandler<UpdateClassCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateClassCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _applicationDbContext.Classes.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res != null)
                {
                    res.SubjectId = request.SubjectId;
                    res.TeacherId = request.TeacherId;
                    res.ClassRoomId = request.ClassRoomId;
                    res.Time = request.Time;
                    res.Period = request.Period;

                    _applicationDbContext.Classes.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return true;
                }
                return false;
            }
            catch (Exception ex) { return false; }
        }
    }
}
