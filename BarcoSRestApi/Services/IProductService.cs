using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcoSRestApi.Models;


namespace BarcoSRestApi.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProduct(string name);
        Boolean DeleteProduct(string name);
        Boolean AddProduct(Product product);
    }
}
