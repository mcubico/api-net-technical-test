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

        [StringLength(250,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        [StringLength(50,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Category { get; set; }

        [StringLength(250,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        public string? Image { get; set; }

        public IFormFile? File { get; set; }
    }
}
