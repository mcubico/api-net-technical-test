namespace ApiTechnicalTest.Presentation.Models
{
    public class AuthenticationResponseModel
    {
        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
