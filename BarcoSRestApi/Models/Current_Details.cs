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
    
    public partial class Current_Details
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> current_id { get; set; }
        public Nullable<int> type { get; set; }
        public string text { get; set; }
        public string reg_date { get; set; }
        public string expiry_date { get; set; }
        public Nullable<decimal> price { get; set; }
    }
}
