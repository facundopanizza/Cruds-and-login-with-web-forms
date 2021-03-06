CREATE DATABASE project;
GO
USE [project]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 8/12/2020 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 8/12/2020 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 8/12/2020 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Price] [money] NOT NULL,
	[IsAvailable] [bit] NOT NULL,
	[BrandId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/12/2020 18:11:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name]) VALUES (2, N'AMD')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (3, N'NVIDIA')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (7, N'Bethesda')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (8, N'Sony')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (9, N'Samsung')
INSERT [dbo].[Brand] ([Id], [Name]) VALUES (10, N'Intel')
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Monitor')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Games')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Processors')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'GPU')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Motherboard')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (15, N'Ryzen 7 4900', 70000.7000, 1, 2, 5)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (16, N'Monitor Curve', 150000.3000, 1, 9, 5)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (17, N'2080 RTX', 95000.0000, 0, 3, 9)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (18, N'Monitor 4K', 100000.0000, 0, 9, 5)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (19, N'Skyrim', 5000.0000, 0, 7, 6)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (20, N'TV 50"', 200000.0000, 0, 8, 5)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (21, N'5500xt', 60000.0000, 0, 2, 9)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (22, N'Fallout 4', 3000.0000, 0, 7, 6)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (23, N'I9 9900k', 85000.1000, 1, 10, 8)
INSERT [dbo].[Product] ([Id], [Name], [Price], [IsAvailable], [BrandId], [CategoryId]) VALUES (24, N'i3 10300K', 30000.0000, 0, 10, 8)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password], [IsAdmin]) VALUES (1, N'facundo', N'123456', 1)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsAdmin]) VALUES (2, N'guest', N'123456', 0)
INSERT [dbo].[Users] ([Id], [Username], [Password], [IsAdmin]) VALUES (3, N'carlos', N'123456', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Product] ADD  CONSTRAINT [DF_Product_IsAvailable]  DEFAULT ((0)) FOR [IsAvailable]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
