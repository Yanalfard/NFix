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
    
    public partial class TblUserPass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUserPass()
        {
            this.TblClient = new HashSet<TblClient>();
            this.TblTutor = new HashSet<TblTutor>();
        }
    
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Auth { get; set; }
        public bool IsActive { get; set; }
        public int Role { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblClient> TblClient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblTutor> TblTutor { get; set; }
    }
}