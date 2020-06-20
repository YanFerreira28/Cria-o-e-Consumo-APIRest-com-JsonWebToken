namespace SISControlAPI.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class apiControl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 50),
                    Sobrenome = c.String(nullable: false, maxLength: 50),
                    Rua = c.String(nullable: false, maxLength: 50),
                    Bairro = c.String(nullable: false, maxLength: 50),
                    Cidade = c.String(nullable: false, maxLength: 50),
                    Estado = c.String(nullable: false, maxLength: 20),
                    Numero = c.String(nullable: false, maxLength: 6),
                    Produto_id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Produto", t => t.Produto_id)
                .Index(t => t.Produto_id);

            CreateTable(
                "dbo.Produto",
                c => new
                {
                    id = c.String(nullable: false, maxLength: 128),
                    Nome = c.String(nullable: false, maxLength: 50),
                    Fornecedor = c.String(nullable: false, maxLength: 60),
                    Marca = c.String(nullable: false, maxLength: 40),
                    Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.Usuario",
                c => new
                {
                    id = c.Int(nullable: false, identity: true),
                    Nome = c.String(nullable: false, maxLength: 50),
                    Email = c.String(nullable: false),
                    Senha = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Cliente", "produto_id", "dbo.Produto");
            DropForeignKey("dbo.Cliente", "Produto_id", "dbo.Produto");
            DropIndex("dbo.Cliente", new[] { "produto_id" });
            DropIndex("dbo.Cliente", new[] { "Produto_id" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Cliente");
        }
    }
}
