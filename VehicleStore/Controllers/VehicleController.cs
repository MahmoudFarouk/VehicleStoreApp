
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VehicleStore.Models;
using VehicleStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VehicleStore.Common;

namespace VehicleStore.Controllers
{

    [ApiController]
    [Route("api/vehicle")]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("getall")]
        public ServiceResponse<List<Vehicle>> GetAllVehicles()
        {
            return _vehicleService.GetAllVehicles();
        }

        [Route("updatestatus")]
        public ServiceResponse UpdateVehiclesStatus()
        {
            Random randNum = new Random();
            int[] updatedVehicles = Enumerable.Repeat(0, 3).Select(i => randNum.Next(1, 7)).ToArray();
            return _vehicleService.UpdateVehiclesStatus(updatedVehicles);
        }

        [HttpGet]
        [Route("getvehiclesbystatus/{status}")]
        public ServiceResponse<List<Vehicle>> GetVehiclesByStatus(bool status)
        {
            return _vehicleService.GetVehiclesByStatus(status);
        }

    }
}