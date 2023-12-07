using Marry.Application.Absreactions;
using Marry.Application.Interfaces;
using Marry.Application.UseCases.Applicant.Querries;
using Marry.Application.UseCases.Marriage.Queries;
using Marry.Domain.Enums;
using Marry.Domain.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Marry.Application.Services.Global
{
    public class MarriageInformationService : IMarriageInformationService
    {
        private readonly IApplicationDbContext _dbContext;

        public MarriageInformationService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask<List<FullMarriageInformationViewModel>> GetAllMerriageInformationAsync()
        {
            try
            {
                var Marriages = await _dbContext.Marriages.Include(x => x.Groom)
                    .ThenInclude(x => x.PersonalInformation)
                    .Include(x => x.Bride)
                    .ThenInclude(x => x.PersonalInformation)
                    .Include(x => x.Bride)
                    .ThenInclude(x => x.Witness)
                    .Include(x => x.Groom)
                    .ThenInclude(x => x.Witness)
                    .ToListAsync();



                var listOfINformations = new List<FullMarriageInformationViewModel>();
                foreach (var obj in Marriages)
                {
                    listOfINformations.Add(new FullMarriageInformationViewModel
                    {
                        BridesFullName = $"{obj.Bride.PersonalInformation.LastName} {obj.Bride.PersonalInformation.MiddleName} {obj.Bride.PersonalInformation.FirstName}",
                        GroomsFullName = $"{obj.Groom.PersonalInformation.LastName} {obj.Groom.PersonalInformation.MiddleName} {obj.Groom.PersonalInformation.FirstName}",

                        BridesBithDate = obj.Bride.PersonalInformation.BirthDate,
                        GroomsBithDate = obj.Groom.PersonalInformation.BirthDate,

                        BridesWitnessFullName = $"{obj.Bride.Witness.LastName} {obj.Bride.Witness.FirstName}",
                        GroomsWitnessFullName = $"{obj.Groom.Witness.LastName} {obj.Groom.Witness.FirstName}",

                        MarriageStatus = obj.Bride.PersonalInformation.MarriageStatus,

                        RegisteredAt = obj.CreatedAt,

                        UpdatedAt = obj.UpdatedAt
                    });
                }
                return listOfINformations;
            }
            catch (Exception ex) { return null; }
        }
    }
}
