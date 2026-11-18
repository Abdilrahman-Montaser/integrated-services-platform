using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class RegistrationRequest
    {
        public int Request_Id { get; set; }
        public string? Request_No { get; set; } 
        public int User_Id { get; set; }
        public RegistrationStatus Status { get; set; } 
        public DateTime Submitted_At { get; set; } 
        public int? ReviewedBy { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? RejectReason { get; set; }
        public User User { get; set; } = null!;
        public User? Reviewer { get; set; }
        public ICollection<RegistrationDocument> Documents { get; set; } = new List<RegistrationDocument>();
    }
}
