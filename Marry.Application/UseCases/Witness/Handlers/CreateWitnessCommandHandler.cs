using Marry.Application.Absreactions;
using Marry.Application.UseCases.Witness.Commands;
using MediatR;

namespace Marry.Application.UseCases.Witness.Handlers
{
    public class CreateWitnessCommandHandler : AsyncRequestHandler<CreateWitnessCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateWitnessCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreateWitnessCommand request, CancellationToken cancellationToken)
        {
            var res = new Domain.Entities.Witness()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
            };
            try
            {
                await _applicationDbContext.Witnesses.AddAsync(res);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var r = ex.Message;
            }
        }
    }
}
