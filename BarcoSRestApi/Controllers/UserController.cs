using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using BarcoSRestApi.Exceptions;
using BarcoSRestApi.Models;
using BarcoSRestApi.Services;

namespace BarcoSRestApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly TokenService tokenService = new TokenService();
        private readonly IUserService userService = new UserService();

       
        [HttpGet]
        [Route("api/v1/UserList")]
        public IHttpActionResult Get([FromUri] string token)
        {
            if (tokenService.isTokenValidate(token)) return Ok(userService.GetUsers(token));
            return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");
        }

        [ResponseType(typeof(bool))]
        [Route("api/v1/AddUser")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] UserBean user, [FromUri] string apiKey)
        {
            try
            {
                return Ok(userService.AddUser(user.email, user.password, user.auth_name, apiKey));
            }
            catch (ValidationException exception)
            {
                return Content(HttpStatusCode.BadRequest, exception.Message);
            }
        }
    }
}