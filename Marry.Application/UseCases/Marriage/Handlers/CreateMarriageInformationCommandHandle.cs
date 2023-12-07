using Marry.Application.Absreactions;
using Marry.Application.UseCases.Marriage.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.UseCases.Marriage.Handlers
{
    public class CreateMarriageInformationCommandHandle : AsyncRequestHandler<CreateMarriageInformationCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateMarriageInformationCommandHandle(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(CreateMarriageInformationCommand request, CancellationToken cancellationToken)
        {
            var res = new Domain.Entities.Marriage()
            {
                BrideId = request.BrideId,
                GroomId = request.GroomId,
            };

            try
            {
                var bride = await _applicationDbContext.Brides.Include(x=>x.PersonalInformation).FirstOrDefaultAsync(x=>x.Id == request.BrideId);
                var groom = await _applicationDbContext.Grooms.Include(x=>x.PersonalInformation).FirstOrDefaultAsync(x => x.Id == request.GroomId);

                bride.PersonalInformation.MarriageStatus = Domain.Enums.MarriageStatus.Married;
                groom.PersonalInformation.MarriageStatus = Domain.Enums.MarriageStatus.Married;
                if (bride.PersonalInformation.Gender == Domain.Enums.Gender.Female && groom.PersonalInformation.Gender == Domain.Enums.Gender.Male)
                {
                    _applicationDbContext.Grooms.Update(groom);
                    _applicationDbContext.Brides.Update(bride);
                    await _applicationDbContext.Marriages.AddAsync(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }
                else { throw new Exception("Call Police!!!!"); }

            }
            catch (Exception ex)
            {
                var r = ex.Message;
            }
        }
    }
}
