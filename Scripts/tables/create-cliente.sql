USE [provacandidato]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 29/01/2022 19:42:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Codigo]            [int]           IDENTITY(1,1) NOT NULL,
	[Nome]              [varchar](50)   NOT NULL,
	[DataNascimento]    [smalldatetime] NULL,
	[CidadeId]          [int]           NOT NULL,
	[Ativo]             [bit]           NOT NULL,

    CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED ([Codigo] ASC),

	CONSTRAINT [FK_Cliente_Cidade] FOREIGN KEY([Codigo]) REFERENCES [dbo].[Cidade] ([Codigo])
)
GO
