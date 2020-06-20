namespace SISControlAPI.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class apiControliti : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cliente", "Produto_id", "dbo.Produto");
            DropIndex("dbo.Cliente", new[] { "Produto_id" });
            DropIndex("dbo.Cliente", new[] { "produto_id" });
            AlterColumn("dbo.Cliente", "produto_id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Cliente", "produto_id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "produto_id" });
            AlterColumn("dbo.Cliente", "produto_id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Cliente", "produto_id");
            CreateIndex("dbo.Cliente", "Produto_id");
            AddForeignKey("dbo.Cliente", "Produto_id", "dbo.Produto", "id");
        }
    }
}
