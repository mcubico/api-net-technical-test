using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    public class CustomerBaseEntity : BaseEntity<Guid>
    {
        [Required(AllowEmptyStrings = false)]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string CompanyName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string ContactName { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? ContactTitle { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string City { get; set; }

        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Region { get; set; }

        [StringLength(10)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? PostalCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Country { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(15)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Phone { get; set; }

        [StringLength(15)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Fax { get; set; }
    }
}
