using ControleEstoque.Api.Helpers;
using ControleEstoque.Api.Security;
using ControleEstoque.Domain.Service;
using ControleEstoque.Startup;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Web.Http;
using Unity;

namespace ControleEstoque.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configure Dependency Injection
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);

            ConfigureWebApi(config);
            ConfigureOAuth(app, container.Resolve<IUsuarioService>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Remove XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            // Modifica a identacao
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica a serialização
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            // Web Api routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public void ConfigureOAuth(IAppBuilder app, IUsuarioService service)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                // Permite chamadas HTTP inseguras ex: http:
                AllowInsecureHttp = true,
                // Caminho do Token
                TokenEndpointPath = new PathString("/api/security/token"),
                // Token expira em 2 horas
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                // Provider que faz a Authorização
                Provider = new AuthorizationServerProvider(service)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            // Token com Bearer Authentication
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}