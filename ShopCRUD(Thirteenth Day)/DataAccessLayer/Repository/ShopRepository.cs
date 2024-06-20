using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ShopRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public  void Add(Shop s)
        {
             _applicationDbContext.Add(s);
             _applicationDbContext.SaveChanges();
        }

        public async void Update(Shop s)
        {
            _applicationDbContext.Entry(s).State = EntityState.Modified;
            await _applicationDbContext.SaveChangesAsync();
        }

        public void Delete(Shop s)
        {
            _applicationDbContext.Remove(s);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Shop> GetAll()
        {
            return _applicationDbContext.Set<Shop>().ToList();
        }

        public Shop GetByID(int id)
        {
            return _applicationDbContext.Set<Shop>().FirstOrDefault(i => i.ShopID == id);
        }
           
    }
}
