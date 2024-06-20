using DataAccessLayer.Entity;
using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer_Services_.Service
{
    public class ShopService:IService<Shop>
    {
        private readonly IRepository<Shop> _iRepo;

        public ShopService(IRepository<Shop> iRepo)
        {
            _iRepo = iRepo;
        }

        public IEnumerable<Shop> GetAllData()
        {
            return _iRepo.GetAll();
        }

        public void AddData(Shop shop)
        {
            _iRepo.Add(shop);
        }

        public void UpdateData(Shop shop)
        {
            _iRepo.Update(shop);
        }

        public void DeleteData(Shop shop)
        {
            _iRepo.Delete(shop);
        }
        public Shop GetDataByID(int id)
        {
            return _iRepo.GetByID(id);
        }

    }
}
