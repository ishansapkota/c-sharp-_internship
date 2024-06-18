using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IGenericRepository <T> where T : class
    {
       /* IEnumerable<T> GetAllData();
        T GetByID(int id);*/

        void Add(T t);
/*
        void Update(T t);

        void Delete(int id);
    */}
}
