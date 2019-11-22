
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
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("getall")]
        public ServiceResponse<List<Customer>> GetAll()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet]
        [Route("getcustomervehicles")]
        public ServiceResponse<List<Vehicle>> GetCustomerVehicles(int customerId)
        {
            return _customerService.GetCustomerVehicles(customerId);
        }
    }
}