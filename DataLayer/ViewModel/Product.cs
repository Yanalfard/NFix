using DataLayer.Models.Dto;
using DataLayer.Models.Regular;
using DataLayer.Services.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataLayer.ViewModel
{
    public class ProductViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string DateSubmited { get; set; }
        public string Keywords { get; set; }
        public string Catagory { get; set; }
        public int CatagoryMain { get; set; }
        public List<TblCatagory> AllCatagory { get; set; }
        public int Raiting { get; set; }
        public long Price { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MinLength(5, ErrorMessage = "تعداد کاراکتر کم است")]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string DescriptionHtml { get; set; }
        public Nullable<int> CatagoryId { get; set; }
        public Nullable<int> Count { get; set; }
        public bool IsSuggested { get; set; }
        public int Discount { get; set; }
        public int Status { get; set; }


        public virtual TblCatagory TblCatagory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblClientProductRel> TblClientProductRel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductCommentRel> TblProductCommentRel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductImageRel> TblProductImageRel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductKeywordRel> TblProductKeywordRel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblProductPropertyRel> TblProductPropertyRel { get; set; }
    }
}
