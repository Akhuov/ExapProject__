using Marry.Application.Absreactions;
using Marry.Application.UseCases.Marriage.Commands;
using MediatR;

namespace Marry.Application.UseCases.Marriage.Handlers
{
    public class UpdateMarriageInformationCommandHandle : AsyncRequestHandler<UpdateMarriageInformationCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateMarriageInformationCommandHandle(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(UpdateMarriageInformationCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var res = _applicationDbContext.Marriages.FirstOrDefault(x => x.Id == request.Id);
                if (res != null)
                {
                    res.BrideId = request.BrideId;
                    res.GroomId = request.GroomId;
                    res.UpdatedAt = DateTime.Now.ToString("dd.MM.yy");

                    _applicationDbContext.Marriages.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }
                else throw new Exception("Not Found");

            }
            catch (Exception ex) { }
        }
    }
}
