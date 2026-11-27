using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.DAL.Entities;

namespace TadweerHub.BLL.Services.Interfaces
{
    public interface IAdminServices
    {
        List<Order> GetDashboardOrders();
        List<RegistrationRequest>GetPendingAccounts();
        void ApproveAccount(int requestId);
        void RejectAccount(int requestId);
    }
}
