using System.Web.Http;

namespace ControleEstoque.Api.Controllers
{
    public class TesteController : ApiController
    {
        [Authorize]
        public string Get()
        {
            return "teste";
        }
    }
}
