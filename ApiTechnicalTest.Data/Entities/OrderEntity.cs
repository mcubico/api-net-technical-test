using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTechnicalTest.Data.Entities
{
    public class OrderEntity : BaseEntity<Guid>
    {
        #region PROPERTIES

        [Required]
        [DataType(dataType: DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        public bool RequiredDate { get; set; } = false;

        [DataType(dataType: DataType.Date)]
        public DateTime? ShippedDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string ShipAdress { get; set; }

        public Guid? ShipVia { get; set; }

        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? ShipName { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? ShipPostalCode { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        #endregion

        #region FOREING KEY

        [ForeignKey(nameof(EmployeeId))]
        public EmployeeEntity Employee { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }

        [ForeignKey(nameof(ShipVia))]
        public ShipperEntity? Shipper { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }

        #endregion
    }
}
