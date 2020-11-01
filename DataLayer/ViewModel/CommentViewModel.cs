using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class CommentViewModel
    {
        public int Commentid { get; set; }
        public int ClientId { get; set; }
        public int VideoId { get; set; }
        public int BlogId { get; set; }
        [Display(Name ="پیام")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public string Body { get; set; }
        public string DateSubmited { get; set; }
        public bool IsValid { get; set; }
        public int Raiting { get; set; }

        

    }
}
