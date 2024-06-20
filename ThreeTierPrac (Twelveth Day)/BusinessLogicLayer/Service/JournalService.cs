using DataAccessLayer.EntitiesOrModel;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class JournalService:IService<Journal>
    {
        private readonly IWorkOperationsRepository<Journal> _iWorkOp;

        public JournalService(IWorkOperationsRepository<Journal> iWorkOp)
        {
            _iWorkOp = iWorkOp;
        }

        public void CreateWorkData(Journal j)
        {
            _iWorkOp.AddData(j);
        }

        public void UpdateWorkData(Journal j)
        {
            _iWorkOp.Update(j);
        }

        public void DeleteWorkData(int i)
        {
            var journal = _iWorkOp.GetByID(i);
            _iWorkOp.Delete(journal);
        }

        public  IEnumerable<Journal> ListWorkData()
        {
            return _iWorkOp.GetAllValue();
        }

        public Journal GetWorkByDay(int day)
        {
            return _iWorkOp.GetByID(day);
        }
    }
}
