using DataAccessLayer.EntitiesOrModel;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class Service<T> : IService <Work> 
    {
        private readonly IWorkOperationsRepository<Work> _iWorkOp;

        public Service(IWorkOperationsRepository<Work> iWorkOp)
        {
            _iWorkOp = iWorkOp;
        }
        public void CreateWorkData(Work t)
        {
            _iWorkOp.AddData(t);
        }

        public void UpdateWorkData(Work t)
        {
            _iWorkOp.Update(t);

        }


        public void DeleteWorkData(int id)
        {
            var work = _iWorkOp.GetByID(id);
            if(work != null)
            {
                _iWorkOp.Delete(work);
            }    

        }

        public IEnumerable<Work> ListWorkData()
        {
            return _iWorkOp.GetAllValue();
        }

        public Work GetWorkByDay(int day)
        {
            return _iWorkOp.GetByID(day);
        }

    }
}
