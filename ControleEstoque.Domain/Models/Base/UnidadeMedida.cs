using ControleEstoque.Common.Validation;
using System;

namespace ControleEstoque.Domain.Models.Base
{
    public class UnidadeMedida
    {
        #region Constructor
        protected UnidadeMedida() { }
        public UnidadeMedida(string descricao, string unidade)
        {
            this.Id = Guid.NewGuid();
            this.Descricao = descricao;
            this.Unidade = unidade;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public string Unidade { get; private set; }
        #endregion

        public void Validate()
        {            
            AssertionConcern.AssertArgumentLength(this.Descricao, 3, 40, "A Descricão deve ter no mínimo 3 e no máximo 40 caracteres");
            AssertionConcern.AssertArgumentNotNull(this.Unidade, "Unidade não pode ser nula");
            AssertionConcern.AssertArgumentLength(this.Unidade, 3, "Unidade permite apenas 2 caracteres");
        }
    }
}
