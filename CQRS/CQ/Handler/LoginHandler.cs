using CQRS.CQ.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CQRS.CQ.Handler
{
    public class LoginHandler : IRequestHandler<LoginCommand, string?>
    {

        private SignInManager<WebShopUser> _signInManager;
        private UserManager<WebShopUser> _userManager;
        private IConfiguration _config;


        public LoginHandler(SignInManager<WebShopUser> signInManager,UserManager<WebShopUser> userManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = configuration;
        }

       
        
        public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

            var loginResult = await _signInManager.PasswordSignInAsync(request.LoginModel.UserName, request.LoginModel.Password, true, false); ;
            if (loginResult.Succeeded)
            {
                var applicationUser = _signInManager.UserManager.FindByNameAsync(request.LoginModel.UserName).GetAwaiter().GetResult();
                var claims = await _signInManager.UserManager.GetClaimsAsync(applicationUser);

                //_logger.LogInformation($"User '{user.UserName}' logged in.");

                var tokenString = GenerateJSONWebToken(claims);

                return tokenString;
            }
            else return null;

        }

        private string GenerateJSONWebToken(IEnumerable<Claim> claims)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var signinCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:5001",
                audience: "http://localhost:5001",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var token = tokenHandler.WriteToken(tokeOptions);

            return token;
        }
    }
}
