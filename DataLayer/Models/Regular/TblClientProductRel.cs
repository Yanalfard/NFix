//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer.Models.Regular
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblClientProductRel
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> Discount { get; set; }
    
        public virtual TblClient TblClient { get; set; }
        public virtual TblOrder TblOrder { get; set; }
        public virtual TblProduct TblProduct { get; set; }
    }
}
