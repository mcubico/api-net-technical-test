using ApiTechnicalTest.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTechnicalTest.Presentation.Controllers
{
    /// <summary>
    /// Gestiona las acciones de los usuarios
    /// </summary>
    [Route("api/[controller]")]
    [RequireHttps]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region ATTRIBUTES

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _environment;

        #endregion

        #region CONSTRUCTORS

        public AccountController(
            SignInManager<IdentityUser> signInManager,
            IConfiguration environment)
        {
            _signInManager = signInManager;
            _environment = environment;
        }

        #endregion

        #region ACTIONS

        [HttpPost("signIn")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(AuthenticationResponseModel))]
        public async Task<IActionResult> Post([FromForm] SingInModel data)
        {
            var response = await _signInManager.PasswordSignInAsync(
                data.Username, data.Password, isPersistent: false, lockoutOnFailure: false);
            return response.Succeeded
                ? Ok(BuildToken(data))
                : BadRequest("Username or password incorrect");
        }

        #endregion

        #region OTHER METHODS

        private AuthenticationResponseModel BuildToken(SingInModel data)
        {
            // Información que se cifrará en el token
            var claims = new List<Claim>
            {
                  new Claim(type: "username", value: data.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _environment["JWT:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);
            var securityToken = new JwtSecurityToken(
                issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: credentials);

            return new AuthenticationResponseModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                ExpirationTime = expiration,
            };
        }

        #endregion
    }
}
