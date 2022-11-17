using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; } = default!;

        [Required]
        public virtual bool Active { get; set; } = true;
    }
}
