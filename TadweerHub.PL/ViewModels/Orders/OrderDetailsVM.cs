using Microsoft.AspNetCore.Mvc;

namespace TadweerHub.PL.ViewModels.Orders
{
    public class OrderDetailsVM : OrderRowVM
    {
        public string Material { get; set; } = "";
        public int RollsCount { get; set; }
        public decimal? WeighedKg { get; set; }      
        public string FromAddress { get; set; } = "";
        public string ToAddress { get; set; } = "";
        public string VehiclePlate { get; set; } = "—";
        public string DriverPhone { get; set; } = "—";
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string EscrowNo { get; set; } = "";
    }
}
