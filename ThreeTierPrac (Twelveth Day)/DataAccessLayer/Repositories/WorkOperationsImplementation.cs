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
    public class WorkOperationsImplementation : IWorkOperationsRepository <Work>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WorkOperationsImplementation(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
       async public void AddData(Work w)
        {
            await _applicationDbContext.Works.AddAsync(w);
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Update(Work w)
        {
            _applicationDbContext.Entry(w).State = EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public void Delete(Work w)
        {
            _applicationDbContext.Remove(w);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Work> GetAllValue()
        {
            return _applicationDbContext.Works.ToList();
        }

        public Work GetByID(int id)
        {
            return _applicationDbContext.Works.FirstOrDefault(i=> i.Day==id);
        }


    }
}
