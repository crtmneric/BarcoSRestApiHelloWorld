//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcoSRestApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bank
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> bank_name { get; set; }
        public string auth_name { get; set; }
        public string iban_number { get; set; }
        public Nullable<int> pos { get; set; }
    }
}
