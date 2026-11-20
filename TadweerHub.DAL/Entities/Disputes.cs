using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Dispute
    {
        public int DisputeId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int OpenedBy { get; set; }
        public User OpenedByUser { get; set; }

        public string Reason { get; set; }
        public DisputeStatus Status { get; set; }
        public string? Resolution { get; set; }

        public DateTime OpenedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
