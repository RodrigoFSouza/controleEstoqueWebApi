
namespace ControleEstoque.Api.Models
{
    public class ChangePasswordModel
    {
        public string Senha { get; set; }
        public string ConfirmacaoSenha { get; set; }
        public string NovaSenha { get; set; }
    }
}