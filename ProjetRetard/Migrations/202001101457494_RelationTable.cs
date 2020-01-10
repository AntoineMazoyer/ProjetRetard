namespace ProjetRetard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID" });
            CreateTable(
                "dbo.UtilisateurBilletRetard",
                c => new
                    {
                        Utilisateur_ID = c.Int(nullable: false),
                        BilletRetard_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Utilisateur_ID, t.BilletRetard_ID })
                .ForeignKey("dbo.Utilisateur", t => t.Utilisateur_ID, cascadeDelete: true)
                .ForeignKey("dbo.BilletRetard", t => t.BilletRetard_ID, cascadeDelete: true)
                .Index(t => t.Utilisateur_ID)
                .Index(t => t.BilletRetard_ID);
            
            DropColumn("dbo.BilletRetard", "Utilisateur_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BilletRetard", "Utilisateur_ID", c => c.Int());
            DropForeignKey("dbo.UtilisateurBilletRetard", "BilletRetard_ID", "dbo.BilletRetard");
            DropForeignKey("dbo.UtilisateurBilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropIndex("dbo.UtilisateurBilletRetard", new[] { "BilletRetard_ID" });
            DropIndex("dbo.UtilisateurBilletRetard", new[] { "Utilisateur_ID" });
            DropTable("dbo.UtilisateurBilletRetard");
            CreateIndex("dbo.BilletRetard", "Utilisateur_ID");
            AddForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur", "ID");
        }
    }
}
