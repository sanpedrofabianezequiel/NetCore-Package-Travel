using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CreateSalesmanDTO
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string UserName { get; set; }

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now.Date;

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
        public bool IsActive { get { return true; } }
    }
}
