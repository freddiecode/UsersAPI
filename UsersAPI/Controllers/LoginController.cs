using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersAPI.Models;

namespace UsersAPI.Controllers
{

    public class TokenRequest
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }

    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST <LoginController>
        [HttpPost]
        public dynamic Post([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.Email, tokenRequest.Password);
            return new { Token = token };

        }

        // GET <LoginController>
        [HttpGet]
        public dynamic Get(string Email, string Password)
        {
            var token = TokenHelper.GetToken(Email, Password);
            return new { Token = token };
        }
    }
}
