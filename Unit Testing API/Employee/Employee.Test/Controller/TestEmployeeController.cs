using Application_Layer.Service_Interface;
using Domain_Layer.DTOs;
using Employee.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Test.Controller
{
    public class TestEmployeeController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode()
        {
            //ARRANGE
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(service => service.GetEmployee()).ReturnsAsync(new List<EmployeeDTO>());

            var testController = new EmployeeController(mockService.Object);

            //ACT

            var result = (OkObjectResult)await testController.Get();


            //ASSERT
            //result.StatusCode.Should().Be(200);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnList()
        {
            //ARRANGE
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(service => service.GetEmployee()).ReturnsAsync(new List<EmployeeDTO>());

            var testController = new EmployeeController(mockService.Object);

            //ACT

            var result = (OkObjectResult)await testController.Get();

            //ASSERT
            
            //result.Value.Should().BeOfType<List<EmployeeDTO>>();
            Assert.IsType<List<EmployeeDTO>>(result.Value);
        }

        [Fact]
        public async Task Post_OnSuccess_ReturnsOkResult()
        {
            // ARRANGE
            var mockService = new Mock<IEmployeeService>();
            var testEmployee = new EmployeeDTO();
            mockService.Setup(service => service.AddEmployee(testEmployee)).Returns(Task.CompletedTask);

            var testController = new EmployeeController(mockService.Object);

            // ACT
            var result = await testController.Post(testEmployee);

            // ASSERT
            Assert.IsType<OkResult>(result); // Verifies that the method returns an OkResult
            mockService.Verify(service => service.AddEmployee(testEmployee), Times.Once); // Verifies that AddEmployee was called exactly once
        }

        [Fact]
        public async Task Post_OnNull_ReturnsBadRequest()
        {
            //ARRANGE
            var mockService = new Mock<IEmployeeService>();
            var testEmployee = new EmployeeDTO();
            var testController = new EmployeeController(mockService.Object);

            //ACT
            var result = await testController.Post(null);

            //ASSERT
            Assert.IsType<BadRequestResult>(result);


        }

    }
}
