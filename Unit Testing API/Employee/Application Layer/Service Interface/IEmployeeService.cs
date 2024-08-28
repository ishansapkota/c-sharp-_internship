using Domain_Layer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Service_Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployee();

        Task AddEmployee(EmployeeDTO emp);
    }
}
