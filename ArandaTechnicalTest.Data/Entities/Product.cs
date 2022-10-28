using System.ComponentModel.DataAnnotations;

namespace ArandaTechnicalTest.Data.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Category { get; set; }

        [StringLength(250)]
        public string? Image { get; set; }
    }
}
