using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class Workshop
    {
        public int UserId { get; set; }
        public string? WorkshopName { get; set; } 
        public string? Governorate { get; set; } 
        public string? Address { get; set; } 
        public User? User { get; set; } 
    }
}
