using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Entities
{
    internal class LotImage
    {
        public int ImageId { get; set; }
        public int LotId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public int SortOrder { get; set; }

        // Navigation Property
        public Lot Lot { get; set; } = null!;
    }
}
