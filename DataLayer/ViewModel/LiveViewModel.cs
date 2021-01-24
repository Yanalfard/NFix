using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models.Regular;

namespace DataLayer.ViewModel
{
    public class LiveViewModel : TblLive
    {
        public string Username { get; set; }
        public bool IsPremium { get; set; }
        public TblUserPass UserPass { get; set; }
        public string ToutorName { get; set; }
        public string ToutorSpeciality { get; set; }
        public string ToutorMainImage { get; set; }
        public LiveViewModel(TblLive live)
        {
            DescriptionLong = live.DescriptionLong;
            DescriptionShort = live.DescriptionShort;
            TimeStart = live.TimeStart;
            Chanel = live.Chanel;
            IsHome = live.IsHome;
            Title = live.Title;
            MainImage = live.MainImage;
            Price = live.Price;
            id = live.id;
            ToutorId = live.ToutorId;
            ToutorSpeciality = live.TblTutor.Specialty;
            MainImage = live.TblTutor.MainImage;
        }
    }
}
