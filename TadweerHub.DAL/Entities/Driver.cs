using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    public class Driver
    {
       
        public int user_id {  get; set; } 
        public User User { get; set; }
        public string governorate {  get; set; }
        public string Vehicle_Type {  get; set; }
        public string Plate_number {  get; set; }
        public bool is_availabe {  get; set; }
        public ICollection<Delivery> Deliveries { get; set; }

    }
}
