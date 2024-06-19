using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public interface IService <T> where T : class
    {

        void CreateWorkData(T t);
        void UpdateWorkData(T t);

        void DeleteWorkData(int id);

        IEnumerable<T> ListWorkData();

        T GetWorkByDay(int day);

    }
}
