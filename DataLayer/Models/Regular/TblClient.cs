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
    
    public partial class TblClient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblClient()
        {
            this.TblClientProductRel = new HashSet<TblClientProductRel>();
            this.TblComment = new HashSet<TblComment>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string IdentificationNo { get; set; }
        public string TellNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int UserPassId { get; set; }
        public int Status { get; set; }
        public bool IsPremium { get; set; }
        public string PremiumTill { get; set; }
        public string InviteCode { get; set; }
    
        public virtual TblUserPass TblUserPass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblClientProductRel> TblClientProductRel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblComment> TblComment { get; set; }
    }
}
