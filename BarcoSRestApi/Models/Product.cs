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
    
    public partial class Product
    {
        public int id { get; set; }
        public Nullable<int> company_id { get; set; }
        public string name { get; set; }
        public string sef { get; set; }
        public string stock_code { get; set; }
        public string shelf_number { get; set; }
        public Nullable<int> current { get; set; }
        public string text { get; set; }
        public Nullable<decimal> stock { get; set; }
        public Nullable<int> brand_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<decimal> risk_limit { get; set; }
        public string barcode_number { get; set; }
        public Nullable<decimal> purchase_price { get; set; }
        public Nullable<decimal> sale_price { get; set; }
        public Nullable<decimal> third_price { get; set; }
        public string features { get; set; }
        public byte[] product_İmage { get; set; }
        public Nullable<int> unit { get; set; }
        public Nullable<System.DateTime> registertime { get; set; }
        public Nullable<System.DateTime> updatetime { get; set; }
    }
}
