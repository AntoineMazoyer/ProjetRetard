/*    ==Paramètres de script==

    Version du serveur source : SQL Server 2016 (13.0.1601)
    Édition du moteur de base de données source : Microsoft SQL Server Enterprise Edition
    Type du moteur de base de données source : SQL Server autonome

    Version du serveur cible : SQL Server 2017
    Édition du moteur de base de données cible : Microsoft SQL Server Standard Edition
    Type du moteur de base de données cible : SQL Server autonome
*/
USE [ProjetRetard]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 27/02/2020 00:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BilletRetard]    Script Date: 27/02/2020 00:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BilletRetard](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Motif] [nvarchar](255) NOT NULL,
	[Justificatif] [nvarchar](max) NULL,
	[DateHeure] [datetime] NOT NULL,
	[Score] [int] NOT NULL,
	[Utilisateur_ID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.BilletRetard] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 27/02/2020 00:31:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nom] [nvarchar](50) NOT NULL,
	[Prenom] [nvarchar](50) NOT NULL,
	[Classe] [nvarchar](20) NOT NULL,
	[AdresseMail] [nvarchar](50) NOT NULL,
	[MotDePasse] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Utilisateur] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BilletRetard]  WITH CHECK ADD  CONSTRAINT [FK_dbo.BilletRetard_dbo.Utilisateur_Utilisateur_ID] FOREIGN KEY([Utilisateur_ID])
REFERENCES [dbo].[Utilisateur] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BilletRetard] CHECK CONSTRAINT [FK_dbo.BilletRetard_dbo.Utilisateur_Utilisateur_ID]
GO
