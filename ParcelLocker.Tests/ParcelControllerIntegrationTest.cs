using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ParcelLocker.Models;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ParcelLocker.Tests
{

    [TestClass]
    public class ParcelIntegrationTests : IDisposable
    {
        private readonly WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        public ParcelIntegrationTests()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }

        [TestMethod]
        public async Task Post_Parcel_Returns_Success()
        {
            // Arrange
            var request = new
            {
                Url = "/api/parcel",
                Body = new
                {
                    weightGrams = 30,
                    destination = new
                    {
                        street = "D",
                        houseNumber = "B",
                        city = "A",
                        postalCode = "C"
                    }
                }
            };

            // Act
            var response = await _client.PostAsync(request.Url, new StringContent(
                JsonSerializer.Serialize(request.Body),
                Encoding.UTF8, "application/json"));

            // Assert
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            var responseObject = JsonSerializer.Deserialize<Parcel>(responseBody, options);

            // Assert specific properties of the response object
            Assert.AreEqual(30, responseObject.WeightGrams);
            Assert.AreEqual(1185, responseObject.ShippingCostCents);
            Assert.AreEqual("D", responseObject.Destination.Street);
            Assert.AreEqual("B", responseObject.Destination.HouseNumber);
            Assert.AreEqual("A", responseObject.Destination.City);
            Assert.AreEqual("C", responseObject.Destination.PostalCode);
        }
    }
}