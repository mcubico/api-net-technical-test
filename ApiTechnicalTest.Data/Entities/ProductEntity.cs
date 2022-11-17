using ApiTechnicalTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechnicalTest.Data.Entities
{
    [Index(nameof(Name))]
    public class ProductEntity : BaseEntity<Guid>
    {
        #region PROPERTIES

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [Required]
        public int QuantityPerUnit { get; set; } = 0;

        [Required]
        public decimal UnitPrice { get; set; } = 0;

        [Required]
        public int UnitsInStock { get; set; } = 0;

        public int? UnitsOnOrder{ get; set; } = 0;

        public int? RecorderLevel { get; set; }

        [Required]
        public bool Discontinuated { get; set; } = false;

        [Required]
        public Guid SupplierId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        #endregion

        #region FOREING KEY

        [ForeignKey(nameof(SupplierId))]
        public SupplierEntity Supplier { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }

        #endregion
    }
}
