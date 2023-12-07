using Marry.Domain.Enums;
using MediatR;

namespace Marry.Application.UseCases.Person.Commands
{
    public class UpdatePersonalInformationCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public bool MedicalCertificate { get; set; }
        public Gender Gender { get; set; }

        public string PassportNumber { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
    }
}
