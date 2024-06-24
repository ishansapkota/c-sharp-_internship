using ApplicationLayer.Service_Interface;
using DomainLayer.Entity;
using DomainLayer.Repo_Interface;
using InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service
{
    public class EmployeeService:IEmployeeService<Employee>
    {
        private readonly IEmployeeRepository<Employee> _iEmp;

        public EmployeeService(IEmployeeRepository<Employee> iEmp)
        {
            _iEmp = iEmp;
        }
        public Task<IEnumerable<Employee>> GetAllEmployeeAsync()
        {
            var employee = _iEmp.GetAllAsync();
            return employee;
        }

        public async Task AddEmployeeAsync(Employee emp)
        {
            await _iEmp.AddAsync(emp); 
        }

        public async Task UpdateEmployeeAsync(Employee emp)
        {
            await _iEmp.UpdateAsync(emp);
        }

        public  async Task<Employee> GetEmployeeById(int id)
        {
            return await _iEmp.GetByIdAsync(id);
        }

        public Task DeleteEmployeeAsync(int id)
        {
            return _iEmp.DeleteAsync(id);
        }
    }
}
