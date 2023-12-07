using Marry.Application.Absreactions;
using Marry.Application.UseCases.Applicant.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Create
{
    public class CreateApplicantBrideCommandHandler : AsyncRequestHandler<CreateBrideCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateApplicantBrideCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        protected override async Task Handle(CreateBrideCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var applicant = new Domain.Entities.Bride()
                {
                    PersonalInformationId = request.PersonalInformationId,
                    WitnessId = request.WitnessId,
                };

                var info = await _applicationDbContext.PersonalInformations.FirstOrDefaultAsync(x => x.Id == request.PersonalInformationId);

                if (info.Gender == Domain.Enums.Gender.Female)
                {
                    await _applicationDbContext.Brides.AddAsync(applicant);
                }
                else if (info.Gender == Domain.Enums.Gender.Male)
                {
                    await _applicationDbContext.Grooms.AddAsync(new Domain.Entities.Groom
                    {
                        PersonalInformationId = request.PersonalInformationId,
                        WitnessId = request.WitnessId,
                    });
                }
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var r = ex.Message;
            }
        }
    }
}
