using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult GenerateToken()
        {
            return Ok(new CreateToken().TokenCreate());
        }
        [HttpGet("[action]")]
        public IActionResult GenerateAuthorizeToken()
        {
            return Ok(new CreateToken().TokenCreateAuthorize());
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("[action]")]
        public IActionResult TestToken()
        {
            return Ok("Hoşgeldiniz");
        }
        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin,Visitor")] //Burada rol belirtiyoruz.
        [HttpGet("[action]")]
        public IActionResult TestTokenByAuthentication()
        {
            return Ok("Hoşgeldiniz");
        }

    }
}
