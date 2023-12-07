using Marry.Application.Absreactions;
using Marry.Application.UseCases.Couples.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Applicant.Handlers.Create
{
    public class CreateApplicantGroomCommandHandler : AsyncRequestHandler<CreateGroomCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateApplicantGroomCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        protected override async Task Handle(CreateGroomCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var applicant = new Domain.Entities.Groom()
                {
                    PersonalInformationId = request.PersonalInformationId,
                    WitnessId = request.WitnessId,
                };

                var info = await _applicationDbContext.PersonalInformations.FirstOrDefaultAsync(x=>x.Id == request.PersonalInformationId);

                if (info.Gender == Domain.Enums.Gender.Male)
                {
                    await _applicationDbContext.Grooms.AddAsync(applicant);
                }
                else if(info.Gender == Domain.Enums.Gender.Female)
                {
                    await _applicationDbContext.Brides.AddAsync(new Domain.Entities.Bride 
                    {
                        PersonalInformationId = request.PersonalInformationId,
                        WitnessId =request.WitnessId,
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
