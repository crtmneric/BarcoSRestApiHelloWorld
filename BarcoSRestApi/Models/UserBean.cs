using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarcoSRestApi.Models
{
    public class UserBean
    {
        
            public string auth_name { get; set; }
            public string email { get; set; }
            public Nullable<int> password { get; set; }
        
    }
}