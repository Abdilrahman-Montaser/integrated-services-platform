using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Delivery
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? DriverId { get; set; }
        public Driver Driver { get; set; }
        public DeliveryStatus status { get; set; }
        public string DeliveryCode { get; set; }
        public int FailedAttempts { get; set; }
        public decimal? WeighedKg { get; set; }
        public string? WeighbridgeImageUrl { get; set; }

        public DateTime AssignedAt { get; set; }
        public DateTime? HandoverConfirmed_At { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
    }
}
