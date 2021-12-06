using Domain;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Identity;

namespace CQRS.PipelinBehaviors
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly SignInManager<WebShopUser> _userManager;

        public RequestLogger(ILogger<TRequest> logger, SignInManager<WebShopUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Northwind Request: {Name} {@UserId} {@Request}",
                name, _userManager.ToString, request);

            return Task.CompletedTask;
        }
    }
}
