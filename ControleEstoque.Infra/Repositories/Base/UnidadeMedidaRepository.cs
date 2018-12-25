using ControleEstoque.Domain.Models.Base;
using ControleEstoque.Domain.Repositories.Base;
using ControleEstoque.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Infra.Repositories.Base
{
    public class UnidadeMedidaRepository : IUnidadeMedidaRepository
    {
        ControleEstoqueContext _context;

        public UnidadeMedidaRepository(ControleEstoqueContext context)
        {
            _context = context;
        }

        public UnidadeMedida GetById(Guid id)
        {
            return _context.UnidadesMedida.Where(x => x.Id == id).FirstOrDefault();
        }

        public UnidadeMedida GetByDescription(string descricao)
        {
            return _context.UnidadesMedida.Where(x => x.Descricao.ToLower() == descricao.ToLower()).FirstOrDefault();
        }

        public List<UnidadeMedida> GetAll()
        {
            return _context.UnidadesMedida.ToList();
        }
        
        public void Create(UnidadeMedida unidade)
        {
            _context.UnidadesMedida.Add(unidade);
            _context.SaveChanges();
        }

        public void Update(UnidadeMedida unidade)
        {
            _context.Entry<UnidadeMedida>(unidade).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(UnidadeMedida unidade)
        {
            _context.UnidadesMedida.Remove(unidade);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
