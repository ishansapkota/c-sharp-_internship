using ApplicationLayer.Service_Interface;
using DomainLayer.DTO;
using DomainLayer.Entity;
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

     

        public IEnumerable<ProductDTO> GetProduct()
        {
            var data =  iProduct.Get();
            return data;
        }

        public ProductDTO GetProductById(int id)
        {
            var product = iProduct.GetById(id);
            return product;
        }

        public void UpdateProduct(ProductDTO product) 
        {
            iProduct.Update(product);

        }

        public void DeleteProduct(int id)
        {
            iProduct.Delete(id);
        }
    }
}
