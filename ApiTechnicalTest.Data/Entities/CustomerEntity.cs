using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Data.Entities
{
    [Index(nameof(CompanyName))]
    [Index(nameof(City))]
    [Index(nameof(Region))]
    [Index(nameof(PostalCode))]
    public class CustomerEntity : CustomerBaseEntity
    {
        #region PROPERTIES

        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string CustomerId { get; set; }

        #endregion

        #region RELATIONS

        public virtual ICollection<OrderEntity> Orders { get; set; }

        #endregion
    }
}
