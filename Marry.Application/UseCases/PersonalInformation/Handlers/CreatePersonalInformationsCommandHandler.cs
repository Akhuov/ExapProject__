using Marry.Application.Absreactions;
using Marry.Application.UseCases.Person.Commands;

using MediatR;

namespace Marry.Application.UseCases.Person.Handlers
{
    public class CreatePersonalInformationsCommandHandler : AsyncRequestHandler<CreatePersonalInformationCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreatePersonalInformationsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        protected override async Task Handle(CreatePersonalInformationCommand request, CancellationToken cancellationToken)
        {
            var personInfo = new Domain.Entities.PersonalInformation()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                BirthDate = request.BirthDate,
                MedicalCertificate = request.MedicalCertificate,
                Gender = request.Gender,
                PassportNumber = request.PassportNumber,
                MarriageStatus = request.MarriageStatus,
            };
            try
            {
                await _applicationDbContext.PersonalInformations.AddAsync(personInfo);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var r = ex.Message;
            }
        }
    }
}
