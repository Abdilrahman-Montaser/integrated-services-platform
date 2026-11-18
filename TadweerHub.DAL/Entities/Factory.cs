using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class Factory
    {
            public int User_Id { get; set; }
            public string? Company_Name { get; set; } 
            public string? Governorate { get; set; } 
            public string? Address { get; set; } 
            public User? User { get; set; }
    }
}
