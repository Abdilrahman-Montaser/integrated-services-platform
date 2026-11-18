using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class RegistrationRequest
    {
        public int RequestId { get; set; }
        public string? RequestNo { get; set; }
        public int UserId { get; set; }
        public RegistrationStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? RejectReason { get; set; }
        public User User { get; set; } = null!;
        public User? Reviewer { get; set; }
        public ICollection<RegistrationDocument> Documents { get; set; } = new List<RegistrationDocument>();
    }
}
