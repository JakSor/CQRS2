using DTO;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CQRS.CQ.Commands
{
    public class RegisterCommand: IRequest<IdentityResult>
    {
        public WebShopUserDTO LoginModel { get; set; }

        public RegisterCommand(WebShopUserDTO loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
