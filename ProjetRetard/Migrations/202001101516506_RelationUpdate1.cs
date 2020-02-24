namespace ProjetRetard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur");
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID1" });
            AlterColumn("dbo.BilletRetard", "Utilisateur_ID1", c => c.Int(nullable: false));
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID1");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur");
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID1" });
            AlterColumn("dbo.BilletRetard", "Utilisateur_ID1", c => c.Int());
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID1");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur", "ID");
        }
    }
}
