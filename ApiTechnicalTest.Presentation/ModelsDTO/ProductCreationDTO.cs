using ApiTechnicalTest.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace ArandaTechnicalTest.Presentation.ModelsDTO
{
    public class ProductCreationDTO
    {
        [Required(AllowEmptyStrings = false, 
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        [StringLength(50, 
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [Required(
           ErrorMessageResourceType = typeof(MessagesResource),
           ErrorMessageResourceName = "Required")]
        public Guid CategoryId { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        public int QuantityPerUnit { get; set; } = 0;

        [Required(
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        public decimal UnitPrice { get; set; } = 0;

        public int? UnitsOnOrder { get; set; } = 0;

        public int? RecorderLevel { get; set; } = 0;

        public bool? Discontinuated { get; set; } = false;

        [Required(
           ErrorMessageResourceType = typeof(MessagesResource),
           ErrorMessageResourceName = "Required")]
        public Guid SupplierId { get; set; }
    }
}
