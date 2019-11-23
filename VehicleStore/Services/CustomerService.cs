using VehicleStore.Interfaces;
using VehicleStore.Models;
using VehicleStore.Common.Enums;
using System.Collections.Generic;
using VehicleStore.Common;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VehicleStore.Services
{
    public class CustomerService : ICustomerService
    {
        private VSDBContext _context;

        public CustomerService(VSDBContext context)
        {
            _context = context;
        }

        public ServiceResponse<List<Customer>> GetAllCustomers()
        {
            ServiceResponse<List<Customer>> response = new ServiceResponse<List<Customer>>();

            try
            {
                response.Data = _context.Customers.ToList();
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.ServerError;

                ex.LogException();
            }

            return response;
        }


        public ServiceResponse<List<Vehicle>> GetCustomerVehicles(int customerId)
        {
            ServiceResponse<List<Vehicle>> response = new ServiceResponse<List<Vehicle>>();

            try
            {
                var x = _context.Customers.ToList();
                var y = _context.Customers.Find(1);

                response.Data = _context.Customers.Include(c => c.Vehicles).AsNoTracking().FirstOrDefault(c => c.Id == customerId).Vehicles.ToList();
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatus.ServerError;

                ex.LogException();
            }

            return response;
        }

    }
}