namespace Marry.Domain.Entities
{
    public class Marriage : Auditable
    {
        public int BrideId {  get; set; }
        public Bride Bride { get; set; }
        public int GroomId {  get; set; }
        public Groom Groom { get; set; }
    }
}
