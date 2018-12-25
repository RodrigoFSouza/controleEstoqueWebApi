using ControleEstoque.Api.Models;
using ControleEstoque.Domain.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ControleEstoque.Api.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private IUsuarioService _service;

        public AccountController(IUsuarioService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpPost]
        public Task<HttpResponseMessage> Register(RegisterUserModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.Register(model.Nome, model.Email, model.Senha, model.ConfirmacaoSenha);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome, email = model.Email });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPut]
        [Route("")]
        [Authorize]
        public Task<HttpResponseMessage> Put(ChangeInformationModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeInformation(User.Identity.Name, model.Nome);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = model.Nome });

            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("changePassword")]
        public Task<HttpResponseMessage> ChangePassword(ChangePasswordModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                _service.ChangeSenha(User.Identity.Name, model.Senha, model.NovaSenha, model.ConfirmacaoSenha);
                response = Request.CreateResponse(HttpStatusCode.OK, new { name = User.Identity.Name });
            } 
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        [HttpPost]
        [Route("resetPassword")]
        public Task<HttpResponseMessage> ResetPassword(ResetPasswordModel model)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            
            try
            {
                var password = _service.ReseteSenha(model.Email);
                response = Request.CreateResponse(HttpStatusCode.OK, new { password });
            }
            catch (Exception ex)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            return tsc.Task;
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
        }

    }
}
