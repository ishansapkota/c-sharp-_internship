using DomainLayer.DTO;
using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Service_Interface
{
    public interface IProductService
    {
        void AddProduct(ProductDTO product);

        IEnumerable<ProductDTO> GetProduct();

        ProductDTO GetProductById(int id);

        void UpdateProduct(ProductDTO product);

        void DeleteProduct(int id);
    }
}
