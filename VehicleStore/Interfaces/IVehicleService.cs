using VehicleStore.Common.Enums;
using VehicleStore.Models;
using System.Collections.Generic;
using VehicleStore.Common;

namespace VehicleStore.Interfaces
{
    public interface IVehicleService
    {
        public ServiceResponse<List<Vehicle>> GetAllVehicles();

        public ServiceResponse UpdateVehiclesStatus(params int[] vehicleIds);

        public ServiceResponse<List<Vehicle>> GetVehiclesByStatus(bool status);

    }
}