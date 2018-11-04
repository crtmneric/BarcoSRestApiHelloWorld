using System.Collections.Generic;
using BarcoSRestApi.Models;

namespace BarcoSRestApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string name);
        bool DeleteProduct(string name);
        bool AddProduct(Product product);
        bool UpdateProduct(Product product);
    }
}