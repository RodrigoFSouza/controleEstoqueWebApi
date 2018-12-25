namespace ControleEstoque.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoTabelaUsuario : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Usuarios", newName: "USUARIO");
            DropPrimaryKey("dbo.USUARIO");
            AlterColumn("dbo.USUARIO", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.USUARIO", "Nome", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.USUARIO", "Email", c => c.String(nullable: false, maxLength: 160));
            AlterColumn("dbo.USUARIO", "Senha", c => c.String(maxLength: 32, fixedLength: true));
            AddPrimaryKey("dbo.USUARIO", "Id");
            CreateIndex("dbo.USUARIO", "Email", unique: true, name: "IX_EMAIL");
        }
        
        public override void Down()
        {
            DropIndex("dbo.USUARIO", "IX_EMAIL");
            DropPrimaryKey("dbo.USUARIO");
            AlterColumn("dbo.USUARIO", "Senha", c => c.String());
            AlterColumn("dbo.USUARIO", "Email", c => c.String());
            AlterColumn("dbo.USUARIO", "Nome", c => c.String());
            AlterColumn("dbo.USUARIO", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.USUARIO", "Id");
            RenameTable(name: "dbo.USUARIO", newName: "Usuarios");
        }
    }
}
