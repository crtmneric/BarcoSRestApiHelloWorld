using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;

namespace BarcoSRestApi.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductService productService = new ProductService();
        private readonly TokenService tokenService = new TokenService();

        
        [HttpGet]
        [Route("api/v1/ProductList")]
        public IHttpActionResult Get([FromUri]string token)
        {
            if (tokenService.isTokenValidate(token))
            {
                ProductResponse response = new ProductResponse();
                response.Products = productService.GetProducts();
                return Ok(response);
            }

            return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");
        }

       
        [ResponseType(typeof(Product))]
        [Route("api/v1/GetProductByName/{name}")]
        [HttpGet]
        public IHttpActionResult Get([FromUri]string name,[FromUri] string token)
        {
            if (tokenService.isTokenValidate(token))
            {
                var product = productService.GetProduct(name);
                if (product == null)
                    return Content(HttpStatusCode.NotFound, "There is no product like:" + name);
                return Ok(product);
            }
            else
            {
                 return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");
            }
           
        }

        
        [ResponseType(typeof(bool))]
        [HttpDelete]
        [Route("api/v1/DeleteProduct/{name}")]
        public IHttpActionResult Delete([FromUri]string name,[FromUri] string token)
        {
            if (tokenService.isTokenValidate(token))
            {
                if (!productService.DeleteProduct(name))
                    return Content(HttpStatusCode.NotFound, "There is no product like:" + name);
                return Content(HttpStatusCode.OK,"Successfully deleted");
            }

            return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");

           
        }


        [ResponseType(typeof(bool))]
        [HttpPut]
        [Route("api/v1/UpdateProduct/{id}")]
        public IHttpActionResult Update([FromUri] string token,[FromBody] Product product)
        {
            if (tokenService.isTokenValidate(token))
            {
                if (product != null)
                {
                    if (!productService.UpdateProduct(product))
                        return Content(HttpStatusCode.NotFound, "There is no product like:" + product.name);
                    return Content(HttpStatusCode.OK, "Succesfully Updated Product:" + product.name);
                }
                return Content(HttpStatusCode.NotFound, "There is no product like:" + product.name);

            }
            return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");

        }


        [ResponseType(typeof(bool))]
        [Route("api/v1/AddProduct")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Product product,[FromUri] string token)
        {
            if (product != null)
            {
                if (tokenService.isTokenValidate(token))
                {
                    if (!productService.AddProduct(product))
                        return Content(HttpStatusCode.NotAcceptable,
                            "The product you have tried to add is contains invalid keys.");
                    return Ok("Successfully added");
                }

                return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");
            }

            return Content(HttpStatusCode.NotAcceptable, "Wrong Json syntax, Check it dude.");
        }
    }
}