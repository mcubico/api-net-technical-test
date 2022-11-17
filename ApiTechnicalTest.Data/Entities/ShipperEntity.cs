using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    public class ShipperEntity : BaseEntity<Guid>
    {
        #region PROPERTIES

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string ShipperId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Phone { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<OrderEntity> Orders { get; set; }

        #endregion
    }
}
