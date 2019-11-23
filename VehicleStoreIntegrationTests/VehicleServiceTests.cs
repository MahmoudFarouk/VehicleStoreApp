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
    public class VehicleServiceTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public VehicleServiceTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task TestGetAllVehiclesReturnVehiclesData()
        {
            var httpResponse = await _client.GetAsync("/api/vehicle/getall");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            ServiceResponse<List<Vehicle>> response = JsonConvert.DeserializeObject<ServiceResponse<List<Vehicle>>>(stringResponse);

            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count > 0);
        }

        [Fact]
        public async Task TestGetVehiclesByStatusReturnVehiclesDataByStatus()
        {
            var httpResponse = await _client.GetAsync("/api/vehicle/getvehiclesbystatus/true");

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            ServiceResponse<List<Vehicle>> response = JsonConvert.DeserializeObject<ServiceResponse<List<Vehicle>>>(stringResponse);

            Assert.NotNull(response.Data);
            Assert.True(response.Data.Count > 0);
            Assert.All(response.Data, v => Assert.True(v.IsConnected));
        }

        [Fact]
        public async Task TestUpdateStatusChangeVehiclesStatus()
        {
            var httpResponse = await _client.PostAsync("/api/vehicle/updatestatus", null);

            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;
            ServiceResponse response = JsonConvert.DeserializeObject<ServiceResponse>(stringResponse);

            Assert.True(response.Status == ResponseStatus.Success);
        }

    }
}
