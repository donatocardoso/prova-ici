USE [provacandidato]
GO

/****** Object:  Table [dbo].[Cidade]    Script Date: 29/01/2022 19:37:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cidade](
	[Codigo]    [int]          IDENTITY(1,1) NOT NULL,
	[Nome]      [varchar](50)  NOT NULL,

    CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED ([Codigo] ASC)
)
GO
