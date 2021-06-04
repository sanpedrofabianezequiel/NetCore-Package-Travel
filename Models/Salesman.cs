using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Salesman : ModelBase
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required, MinLength(8), MaxLength(20)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string UserName { get; set; }

        //TODO revisar privacidad de la contraseña
        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public bool IsActive { get; set; } = false;

        public bool IsAdmin { get; set; } = false;
    }
}
