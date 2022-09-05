using System.ComponentModel.DataAnnotations;

namespace Bca_New.Models
{
    public class Players
    {
        [Key]
        public int id { get; set; }
        public string? name { get; set; }
        public string? tournment_type { get; set; }
        public string? sport_name { get; set; }
        public DateTime date{ get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public string? status { get; set; }
        //public string? image { get; set; }
    }
}
