USE [herois_db]
GO
/****** Object:  Table [dbo].[Herois]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Herois](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[NomeHeroi] [nvarchar](450) NOT NULL,
	[DataNascimento] [datetime2](7) NULL,
	[Altura] [real] NOT NULL,
	[Peso] [real] NOT NULL,
 CONSTRAINT [PK_Herois] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HeroisSuperpoderes]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeroisSuperpoderes](
	[HeroiId] [int] NOT NULL,
	[SuperpoderId] [int] NOT NULL,
 CONSTRAINT [PK_HeroisSuperpoderes] PRIMARY KEY CLUSTERED 
(
	[HeroiId] ASC,
	[SuperpoderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Superpoderes]    Script Date: 29/07/2025 18:02:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Superpoderes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Superpoder] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
 CONSTRAINT [PK_Superpoderes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[HeroisSuperpoderes]  WITH CHECK ADD  CONSTRAINT [FK_HeroisSuperpoderes_Herois_HeroiId] FOREIGN KEY([HeroiId])
REFERENCES [dbo].[Herois] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroisSuperpoderes] CHECK CONSTRAINT [FK_HeroisSuperpoderes_Herois_HeroiId]
GO
ALTER TABLE [dbo].[HeroisSuperpoderes]  WITH CHECK ADD  CONSTRAINT [FK_HeroisSuperpoderes_Superpoderes_SuperpoderId] FOREIGN KEY([SuperpoderId])
REFERENCES [dbo].[Superpoderes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HeroisSuperpoderes] CHECK CONSTRAINT [FK_HeroisSuperpoderes_Superpoderes_SuperpoderId]
GO
