using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface IEmployeeService<T> where T : class
    {
       /* Task AddEmployee(T t);
        Task DeleteEmployee(T t);
*/
        Task<IEnumerable<T>> GetAllEmployeeAsync();
        Task AddEmployeeAsync(T t);

        Task UpdateEmployeeAsync(T t);

        Task<T> GetEmployeeById(int id);

        Task DeleteEmployeeAsync(int id);

    }
}
