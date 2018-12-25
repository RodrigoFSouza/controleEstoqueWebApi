using ControleEstoque.Common.Resources;
using ControleEstoque.Common.Validation;
using System;

namespace ControleEstoque.Domain.Models
{
    public class Usuario
    {
        #region Properties
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        #endregion

        #region Constructor
        protected Usuario() { }

        public Usuario(string nome, string email)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Email = email;
        }
        #endregion

        #region Methods
        public void SetSenha(string senha, string confirmacaoSenha)
        {
            AssertionConcern.AssertArgumentNotNull(senha, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentNotNull(confirmacaoSenha, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentLength(senha, 6, 20, Errors.InvalidUserPassword);
            AssertionConcern.AssertArgumentEquals(senha, confirmacaoSenha, Errors.PasswordDoesNotMatch);

            this.Senha = PasswordAssertionConcern.Encrypt(senha);
        }

        public string ResetSenha()
        {
            string senha = Guid.NewGuid().ToString().Substring(0, 8);
            this.Senha = PasswordAssertionConcern.Encrypt(senha);

            return senha;
        }

        public void AlterarNome(string nome)
        {
            this.Nome = nome;
        }

        public void Validate()
        {
            AssertionConcern.AssertArgumentLength(this.Nome, 3, 250, Errors.InvalidUserName);
            EmailAssertionConcern.AssertIsValid(this.Email);
            PasswordAssertionConcern.AssertIsValid(this.Senha);
        }
#endregion
    }
}
