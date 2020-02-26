namespace ProjetRetard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BDDpropre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropForeignKey("dbo.Utilisateur", "BilletRetard_ID", "dbo.BilletRetard");
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID" });
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID1" });
            DropIndex("dbo.Utilisateur", new[] { "BilletRetard_ID" });
            DropColumn("dbo.BilletRetard", "Utilisateur_ID");
            RenameColumn(table: "dbo.BilletRetard", name: "Utilisateur_ID1", newName: "Utilisateur_ID");
            AlterColumn("dbo.BilletRetard", "Utilisateur_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID");
            DropColumn("dbo.Utilisateur", "BilletRetard_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilisateur", "BilletRetard_ID", c => c.Int());
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID" });
            AlterColumn("dbo.BilletRetard", "Utilisateur_ID", c => c.Int());
            RenameColumn(table: "dbo.BilletRetard", name: "Utilisateur_ID", newName: "Utilisateur_ID1");
            AddColumn("dbo.BilletRetard", "Utilisateur_ID", c => c.Int());
            CreateIndex("dbo.Utilisateur", "BilletRetard_ID");
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID1");
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID");
            AddForeignKey("dbo.Utilisateur", "BilletRetard_ID", "dbo.BilletRetard", "ID");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur", "ID");
        }
    }
}
