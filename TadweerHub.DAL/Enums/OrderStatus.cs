using System;
using System.Collections.Generic;
using System.Text;

namespace TadweerHub.DAL.Enums
{
    public enum OrderStatus
    {
        Paid = 1,
        InTransit = 2,
        Completed = 3,
        Disputed = 4,
        Refunded = 5,
        Cancelled = 6
    }
}
