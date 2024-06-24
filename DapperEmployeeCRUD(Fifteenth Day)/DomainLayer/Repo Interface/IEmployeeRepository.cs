using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repo_Interface
{
    public interface IEmployeeRepository<T> where T : class
    {
        Task AddAsync(T t);
        Task UpdateAsync(T t);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);
    }
}
