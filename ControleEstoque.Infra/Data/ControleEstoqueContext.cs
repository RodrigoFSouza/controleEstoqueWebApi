using ControleEstoque.Domain.Models;
using ControleEstoque.Domain.Models.Base;
using ControleEstoque.Infra.Data.Map;
using ControleEstoque.Infra.Data.Map.Base;
using System.Data.Entity;

namespace ControleEstoque.Infra.Data
{
    public class ControleEstoqueContext : DbContext
    {
        public ControleEstoqueContext() : base("ControleEstoqueContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UnidadeMedida> UnidadesMedida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UnidadeMedidaMap());
        }
    }
}
