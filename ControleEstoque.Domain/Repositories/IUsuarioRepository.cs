
using ControleEstoque.Domain.Models;
using System;

namespace ControleEstoque.Domain.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario Get(string email);
        Usuario Get(Guid id);
        void Create(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
