using CQRS.CQ.Commands;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CQRS.CQ.Handler
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, IdentityResult>
    {
        private UserManager<WebShopUser> _userManager;

        public RegisterHandler(UserManager<WebShopUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = new WebShopUser { PasswordHash = request.LoginModel.Password, UserName = request.LoginModel.UserName };
            var result = await _userManager.CreateAsync(user, request.LoginModel.Password);
           
            return result;            
        }
    }
}
