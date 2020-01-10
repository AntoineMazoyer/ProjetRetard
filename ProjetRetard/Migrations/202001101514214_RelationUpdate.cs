namespace ProjetRetard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UtilisateurBilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropForeignKey("dbo.UtilisateurBilletRetard", "BilletRetard_ID", "dbo.BilletRetard");
            DropIndex("dbo.UtilisateurBilletRetard", new[] { "Utilisateur_ID" });
            DropIndex("dbo.UtilisateurBilletRetard", new[] { "BilletRetard_ID" });
            AddColumn("dbo.BilletRetard", "Utilisateur_ID", c => c.Int());
            AddColumn("dbo.BilletRetard", "Utilisateur_ID1", c => c.Int());
            AddColumn("dbo.Utilisateur", "BilletRetard_ID", c => c.Int());
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID");
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID1");
            CreateIndex("dbo.Utilisateur", "BilletRetard_ID");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur", "ID");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur", "ID");
            AddForeignKey("dbo.Utilisateur", "BilletRetard_ID", "dbo.BilletRetard", "ID");
            DropTable("dbo.UtilisateurBilletRetard");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UtilisateurBilletRetard",
                c => new
                    {
                        Utilisateur_ID = c.Int(nullable: false),
                        BilletRetard_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Utilisateur_ID, t.BilletRetard_ID });
            
            DropForeignKey("dbo.Utilisateur", "BilletRetard_ID", "dbo.BilletRetard");
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID1", "dbo.Utilisateur");
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropIndex("dbo.Utilisateur", new[] { "BilletRetard_ID" });
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID1" });
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID" });
            DropColumn("dbo.Utilisateur", "BilletRetard_ID");
            DropColumn("dbo.BilletRetard", "Utilisateur_ID1");
            DropColumn("dbo.BilletRetard", "Utilisateur_ID");
            CreateIndex("dbo.UtilisateurBilletRetard", "BilletRetard_ID");
            CreateIndex("dbo.UtilisateurBilletRetard", "Utilisateur_ID");
            AddForeignKey("dbo.UtilisateurBilletRetard", "BilletRetard_ID", "dbo.BilletRetard", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UtilisateurBilletRetard", "Utilisateur_ID", "dbo.Utilisateur", "ID", cascadeDelete: true);
        }
    }
}
