using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    internal class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Co2PerTon { get; set; }
        public decimal WaterLPerTon { get; set; }

        // Navigation Property (classifies -> LOTS)
        public ICollection<Lot> Lots { get; set; } = new List<Lot>();
    }
}
