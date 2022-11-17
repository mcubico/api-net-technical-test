using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    [Index(nameof(CompanyName))]
    [Index(nameof(PostalCode))]
    public class SupplierEntity : CustomerBaseEntity
    {
        #region PROPERTIES

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string SupplierId { get; set; }

        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? HomePage { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<ProductEntity> Products { get; set; }

        #endregion
    }
}
