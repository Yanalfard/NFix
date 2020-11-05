using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models.Metadata
{
    public class MdTuotorVideoRel
    {
        [Key]
        public int id { get; set; }
        public int ToutorId { get; set; }
        public int VideoId { get; set; }

    }
}
