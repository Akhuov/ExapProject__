﻿using Marry.Domain.Enums;

namespace Marry.Api.ViewModels
{
    public class PersonalInformationDto
    {
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
