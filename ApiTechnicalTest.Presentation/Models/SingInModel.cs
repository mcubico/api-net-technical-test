using ApiTechnicalTest.Presentation.Resources;
using System.ComponentModel.DataAnnotations;

namespace ApiTechnicalTest.Presentation.Models
{
    public class SingInModel
    {
        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false,
            ErrorMessageResourceType = typeof(MessagesResource),
            ErrorMessageResourceName = "Required")]
        public string Password { get; set; }
    }
}
