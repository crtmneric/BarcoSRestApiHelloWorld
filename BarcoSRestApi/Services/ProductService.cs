using System.Collections.Generic;
using System.Linq;
using BarcoSRestApi.Models;

namespace BarcoSRestApi.Services
{
    public class ProductService : IProductService
    {
        private readonly BarcosEntities db = new BarcosEntities();

        public bool DeleteProduct(string name)
        {
            if (db.Products.Where(x => x.name == name).FirstOrDefault() != null)
            {
                db.Products.Remove(db.Products.Where(x => x.name == name).FirstOrDefault());
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool AddProduct(Product product)
        {
            if (product != null)
            {              
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public Product GetProduct(string name)
        {
            return db.Products.Where(x => x.name == name).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }
    }
}