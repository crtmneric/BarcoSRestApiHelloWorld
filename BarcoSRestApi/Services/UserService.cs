using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BarcoSRestApi.Exceptions;
using BarcoSRestApi.Extensions;
using BarcoSRestApi.Models;

namespace BarcoSRestApi.Services
{
    public class UserService : IUserService
    {
        private const string ApiKey =
            "SohNoQHtcGZsTH1JY5zkKiU8Whvp8VV5xWyaThNmb6nhwRK4YdYYIgEtO6AKDengijhMXtwsDhMaDLsZSnl9L5y2RzJ62duyPmXL";

        private readonly BarcosEntities db = new BarcosEntities();
        private readonly TokenService ts = new TokenService();
        public user AddUser(string email, int? password, string authName, string apiKey)
        {
            Logger.LOGGER.InfoFormat("trying to add user for email:{0}, password: {1}, authName: {2}, apiKey: {3}", email, password, authName, apiKey);

            if (!checkIfEmailExists(email) && apiKey == ApiKey&&!String.IsNullOrEmpty(authName)&&!String.IsNullOrEmpty(email))
            {
                var userToAdd = new user {email = email};
                if (!password.HasValue)
                {
                    Logger.LOGGER.Error("password has no value to add user: "+email);
                    throw new ValidationException("Password Can Only be Numeric, and shouldnt be empty !");
                }
                
                userToAdd.password = Convert.ToInt32(password);
                userToAdd.auth_name = authName;
                db.users.Add(userToAdd);

                Logger.LOGGER.Info("successfully created user, now inserting to database: "+userToAdd);
                userToAdd.id = db.SaveChanges();

                Logger.LOGGER.Info("successfully added user ");
                return userToAdd;
            }

            throw new ValidationException("There is a validation error with your request.");
        }

        public bool DeleteUser(int id)
        {
            var userToSearch = db.users.Where(x => x.id == id).FirstOrDefault();
            if (userToSearch != null)
            {
                db.users.Remove(userToSearch);
                db.SaveChanges();
                return true;
            }

            return false;
        }

      

        public user GetUserByCredentials(string email, string password)
        {
            var userToSearch = db.users.Where(x => x.email == email).FirstOrDefault();
            if (userToSearch != null)
            {
                var pass = userToSearch.password.ToString();

                if (pass == password) return userToSearch;
            }

            return null;
        }

        public user GetUserByName(string name)
        {
            var userToSearch = db.users.Where(x => x.auth_name == name).FirstOrDefault();
            if (userToSearch != null)
            {
                return userToSearch;
            }

            return null;
        }

        public List<user> GetUsers(string token)
        {
            if (ts.isTokenValidate(token)) return db.users.ToList();
            return null;
        }

        public bool UpdateUser(user userck)
        {
            var userToSearch = db.users.Where(x => x.id == userck.id).FirstOrDefault();
            if (userToSearch != null)
            {
                userToSearch = userck;
                db.users.AddOrUpdate(userToSearch);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool checkIfEmailExists(string email)
        {

            return db.users.FirstOrDefault(x => x.email == email) != null;
        }
    }
}