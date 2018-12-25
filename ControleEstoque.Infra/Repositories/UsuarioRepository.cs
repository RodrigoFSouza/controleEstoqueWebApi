
using System;
using System.Data.Entity;
using System.Linq;
using ControleEstoque.Domain.Models;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Infra.Data;

namespace ControleEstoque.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ControleEstoqueContext _context = new ControleEstoqueContext();

        public UsuarioRepository(ControleEstoqueContext context)
        {
            this._context = context;
        }

        public Usuario Get(Guid id)
        {
            return _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }

        public Usuario Get(string email)
        {
            return _context.Usuarios.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }

        public void Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }        

        public void Update(Usuario usuario)
        {
            _context.Entry<Usuario>(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
