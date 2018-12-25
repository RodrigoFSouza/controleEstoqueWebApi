
using ControleEstoque.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Repositories.Base
{
    public interface IUnidadeMedidaRepository : IDisposable
    {
        UnidadeMedida GetById(Guid id);
        UnidadeMedida GetByDescription(string descricao);
        List<UnidadeMedida> GetAll();
        void Create(UnidadeMedida unidade);
        void Update(UnidadeMedida unidade);
        void Delete(UnidadeMedida unidade);
    }
}
