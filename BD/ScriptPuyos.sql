USE [BDPuyos]
GO
/****** Object:  Table [dbo].[Calefactor]    Script Date: 1/6/2024 12:01:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calefactor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Calorias] [int] NULL,
	[Modelo] [nvarchar](50) NULL,
	[Cantidad] [int] NULL,
	[Estado] [nvarchar](50) NULL,
	[Precio] [float] NULL,
	[Eficiencia] [nvarchar](50) NULL,
	[TiroBalanceado] [nvarchar](50) NULL,
	[CodProveedor] [int] NULL,
 CONSTRAINT [PK_Calefactor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 1/6/2024 12:01:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Dni] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente_Calefactor]    Script Date: 1/6/2024 12:01:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente_Calefactor](
	[CodCli] [int] NOT NULL,
	[CodCal] [int] NOT NULL,
	[Estado] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 1/6/2024 12:01:48 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](50) NULL,
	[Cuit] [int] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Calefactor]  WITH CHECK ADD  CONSTRAINT [FK_Calefactor_Proveedor] FOREIGN KEY([CodProveedor])
REFERENCES [dbo].[Proveedor] ([Codigo])
GO
ALTER TABLE [dbo].[Calefactor] CHECK CONSTRAINT [FK_Calefactor_Proveedor]
GO
ALTER TABLE [dbo].[Cliente_Calefactor]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Calefactor_Calefactor] FOREIGN KEY([CodCal])
REFERENCES [dbo].[Calefactor] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente_Calefactor] CHECK CONSTRAINT [FK_Cliente_Calefactor_Calefactor]
GO
ALTER TABLE [dbo].[Cliente_Calefactor]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Calefactor_Cliente] FOREIGN KEY([CodCli])
REFERENCES [dbo].[Cliente] ([Codigo])
GO
ALTER TABLE [dbo].[Cliente_Calefactor] CHECK CONSTRAINT [FK_Cliente_Calefactor_Cliente]
GO
