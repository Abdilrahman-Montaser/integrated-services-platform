using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Disputes
    {
        public int dispute_id { get; set; }

        public int order_id { get; set; }
        public Order Order { get; set; }

        public int opened_by { get; set; }
        public User OpenedByUser { get; set; }

        public string reason { get; set; }
        public DisputeStatus status { get; set; }
        public string? resolution { get; set; }

        public DateTime opened_at { get; set; }
        public DateTime? resolved_at { get; set; }
    }
}
