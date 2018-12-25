namespace ControleEstoque.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarUnidadeMedida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UNIDADEMEDIDA",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 40),
                        Unidade = c.String(maxLength: 3),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UNIDADEMEDIDA");
        }
    }
}
