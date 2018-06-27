using System;
using System.Linq;
using BarcoSRestApi.Models;

namespace BarcoSRestApi.Services
{
    public class TokenService
    {
        public bool isTokenValidate(string token)
        {
            var db = new BarcosEntities();
            Warehouse searchToken = db.Warehouses.Where(x => x.name == token).FirstOrDefault();
            if (searchToken != null)
            {
                var result = DateTime.Compare(DateTime.Now, DateTime.Parse(searchToken.reg_date.ToString()));
                if (result < 0) return true;
            }

            return false;
        }
    }
}