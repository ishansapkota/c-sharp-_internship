using ApplicationLayer.Service_Interface;
using DapperEmployeeCRUD_Fifteenth_Day_.Controllers;
using DomainLayer.Entity;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCRUD.Test.Controller
{
    
    public  class TestEmployeeController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200()
        {
            //ARRANGE 
            var mockEmpService = new Mock<IEmployeeService<Employee>>();
            mockEmpService.Setup(service => service.GetAllEmployeeAsync()).ReturnsAsync(new List<Employee>());
            var employeController = new EmployeeController(mockEmpService.Object);


            //ACT
            var result = (OkObjectResult)await employeController.GetEmployeeList();

            //ASSERT
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokeService()
        {
            //ARRANGE
            var mockService = new Mock<IEmployeeService<Employee>>();
            mockService.Setup(service => service.GetAllEmployeeAsync()).ReturnsAsync(new List<Employee>);

            //ACT 

            //ASSERT
        }

    }
}
