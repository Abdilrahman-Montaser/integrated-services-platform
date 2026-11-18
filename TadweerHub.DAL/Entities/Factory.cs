namespace TadweerHub.DAL.Entities
{
    public class Factory
    {
        public int UserId { get; set; }
        public string? CompanyName { get; set; }
        public string? Governorate { get; set; }
        public string? Address { get; set; }
        public User? User { get; set; }
        public List<Lot> Lots { get; internal set; }
    }
}
