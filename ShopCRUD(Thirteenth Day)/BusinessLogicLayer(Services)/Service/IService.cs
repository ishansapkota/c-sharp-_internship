using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_Services_.Service
{
    public interface IService<T> where T : class
    {
        void AddData(T t);
        void UpdateData(T t);
        void DeleteData(T t);
        IEnumerable<T> GetAllData();
        T GetDataByID(int id);

    }
}
