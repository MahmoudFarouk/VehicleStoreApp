using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using VehicleStore;
using Web.Api.IntegrationTests;
using Xunit;
using VehicleStore.Models;
using VehicleStore.Common;
using Newtonsoft.Json;
using System.Threading.Tasks;
using VehicleStore.Common.Enums;


namespace VehicleStoreIntegrationTests
{
    public class CustomerServciceTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustomerServciceTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetAllCustomersReturnCustomersData()
        {
            var httpResponse = await _client.GetAsync("/api/customer/getall");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            ServiceResponse<List<Customer>> response = JsonConvert.DeserializeObject<ServiceResponse<List<Customer>>>(stringResponse);

            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count > 0);
        }

        [Fact]
        public async Task TestGetCustomerVehiclesReturnOnlyCustomerVehciles()
        {
            int customerId = 1;
            var httpResponse = await _client.GetAsync($"/api/customer/getcustomervehicles/{customerId}");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            ServiceResponse<List<Vehicle>> response = JsonConvert.DeserializeObject<ServiceResponse<List<Vehicle>>>(stringResponse);

            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count > 0);
            Assert.All(response.Data, v => Assert.True(v.CustomerId == 1));
        }

    }
}
