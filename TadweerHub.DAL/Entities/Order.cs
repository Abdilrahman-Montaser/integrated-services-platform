using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderNo { get; set; }

        public int LotId { get; set; }
        public Lot Lot { get; set; }

        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

        public decimal WeightKg { get; set; }
        public decimal LotPrice { get; set; }
        public decimal PlatformCommission { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal DistanceKm { get; set; }
        public decimal TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CancelledAt { get; set; }

        public Delivery? Delivery { get; set; }



    }
}
