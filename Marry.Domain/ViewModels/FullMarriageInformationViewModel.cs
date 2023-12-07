using Marry.Domain.Enums;

namespace Marry.Domain.ViewModels
{
    public class FullMarriageInformationViewModel
    {
        public string BridesFullName { get; set; }
        public string BridesBithDate { get; set; }
        public string BridesWitnessFullName { get; set; }
        public string GroomsFullName { get; set; }
        public string GroomsBithDate { get; set; }
        public string GroomsWitnessFullName { get; set; }
        public MarriageStatus MarriageStatus { get; set; }
        public string RegisteredAt { get; set; }
        public string UpdatedAt { get; set; }

    }
}
