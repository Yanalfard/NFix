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
    
    public partial class TblTutor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblTutor()
        {
            this.TblTuotorVideoRel = new HashSet<TblTuotorVideoRel>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public string IdentificationNo { get; set; }
        public string TellNo { get; set; }
        public string MainImage { get; set; }
        public string Description { get; set; }
        public int UserPassId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblTuotorVideoRel> TblTuotorVideoRel { get; set; }
        public virtual TblUserPass TblUserPass { get; set; }
    }
}
