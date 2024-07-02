using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository iProduct;

        public ProductService(IProductRepository _iProduct)
        {
            iProduct = _iProduct;
        }
        public void AddProduct(ProductDTO product)
        {
            iProduct.Add(product);
        }
    }
}
