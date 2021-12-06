using CQRS.CQ.Commands;
using Domain;
using DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        
        private IMediator _mediator;

        public AccountController(UserManager<WebShopUser> userManager, IConfiguration configuration, SignInManager<WebShopUser> sign, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] WebShopUserDTO dto)
        {
            var query = new RegisterCommand(dto);
            var result = await _mediator.Send(query);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost, Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] WebShopUserDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            var query = new LoginCommand(user);
            var result = await _mediator.Send(query);
            
            if (result != null)
            {
                return Ok(new { Token = result });
            }
            
            return Unauthorized();
        }
       
    }

}
