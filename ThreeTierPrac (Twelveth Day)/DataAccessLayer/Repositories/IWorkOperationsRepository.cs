using DataAccessLayer.EntitiesOrModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IWorkOperationsRepository<T> where T : class
    {
        void AddData(T t);

        void Update(T t);

        void Delete(T t);

        IEnumerable<T> GetAllValue();

        T GetByID(int id);
        
    }
}
