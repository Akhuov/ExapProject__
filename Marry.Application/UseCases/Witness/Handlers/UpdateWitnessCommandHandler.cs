using Marry.Application.Absreactions;
using Marry.Application.UseCases.Witness.Commands;
using MediatR;

namespace Marry.Application.UseCases.Witness.Handlers
{
    public class UpdateWitnessCommandHandler : AsyncRequestHandler<UpdateWitnessCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateWitnessCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(UpdateWitnessCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var res = _applicationDbContext.Witnesses.FirstOrDefault(x => x.Id == request.Id);
                if (res != null)
                {
                    res.FirstName = request.FirstName;
                    res.LastName = request.LastName;


                    _applicationDbContext.Witnesses.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }
                else throw new Exception("Not Found");

            }
            catch (Exception ex) { }
        }
    }
}
