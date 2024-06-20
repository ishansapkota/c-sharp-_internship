using DataAccessLayer.Data;
using DataAccessLayer.EntitiesOrModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class JournalEntryOperation : IWorkOperationsRepository<Journal>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public JournalEntryOperation(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void AddData(Journal j)
        {
            _applicationDbContext.Journals.Add(j);
            _applicationDbContext.SaveChanges();
        }

        public void Update(Journal j)
        {
            _applicationDbContext.Entry(j).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Journal j)
        {
            _applicationDbContext.Remove(j);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Journal> GetAllValue()
        {
            return _applicationDbContext.Journals.ToList() ;
        }

        public Journal GetByID(int id)
        {
            return _applicationDbContext.Journals.FirstOrDefault(i=>i.JournalID==id);
        }

    }
}
