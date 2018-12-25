using ControleEstoque.Common.Resources;
using ControleEstoque.Common.Validation;
using ControleEstoque.Domain.Models;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.Service;
using System;

namespace ControleEstoque.App
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario Authenticate(string email, string senha)
        {
            var usuario = GetByEmail(email);

            if (usuario.Senha != PasswordAssertionConcern.Encrypt(senha))
            {
                throw new System.Exception(Errors.InvalidCredentials);
            }

            return usuario;
        }

        public void ChangeInformation(string email, string nome)
        {
            var usuario = GetByEmail(email);

            usuario.AlterarNome(nome);
            usuario.Validate();

            _repository.Update(usuario);
        }

        public void ChangeSenha(string email, string senha, string novaSenha, string confirmacaoSenha)
        {
            var usuario = Authenticate(email, senha);

            usuario.SetSenha(novaSenha, confirmacaoSenha);
            usuario.Validate();

            _repository.Update(usuario);
        }        

        public Usuario GetByEmail(string email)
        {
            var usuario = _repository.Get(email);
            if (usuario == null)
                throw new Exception(Errors.UserNotFound);

            return usuario;
        }

        public void Register(string nome, string email, string senha, string confirmacaoSenha)
        {
            var hasUsuario = _repository.Get(email);
            if (hasUsuario != null)
                throw new Exception(Errors.DuplicateEmail);

            var usuario = new Usuario(nome, email);
            usuario.SetSenha(senha, confirmacaoSenha);
            usuario.Validate();

            _repository.Create(usuario);
        }

        public string ReseteSenha(string email)
        {
            var usuario = GetByEmail(email);
            var senha = usuario.ResetSenha();
            usuario.Validate();

            _repository.Update(usuario);
            return senha;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
