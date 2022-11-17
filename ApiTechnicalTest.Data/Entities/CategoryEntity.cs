using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class CategoryEntity : BaseEntity<Guid>
    {
        #region PROPERTIES
        
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [StringLength(500)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Description { get; set; }

        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Picture { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<ProductEntity> Products { get; set; }

        #endregion
    }
}
