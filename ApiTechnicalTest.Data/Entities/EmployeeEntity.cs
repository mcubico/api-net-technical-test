using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    [Index(nameof(FirstName), nameof(LastName))]
    [Index(nameof(PostalCode))]
    public class EmployeeEntity : BaseEntity<Guid>
    {
        #region PROPERTIES

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string EmployeeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string LastName { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Title { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? TitleOfCourtesy { get; set; }

        [Required]
        [DataType(dataType: DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(dataType: DataType.Date)]
        public DateTime HireDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string HomePhone { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Extension { get; set; }

        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Photo { get; set; }

        [StringLength(500)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Notes { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string ReportsTo { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? PostalCode { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<OrderEntity> Orders { get; set; }

        #endregion
    }
}
