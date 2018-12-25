using ControleEstoque.Domain.Models;
using System;


namespace ControleEstoque.Domain.Service
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Authenticate(string email, string senha);
        Usuario GetByEmail(string email);
        void Register(string nome, string email, string senha, string confirmacaoSenha);
        void ChangeInformation(string email, string nome);
        void ChangeSenha(string email, string senha, string novaSenha, string confirmacaoSenha);
        string ReseteSenha(string email);

    }
}
