using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Delivery
    {
        public int order_id { get; set; }
        public Order Order { get; set; }
        public int? driver_id { get; set; }
        public Driver Driver { get; set; }
        public DeliveryStatus status { get; set; }
        public string delivery_code { get; set; }
        public int failed_attempts { get; set; }
        public decimal? weighed_kg { get; set; }
        public string? weighbridge_image_url { get; set; }

        public DateTime assigned_at { get; set; }
        public DateTime? handover_confirmed_at { get; set; }
        public DateTime? started_at { get; set; }
        public DateTime? confirmed_at { get; set; }
    }
}
