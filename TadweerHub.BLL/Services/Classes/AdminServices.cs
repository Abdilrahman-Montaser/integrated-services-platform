using System;
using System.Collections.Generic;
using System.Text;
using TadweerHub.BLL.Services.Interfaces;
using TadweerHub.DAL.Entities;
using TadweerHub.DAL.Enums;
using TadweerHub.DAL.Repositories.Interfaces;

namespace TadweerHub.BLL.Services.Classes
{
    public class AdminServices : IAdminServices
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRegistrationRequestRepository _registrationRequestRepository;
        public AdminServices(IOrderRepository orderRepo
            , IRegistrationRequestRepository registrationRequest)
        {
            _orderRepository = orderRepo;
            _registrationRequestRepository = registrationRequest;
        }
        public void ApproveAccount(int requestId)
        {
            var request = _registrationRequestRepository.GetById(requestId);
            if(request == null)
            {
                return;
            }
            request.Status =RegistrationStatus.Approved;
            _registrationRequestRepository.Update(request);
            _registrationRequestRepository.Save();
        }

        public List<Order> GetDashboardOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public List<RegistrationRequest> GetPendingAccounts()
        {
            return _registrationRequestRepository.GetAll()
                .Where(r => r.Status== 0)
                .ToList();
        }

        public void RejectAccount(int requestId)
        {
            var request = _registrationRequestRepository.GetById(requestId);
            if (request == null)
            {
                return;
            }
            request.Status = RegistrationStatus.Rejected;
            _registrationRequestRepository.Update(request);
            _registrationRequestRepository.Save();
        }
    }
}
