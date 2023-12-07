namespace Marry.Domain.Entities
{
    public class Groom : BaseModel
    {
        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
        public int WitnessId { get; set; }
        public Witness Witness { get; set; }
        public virtual Marriage Marriage { get; set; }
    }
}
