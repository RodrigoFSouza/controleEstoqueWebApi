using ControleEstoque.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ControleEstoque.Infra.Data.Map.Base
{
    public class UnidadeMedidaMap : EntityTypeConfiguration<UnidadeMedida>        
    {
        public UnidadeMedidaMap()
        {
            ToTable("UNIDADEMEDIDA");

            HasKey(x => x.Id);
            Property(x => x.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



            Property(x => x.Descricao)
                .HasMaxLength(40);

            Property(x => x.Unidade)
                .HasMaxLength(3);
        }
    }
}
