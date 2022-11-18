using ApiTechnicalTest.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Presentation.ModelsDTO
{
    public class CategoryCreationDTO
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        [StringLength(50,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string Name { get; set; }

        [StringLength(500,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Description { get; set; }

        [StringLength(250,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "StringLengthMax")]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string? Picture { get; set; }

        public IFormFile? File { get; set; }
    }
}
