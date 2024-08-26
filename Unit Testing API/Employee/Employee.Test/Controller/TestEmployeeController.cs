using Employee.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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

            var testController = new EmployeeController();

            //ACT

            var result = (OkObjectResult)await testController.Get();


            //ASSERT

            result.StatusCode.Should().Be(200);
        }

    }
}
