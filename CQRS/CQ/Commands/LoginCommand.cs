using DTO;
using MediatR;

namespace CQRS.CQ.Commands
{
    public class LoginCommand : IRequest<string?>
    {
        public WebShopUserDTO LoginModel { get; set; }

        public LoginCommand(WebShopUserDTO loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
