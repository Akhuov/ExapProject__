using Marry.Application.Absreactions;
using Marry.Application.UseCases.Person.Commands;
using MediatR;

namespace Marry.Application.UseCases.PersonalInformation.Handlers
{
    public class UpdatePersonalInformationsCommandHandler : AsyncRequestHandler<UpdatePersonalInformationCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdatePersonalInformationsCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        protected override async Task Handle(UpdatePersonalInformationCommand request, CancellationToken cancellationToken)
        {

            try
            {

                var res = _applicationDbContext.PersonalInformations.FirstOrDefault(x => x.Id == request.Id);
                if (res != null)
                {
                    res.PassportNumber = request.PassportNumber;
                    res.FirstName = request.FirstName;
                    res.LastName = request.LastName;
                    res.BirthDate = request.BirthDate;
                    res.MiddleName = request.MiddleName;
                    res.MedicalCertificate = request.MedicalCertificate;
                    res.Gender = request.Gender;
                    res.MarriageStatus = request.MarriageStatus;

                    _applicationDbContext.PersonalInformations.Update(res);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                }
                else throw new Exception("Not Found");

            }
            catch (Exception ex){ }
        }
    }
}
