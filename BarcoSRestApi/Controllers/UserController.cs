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
            if (tokenService.isTokenValidate(token))
            {
                UserResponse response = new UserResponse();
                response.Users = userService.GetUsers(token);
                return Ok(response);
            }


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

        [ResponseType(typeof(UserBean))]
        [Route("api/v1/GetUserByName/{name}")]
        [HttpGet]
        public IHttpActionResult GetUser([FromUri] string name, [FromUri] string token)
        {
            if (tokenService.isTokenValidate(token))
            {
                if (!String.IsNullOrEmpty(name))
                {
                    var toReturn = userService.GetUserByName(name);
                    if (toReturn != null)
                    {
                        return Ok(toReturn);
                    }

                    return Content(HttpStatusCode.NotFound, "User not found..");
                }
            }

            return Content(HttpStatusCode.Unauthorized, "Token expired or not found.");

        }

        [ResponseType(typeof(bool))]
        [Route("api/v1/DeleteUser/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id, [FromUri] string token)
        {
            if (tokenService.isTokenValidate(token))
            {

                if (userService.DeleteUser(id))
                {
                    return Ok("Successfully deleted user..");
                }

                return Content(HttpStatusCode.NotFound, "User Not Found!");
            }

            return Content(HttpStatusCode.Unauthorized, "Token expired or not found!");
        }

        [ResponseType(typeof(bool))]
        [HttpPut]
        [Route("api/v1/UpdateUser")]
        public IHttpActionResult Update([FromBody] user userck, [FromUri] string token)
        {
            if (tokenService.isTokenValidate(token))
            {
                if (userService.UpdateUser(userck))
                {
                    return Ok("Successfully updates user..");
                }

                return Content(HttpStatusCode.NotFound, "User Not Found!");
            }

            return Content(HttpStatusCode.Unauthorized, "Token expired or not found!");
        }
    }
}