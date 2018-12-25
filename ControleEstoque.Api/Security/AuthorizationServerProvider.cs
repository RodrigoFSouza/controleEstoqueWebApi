using ControleEstoque.Common.Resources;
using ControleEstoque.Domain.Service;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ControleEstoque.Api.Security
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IUsuarioService _service;

        public AuthorizationServerProvider(IUsuarioService service)
        {
            _service = service;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            // Habilita o cors
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                var usuario = _service.Authenticate(context.UserName, context.Password);

                if (usuario == null)
                {
                    context.SetError("invalid_grant", Errors.InvalidCredentials);
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                // Este é o mais importante
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, usuario.Nome));

                // Seta a thread atual quem está autenticado
                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", Errors.InvalidCredentials);
            }
        }
    }
}