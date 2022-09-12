using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using northwind_backend.Controllers;
using northwind_backend.DTOS;
using northwind_backend.Models;
using northwind_backend.Repositories;

namespace northwind_backend_tests
{
    [TestClass]
    public class CustomerControllerTests
    {
        [TestMethod]
        public async Task Customer_table_Is_Null()
        {
            // Arrange
            var repository = new Mock<ICustomerRepository>();
            repository.Setup(r => r.IsCustomerNull()).Returns(true);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            var mapper = config.CreateMapper();

            var controller = new CustomerController(mapper, repository.Object);

            // Act
            var actionResult = await controller.GetCustomers(1);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Customer_table_Is_Not_Null()
        {
            // Arrange
            var repository = new Mock<ICustomerRepository>();
            repository.Setup(r => r.IsCustomerNull()).Returns(false);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDto>());
            var mapper = config.CreateMapper();

            var controller = new CustomerController(mapper, repository.Object);

            // Act
            var actionResult = await controller.GetCustomers(1);

            // Assert
            Assert.IsInstanceOfType(actionResult.Result, typeof(OkObjectResult));
        }
    }
}