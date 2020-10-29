using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ViewModel
{
    public class VideoViewViewModel
    {
        public int id { get; set; }
        public string VideoUrl { get; set; }
        public string VidioDemoUrl { get; set; }
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DescriptionDemo { get; set; }
        public string DateSubmited { get; set; }
        public bool IsOnline { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public int Raiting { get; set; }
        public string ShareLink { get; set; }
        public string UserName { get; set; }
        public bool IsPremium { get; set; }
        public int UserPassId { get; set; }
        public string TutorName { get; set; }
        public string TutorMainImage { get; set; }
        public string TutorSpecialty { get; set; }

    }
}
