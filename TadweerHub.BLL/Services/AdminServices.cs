using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.BLL.Interfaces;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.BLL.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRegistrationRequestRepository _registrationRequestRepository;
        public AdminServices(IOrderRepository orderRepository,
            IRegistrationRequestRepository registrationRequestRepository)
        {
            _orderRepository = orderRepository;
            _registrationRequestRepository = registrationRequestRepository;
        }
        public IEnumerable<Order> GetDashboardOrders()
        {
           return _orderRepository.GetAll();
        }

        public IEnumerable<RegistrationRequest> GetPendingAccounts()
        {
            return _registrationRequestRepository.GetAll();
        }
    }
}
