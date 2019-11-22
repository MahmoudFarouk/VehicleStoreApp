using VehicleStore.Common.Enums;
using VehicleStore.Models;
using System.Collections.Generic;
using VehicleStore.Common;

namespace VehicleStore.Interfaces
{
    public interface ICustomerService
    {
        public ServiceResponse<List<Customer>> GetAllCustomers();
        public ServiceResponse<List<Vehicle>> GetCustomerVehicles(int customerId);
    }
}