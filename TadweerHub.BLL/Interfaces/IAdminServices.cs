using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.BLL.Interfaces;
using TadweerHub.DAL.Entities;

namespace TadweerHub.BLL.Interfaces
{
    public interface IAdminServices
    {
        IEnumerable<Order> GetDashboardOrders();
        IEnumerable<RegistrationRequest> GetPendingAccounts();
    }
}
