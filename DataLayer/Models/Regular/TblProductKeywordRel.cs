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
    
    public partial class TblProductKeywordRel
    {
        public int id { get; set; }
        public int ProductId { get; set; }
        public int KeywordId { get; set; }
    
        public virtual TblKeyword TblKeyword { get; set; }
        public virtual TblProduct TblProduct { get; set; }
    }
}
