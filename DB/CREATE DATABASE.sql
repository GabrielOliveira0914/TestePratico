CREATE DATABASE MinhaAgendaMinhaVida
GO

USE [MinhaAgendaMinhaVida]
GO

/****** Object:  Table [dbo].[Agenda]    Script Date: 15/12/2021 14:34:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Agenda](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](50) NULL,
	[Descricao] [varchar](220) NULL,
	[DataInicio] [date] NULL,
	[DataTermino] [date] NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

