using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class Driver
    {
        public int UserId { get; set; }
        public string? Governorate { get; set; } 
        public string? VehicleType { get; set; }
        public string? PlateNumber { get; set; } 
        public bool IsAvailable { get; set; }

        public User? User { get; set; } 
    }
}
