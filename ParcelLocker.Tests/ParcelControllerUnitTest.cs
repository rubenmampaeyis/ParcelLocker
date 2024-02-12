using Microsoft.AspNetCore.Mvc;
using Moq;
using ParcelLocker.Models;
using ParcelLocker.Services;

namespace ParcelLocker.Tests
{
    [TestClass]
    public class ParcelControllerUnitTest
    {
        private readonly ParcelController _controller;
        public ParcelControllerUnitTest()
        {
            var fileStoreMock = new Mock<FileStore>();
            var parcelService = new ParcelService(fileStoreMock.Object);
            _controller = new ParcelController(parcelService, fileStoreMock.Object);
        }
        [TestMethod]
        public async Task AddParcel_Should_CaluclateCost()
        {
            // Arrange
            var parcel = new AddParcelDTO()
            {
                WeightGrams = 30,
                Destination = new Address()
                {
                    City = "City",
                    HouseNumber = "55",
                    PostalCode = "12345",
                    Street = "Street"
                }
            };

            // Act
            var result = (await _controller.AddParcelAsync(parcel)) as OkObjectResult;
            
            var value = result.Value as Parcel;
            Assert.AreEqual(1185, value.ShippingCostCents);
        }
    }
}