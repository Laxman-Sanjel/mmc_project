using System.ComponentModel.DataAnnotations;

namespace Bca_New.Models
{
    public class Result
    {
        [Key]
        public int id { get; set; }

        public string? tournment_name { get; set; }
        public string? name { get; set; }
        public string? rank { get; set; }
    }
}
