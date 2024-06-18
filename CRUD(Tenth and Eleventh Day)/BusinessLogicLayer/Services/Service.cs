using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public  class Service : IService
    {
        private readonly IGenericRepository<Employee> _repo;

        public Service(IGenericRepository<Employee> repo)
        {
            _repo = repo;
        }

        public void CreateEmployee(Employee employee)
        {
            _repo.Add(employee);
        }
    }
}
