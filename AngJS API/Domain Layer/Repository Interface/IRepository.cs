using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Repository_Interface
{
    public interface IRepository<T> where T :class
    {
        Task<IEnumerable<T>> GetTodosAsync();

        Task AddTodoAsync(T todo);

        /* Task UpdateTodoAsync(T todo);

        Task<T> GetTodoByIdAsync(int id);*/
    }
}
