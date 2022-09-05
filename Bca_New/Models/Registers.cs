using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bca_New.Models   
{
    public class Registers
    {
        [Key]
        public int id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage ="name is required filed")]
        [Display(Name ="name")]
        public string? name { get; set; }
        [Required(ErrorMessage = "email is required filed")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Please provide vaild email")]
        [DataType(DataType.EmailAddress)]

        public string? email { get; set; }
        [Required(ErrorMessage = "password is required filed")]
        [DataType(DataType.Password)]
        [StringLength(10, MinimumLength = 5)]
        public string? password { get; set; }
    }
}

