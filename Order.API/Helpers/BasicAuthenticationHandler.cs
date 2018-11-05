using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.Domain.Costumers;
using Order.Services.CostumerServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Order.API.Helpers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly ICostumerService _costumerService;
        private readonly ILogger<BasicAuthenticationHandler> _logger;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            ILogger<BasicAuthenticationHandler> nlogger,
            ICostumerService costumerService)
            : base(options, logger, encoder, clock)
        {
            _costumerService = costumerService;
            _logger = nlogger;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                _logger.LogError(Guid.NewGuid() + " Missing Authorization Header");

                return AuthenticateResult.Fail(Guid.NewGuid() + " Missing Authorization Header");
            }

            Costumer costumer = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                costumer = await _costumerService.Authenticate(username, password);
            }
            catch
            {
                _logger.LogError(Guid.NewGuid() + " Invalid Authorization Header");
                return AuthenticateResult.Fail(Guid.NewGuid() + " Invalid Authorization Header");
            }

            if (costumer == null)
            {
                _logger.LogError(Guid.NewGuid() + " Invalid Username or Password");

                return AuthenticateResult.Fail(Guid.NewGuid() + " Invalid Username or Password");
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, costumer.Id.ToString()),
                new Claim(ClaimTypes.Name, costumer.Email),
                new Claim(ClaimTypes.Role, costumer.Role.ToString())
            };


            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }


    }
}
