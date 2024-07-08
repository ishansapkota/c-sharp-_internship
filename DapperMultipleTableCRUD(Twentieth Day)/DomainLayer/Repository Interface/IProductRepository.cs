using DomainLayer.DTO;
using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repository_Interface
{
    public interface IProductRepository
    {
        void Add(ProductDTO product);

        IEnumerable<ProductDTO> Get();

        ProductDTO GetById(int id);

        void Update(ProductDTO product);

        void Delete(int id);
    }
}
