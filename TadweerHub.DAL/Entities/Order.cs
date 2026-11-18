using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Enums;

namespace TadweerHub.DAL.Entities
{
    public class Order
    {
        public int order_id { get; set; }          
        public string order_no { get; set; }       

        public int lot_id { get; set; }            
        public Lot Lot { get; set; }

        public int workshop_id { get; set; }       
        public WorkShop Workshop { get; set; }

        public decimal weight_kg { get; set; }
        public decimal lot_price { get; set; }
        public decimal platform_commission { get; set; }
        public decimal delivery_fee { get; set; }
        public decimal distance_km { get; set; }
        public decimal total_amount { get; set; }
        public string delivery_address { get; set; }
        public OrderStatus status { get; set; }

        public DateTime created_at { get; set; }
        public DateTime? completed_at { get; set; }
        public DateTime? cancelled_at { get; set; }

        public Delivery? Delivery { get; set; }



    }
}
