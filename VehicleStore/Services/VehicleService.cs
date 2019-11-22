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
    public class VehicleService : IVehicleService
    {
        private VSDBContext _context;

        public VehicleService(VSDBContext context)
        {
            _context = context;
        }

        public ServiceResponse<List<Vehicle>> GetAllVehicles()
        {
            ServiceResponse<List<Vehicle>> response = new ServiceResponse<List<Vehicle>>();

            try
            {
                response.Data = _context.Vehicles.Include(c=>c.Customer).AsNoTracking().ToList();
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

        public ServiceResponse UpdateVehiclesStatus(params int[] vehicleIds)
        {
            ServiceResponse<List<Vehicle>> response = new ServiceResponse<List<Vehicle>>();

            try
            {
                _context.Vehicles.Where(v => vehicleIds.Contains(v.Id)).ToList().ForEach(v => v.IsConnected = !v.IsConnected);

                _context.SaveChanges();

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
        
        public ServiceResponse<List<Vehicle>> GetVehiclesByStatus(bool status)
        {
            ServiceResponse<List<Vehicle>> response = new ServiceResponse<List<Vehicle>>();

            try
            {
                response.Data = _context.Vehicles.Where(v => v.IsConnected == status).ToList();
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