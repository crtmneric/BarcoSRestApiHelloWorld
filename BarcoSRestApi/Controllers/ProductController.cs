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
        [Route("api/v1/ProductList")]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }

        [ResponseType(typeof(Product))]
        [Route("api/v1/GetProductByName/{name}")]
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
        [Route("api/v1/DeleteProduct/{name}")]
        public IHttpActionResult Delete(string name)
        {

            if (!productService.DeleteProduct(name))
                return NotFound();
            return Ok("Successfully deleted");
        }

        [ResponseType(typeof(Boolean))]
        [Route("api/v1/AddProduct")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!productService.AddProduct(product))
                return NotFound();
            return Ok("Successfully added");




        }
    }
}
