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
    
    public partial class TblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblOrder()
        {
            this.TblClientProductRel = new HashSet<TblClientProductRel>();
        }
    
        public int id { get; set; }
        public long Sum { get; set; }
        public bool IsFInaly { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> DiscountId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblClientProductRel> TblClientProductRel { get; set; }
        public virtual TblDiscount TblDiscount { get; set; }
    }
}
