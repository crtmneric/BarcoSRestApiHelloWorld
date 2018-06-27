using System;
using System.Collections.Generic;
using System.Linq;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BarcoSUnitTest
{
    [TestClass]
    public class ProductServiceTester
    {
        private IProductService ps = new ProductService();
        private BarcosEntities db = new BarcosEntities();
        [TestMethod]
        public void GettingNullProduct()
        {
          Assert.AreEqual(null,ps.GetProduct("")); 
        }
        [TestMethod]
        public void AddingNullProduct()
        {
            
            Assert.AreEqual(false,ps.AddProduct(null));
        }
        [TestMethod]
        public void AddingProduct()
        {
            Product product = new Product{barcode_number = "541242132",name = "sik"};
            Assert.AreEqual(true, ps.AddProduct(product));
        }
        [TestMethod]
        public void DeletingNullProduct()
        {
            Assert.AreEqual(false, ps.DeleteProduct(""));
        }
        public void DeletingExistingProduct()
        {
            Assert.AreEqual(true, ps.DeleteProduct("yarrak"));
        }
        [TestMethod]
        public void GettingProductList()
        {
            List<Product> products = db.Products.ToList();
            Assert.AreEqual(products.Count, ps.GetProducts().Count);
        }
    }
}
