using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;

namespace BarcoSRestApi.Controllers
{

    public class ProductController : ApiController
    {

        private IProductService productService = new ProductService();

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        [ResponseType(typeof(Product))]
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var product = productService.GetProduct(name);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [ResponseType(typeof(Boolean))]
        [HttpDelete]
        public IHttpActionResult Delete(string name)
        {

            if (!productService.DeleteProduct(name))
                return NotFound();
            return Ok("Successfully deleted");
        }

        [ResponseType(typeof(Boolean))]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!productService.AddProduct(product))
                return NotFound();
            return Ok("Successfully added");




        }
    }
}
