using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ModelBase
    {
        [Required]
        public virtual long ID { get; set; }
    }
}
