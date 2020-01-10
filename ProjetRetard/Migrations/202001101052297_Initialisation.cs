namespace ProjetRetard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BilletRetard",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Motif = c.String(nullable: false, maxLength: 255),
                        Justificatif = c.String(),
                        DateHeure = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        Utilisateur_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Utilisateur", t => t.Utilisateur_ID)
                .Index(t => t.Utilisateur_ID);
            
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 50),
                        Prenom = c.String(nullable: false, maxLength: 50),
                        Classe = c.String(nullable: false, maxLength: 20),
                        AdresseMail = c.String(nullable: false, maxLength: 50),
                        MotDePasse = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BilletRetard", "Utilisateur_ID", "dbo.Utilisateur");
            DropIndex("dbo.BilletRetard", new[] { "Utilisateur_ID" });
            DropTable("dbo.Utilisateur");
            DropTable("dbo.BilletRetard");
        }
    }
}
