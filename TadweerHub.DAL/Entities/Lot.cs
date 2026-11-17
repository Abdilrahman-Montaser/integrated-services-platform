
namespace TadweerHub.DAL.Entities
{
    internal class Lot
    {
        public int LotId { get; set; }
        public string LotCode { get; set; } 
        public string Title { get; set; } 
        public string? Description { get; set; }
        public string Condition { get; set; } 
        public string ColorName { get; set; } 
        public string ColorHex { get; set; } 
        public decimal WeightKg { get; set; }
        public int RollsCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string Governorate { get; set; } 
        public string PickupAddress { get; set; } 
        public string Status { get; set; }  //Draft|Active|Reserved|Sold
        public bool IsDeleted { get; set; }
        public byte[] RowVersion { get; set; } 
        public DateTime CreatedAt { get; set; } 
        
        public int FactoryId { get; set; }    // FK -> Factories
        public int MaterialTypeId { get; set; }   // FK -> MaterialTypes
        // Navigation Properties
        public MaterialType MaterialType { get; set; } = null!;
        public ICollection<LotImage> LotImages { get; set; } = new List<LotImage>();
        public Factory Factory { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

