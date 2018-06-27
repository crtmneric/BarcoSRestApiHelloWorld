using System.Collections.Generic;
using BarcoSRestApi.Models;

namespace BarcoSRestApi.Services
{
    public interface IUserService
    {
        user GetUserByCredentials(string email, string password);
        user AddUser(string email, int? password, string authName, string apiKey);
        List<user> GetUsers(string token);
    }
}