USE [master]
GO
/****** Object:  Database [THECAVE]    Script Date: 27/11/2023 11:01:14 ******/
CREATE DATABASE [THECAVE]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'THECAVE', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\THECAVE.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'THECAVE_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\THECAVE_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [THECAVE] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [THECAVE].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [THECAVE] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [THECAVE] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [THECAVE] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [THECAVE] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [THECAVE] SET ARITHABORT OFF 
GO
ALTER DATABASE [THECAVE] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [THECAVE] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [THECAVE] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [THECAVE] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [THECAVE] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [THECAVE] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [THECAVE] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [THECAVE] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [THECAVE] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [THECAVE] SET  DISABLE_BROKER 
GO
ALTER DATABASE [THECAVE] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [THECAVE] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [THECAVE] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [THECAVE] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [THECAVE] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [THECAVE] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [THECAVE] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [THECAVE] SET RECOVERY FULL 
GO
ALTER DATABASE [THECAVE] SET  MULTI_USER 
GO
ALTER DATABASE [THECAVE] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [THECAVE] SET DB_CHAINING OFF 
GO
ALTER DATABASE [THECAVE] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [THECAVE] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [THECAVE] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [THECAVE] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'THECAVE', N'ON'
GO
ALTER DATABASE [THECAVE] SET QUERY_STORE = OFF
GO
USE [THECAVE]
GO
/****** Object:  Table [dbo].[Alquileres]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alquileres](
	[CodAlquiler] [int] IDENTITY(1,1) NOT NULL,
	[Estacion] [int] NULL,
	[Precio] [float] NULL,
	[Tiempo] [float] NULL,
	[Fecha] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Usuario] [char](64) NOT NULL,
	[Accion] [char](60) NOT NULL,
	[Hora] [datetime] NOT NULL,
	[Modulo] [char](64) NULL,
	[Criticidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Cod_Categoria] [int] NOT NULL,
	[Nombre] [char](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dvUsuarios]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dvUsuarios](
	[HashValue] [nvarchar](max) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_dvUsuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estaciones]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estaciones](
	[Nro] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [char](30) NULL,
	[Ocupacion] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[Cod_Perfil] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [char](20) NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[Cod_Perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerfilPermiso]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerfilPermiso](
	[Cod_Perfil] [int] NOT NULL,
	[Cod_Permiso] [int] NOT NULL,
	[a] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Perfil - PErmiso] PRIMARY KEY CLUSTERED 
(
	[a] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[Cod_Permiso] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [char](20) NULL,
 CONSTRAINT [PK_Permiso] PRIMARY KEY CLUSTERED 
(
	[Cod_Permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Cod_Producto] [int] NOT NULL,
	[Nombre] [char](100) NOT NULL,
	[Categoria] [int] NOT NULL,
	[Stock] [int] NULL,
	[Precio] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductosHistorico]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductosHistorico](
	[Cod_Producto] [int] NOT NULL,
	[Fecha] [datetime] NULL,
	[Stock] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaRebote]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaRebote](
	[COLUMNA] [nvarchar](max) NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TablaRebote_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Username] [char](64) NOT NULL,
	[Password] [char](64) NOT NULL,
	[Block] [int] NOT NULL,
	[DNI] [char](50) NULL,
	[Apellido] [char](50) NULL,
	[Nombre] [char](50) NULL,
	[Cod_Perfil] [int] NULL,
	[Activo] [int] NULL,
	[Idioma] [int] NULL,
 CONSTRAINT [PK__Usuarios__536C85E5728AFEC8] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 27/11/2023 11:01:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[Cod_Venta] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Precio] [int] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[Cod_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Alquileres] ON 

INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (1, 1, 1000, 10, CAST(N'2023-06-26T19:34:43.780' AS DateTime))
INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (2, 4, 0, 0, CAST(N'2023-08-06T16:10:42.597' AS DateTime))
INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (3, 5, 400, 4, CAST(N'2023-08-06T16:17:46.853' AS DateTime))
INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (4, 6, 1000, 10, CAST(N'2023-09-15T19:59:50.277' AS DateTime))
INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (5, 6, 100, 1, CAST(N'2023-11-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Alquileres] ([CodAlquiler], [Estacion], [Precio], [Tiempo], [Fecha]) VALUES (6, 1, 300, 3, CAST(N'2023-11-25T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Alquileres] OFF
GO
INSERT [dbo].[Bitacora] ([Usuario], [Accion], [Hora], [Modulo], [Criticidad]) VALUES (N'Admin                                                           ', N'Inicio de sesion                                            ', CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Usuario                                                         ', 0)
INSERT [dbo].[Bitacora] ([Usuario], [Accion], [Hora], [Modulo], [Criticidad]) VALUES (N'Admin                                                           ', N'Estacion deshabilitada                                      ', CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Negocio                                                         ', 1)
INSERT [dbo].[Bitacora] ([Usuario], [Accion], [Hora], [Modulo], [Criticidad]) VALUES (N'Admin                                                           ', N'Estacion NRO habilitada                                     ', CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Negocio                                                         ', 1)
INSERT [dbo].[Bitacora] ([Usuario], [Accion], [Hora], [Modulo], [Criticidad]) VALUES (N'Admin                                                           ', N'Alquiler cobrado                                            ', CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Negocio                                                         ', 0)
INSERT [dbo].[Bitacora] ([Usuario], [Accion], [Hora], [Modulo], [Criticidad]) VALUES (N'Admin                                                           ', N'compra cobrada                                              ', CAST(N'2023-11-25T00:00:00.000' AS DateTime), N'Negocio                                                         ', 1)
GO
INSERT [dbo].[Categorias] ([Cod_Categoria], [Nombre]) VALUES (0, N'Coleccionables                ')
INSERT [dbo].[Categorias] ([Cod_Categoria], [Nombre]) VALUES (1, N'Giftcards                     ')
INSERT [dbo].[Categorias] ([Cod_Categoria], [Nombre]) VALUES (2, N'Componentes                   ')
INSERT [dbo].[Categorias] ([Cod_Categoria], [Nombre]) VALUES (3, N'Consumibles                   ')
GO
SET IDENTITY_INSERT [dbo].[dvUsuarios] ON 

INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'20ae520c822b3f790926db37b43555692a833357148b1a06a309754476e8e300', 1)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'20228c349f45b4331357760ece0f3bd4a98b70de750edea8ff17cbe88ee017da', 2)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'2b2f2cb1c68e7ed87fff923e8bc9ff3e1a8e305580ee3e8e98b9864729c07cfd', 3)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'ff13b82d2b88392d41742890e10df7a64804e2abee7771618e810df89c4cedee', 4)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'17d847bfa5948b69c681d624262c5f8a2a8226b4cde5c78bb007f43a0b01af25', 5)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'0840d8b61ebf18b1fc5d6c0ad96eb9bc569e1ac41435b4db31237b2283643058', 6)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'a25a5191ce39ab44c6af8b762888dbdf3ad25359a44094be6b2c3da64146d72c', 7)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'b654e3b3d2f50a230aaf0956dcf467d73c30a917b752dc0db5d8b8c8a0ec03aa', 8)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'9d9f71cb6aa6dc18cd15146b66a2268cbbeaea6fe345bc09f13012c509ae215e', 9)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'b48a9b843ceb23897efdecea6b5f39ffdcf09250ed44da2e9eca302707312429', 10)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'75caaf04a78f41af8a25ab889b9c10b158a673b5d57193d43d2f0dd64e50d1b9', 11)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'8df7ebd5a4b1aa93181d109921e49f497598841423265211a46be2cc0757788f', 12)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'b18d5e3a5c3671cbffc173a46711f193074c1b4dfbc46fe083660b604c836036', 13)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'09a8bcb011e669e4dd0abb2307a404cce1c72a0ed2203f5e5acbf8f366a8a036', 14)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'47511e2e5ed4ee033203f8a0d98815228687d1f81bc890f99dfc0644ba55c27c', 15)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'96e76f59c66f144c5b204adedb8f336d7ae2ca7b94a180527c441188c40dc675', 16)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'fd1899160d21eb3b5cc21db759ffa68b2179ee43a31a0cb2e257c5254ae92bc5', 17)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'458c9103119a8f32b69c8addbd603e270696044498d3c21f772de5b6500d7fea', 18)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'2de1d8baa2bf218df60f2898d55fb331eb09b16b5f2958778c19a0e8ade2b16f', 19)
INSERT [dbo].[dvUsuarios] ([HashValue], [Id]) VALUES (N'994f1b042b4901c403f8e95b262b87426da37821b9a23450e5682c44a4fe1a90', 20)
SET IDENTITY_INSERT [dbo].[dvUsuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Estaciones] ON 

INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (1, N'PC-VR                         ', 1)
INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (2, N'Consola                       ', 1)
INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (3, N'XBOX                          ', 1)
INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (4, N'PC-Estandar                   ', 1)
INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (5, N'PC-NG                         ', 1)
INSERT [dbo].[Estaciones] ([Nro], [Tipo], [Ocupacion]) VALUES (6, N'PC-Streamer                   ', 1)
SET IDENTITY_INSERT [dbo].[Estaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfiles] ON 

INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (1, N'Admin               ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (2, N'Encargado           ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (6, N'Vendedor            ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (7, N'aaaaaaaa            ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (8, N'aa                  ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (9, N'a                   ')
INSERT [dbo].[Perfiles] ([Cod_Perfil], [Nombre]) VALUES (10, N'dsf                 ')
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[PerfilPermiso] ON 

INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (1, 1, 1)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (1, 2, 2)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (1, 3, 3)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (2, 2, 4)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (10, 1, 6)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (10, 2, 7)
INSERT [dbo].[PerfilPermiso] ([Cod_Perfil], [Cod_Permiso], [a]) VALUES (10, 2, 8)
SET IDENTITY_INSERT [dbo].[PerfilPermiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([Cod_Permiso], [Descripcion]) VALUES (1, N'Administracion      ')
INSERT [dbo].[Permiso] ([Cod_Permiso], [Descripcion]) VALUES (2, N'Alquileres          ')
INSERT [dbo].[Permiso] ([Cod_Permiso], [Descripcion]) VALUES (3, N'Ventas              ')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
GO
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (0, N'Figura Link The Legend Of Zelda                                                                     ', 0, 0, 10000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (1, N'Figura Sideshow Arthur Morgan Red Dead Redemption 2                                                 ', 0, 0, 10000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (2, N'Funko Pop Doomslayer DOOM Eterrnal                                                                  ', 0, 3, 10000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (3, N'Figura Black Series Ahsoka Tano Star Wars The Clone Wars                                            ', 0, 1, 10000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (4, N'Figura Luffy One Piece                                                                              ', 0, 0, 10000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (5, N'Giftcard PSN                                                                                        ', 1, 8, 50)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (6, N'Giftcard XBOX                                                                                       ', 1, 9, 50)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (7, N'Giftcard Steam                                                                                      ', 1, 10, 50)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (8, N'GPU                                                                                                 ', 2, 0, 150000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (9, N'CPU                                                                                                 ', 2, 6, 100000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (10, N'SSD                                                                                                 ', 2, 10, 15000)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (11, N'Coca Cola                                                                                           ', 3, 18, 500)
INSERT [dbo].[Productos] ([Cod_Producto], [Nombre], [Categoria], [Stock], [Precio]) VALUES (12, N'Snacks                                                                                              ', 3, 15, 300)
GO
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (6, CAST(N'2023-10-29T19:09:32.737' AS DateTime), 9)
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (11, CAST(N'2023-10-29T19:09:32.737' AS DateTime), 18)
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (0, CAST(N'2023-10-29T19:10:35.090' AS DateTime), 2)
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (0, CAST(N'2023-11-24T20:26:52.217' AS DateTime), 2)
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (8, CAST(N'2023-11-25T12:47:02.667' AS DateTime), 3)
INSERT [dbo].[ProductosHistorico] ([Cod_Producto], [Fecha], [Stock]) VALUES (4, CAST(N'2023-11-25T14:21:57.073' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[TablaRebote] ON 

INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'1                                                               6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b01                                                 1                                                 1                                                 1', 1)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'11                                                              4fc82b26aecb47d2868c4efbe3581732a3e7cbcc6c2efb32062c08170a05eeb8011                                                11                                                11                                                1', 2)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'11111                                                           0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c011111                                             111                                               111                                               1', 3)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'111111111111111111111                                           f3b2ce1a487bc887474e85927fa4bcca4f3f2ab2e9ef530b31f484447f1e65260111111111                                         11111111                                          11111111                                          1', 4)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'1213                                                            f2fcaaed6b070b5de03f24ea5fd990abfe9121650072cd584961ec53bab87253012424                                             21424                                             24242                                             1', 5)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'123                                                             3fdba35f04dc8c462986c992bcf875546257113072a909c162f7e470e581e2780123                                               132                                               132                                               1', 6)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'2                                                               d4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab3502                                                 2                                                 2                                                 1', 7)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'2222222222                                                      cc399d73903f06ee694032ab0538f05634ff7e1ce5e8e50ac330a871484f34cf02222                                              2222                                              2222                                              1', 8)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'333                                                             556d7dc3a115356350f1f9910b1af1ab0e312d4b3e4fc788d2da63668f36d0170333                                               333                                               333                                               1', 9)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'4                                                               d4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab3502                                                 2                                                 2                                                 1', 10)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'44                                                              71ee45a3c0db9a9865f7313dd3372cf60dca6479d46261f3542eb9346e4a04d6044                                                44                                                444                                               1', 11)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'4444444                                                         bb0f6a26de562e481bcbfcc0380fe6ddc7f6bcb2a2fa5cda912087863efef2050444444444                                         44444444                                          4444444                                           1', 12)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'6666                                                            d7697570462f7562b83e81258de0f1e41832e98072e44c36ec8efec46786e24e06666                                              6666                                              6666                                              1', 13)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'777                                                             eaf89db7108470dc3f6b23ea90618264b3e8f8b6145371667c4055e9c5ce9f520777                                               777                                               777                                               1', 14)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'a                                                               32b8399b03667400a7ffbb68958a8b7978f559b13e2cc7332fcfc1743058472e01111111111                                        prueba                                            prueba                                            10', 15)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'Admin                                                           c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f01111                                              111                                               111                                               110', 16)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'Admin2                                                          c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f0admin                                             admin                                             admin                                             100', 17)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'Admin3                                                          c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f0aaaa                                              aaaa                                              aaaa                                              111', 18)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'Juan                                                            f43b4f3f45c2cef1882addf1d010c232ec7072b834303dfa3687e75a16d41f6f01111                                              11111                                             11111                                             111', 19)
INSERT [dbo].[TablaRebote] ([COLUMNA], [id]) VALUES (N'Leo                                                             5bc426e8d81e2f4136a562fac893c2229e3faa99d97df09ab604a2f8a0c0a60c0611', 20)
SET IDENTITY_INSERT [dbo].[TablaRebote] OFF
GO
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'1                                                               ', N'6b86b273ff34fce19d6b804eff5a3f5747ada4eaa22f1d49c01e52ddb7875b4b', 0, N'1                                                 ', N'1                                                 ', N'1                                                 ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'11                                                              ', N'4fc82b26aecb47d2868c4efbe3581732a3e7cbcc6c2efb32062c08170a05eeb8', 0, N'11                                                ', N'11                                                ', N'11                                                ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'11111                                                           ', N'0ffe1abd1a08215353c233d6e009613e95eec4253832a761af28ff37ac5a150c', 0, N'11111                                             ', N'111                                               ', N'111                                               ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'111111111111111111111                                           ', N'f3b2ce1a487bc887474e85927fa4bcca4f3f2ab2e9ef530b31f484447f1e6526', 0, N'111111111                                         ', N'11111111                                          ', N'11111111                                          ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'1213                                                            ', N'f2fcaaed6b070b5de03f24ea5fd990abfe9121650072cd584961ec53bab87253', 0, N'12424                                             ', N'21424                                             ', N'24242                                             ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'123                                                             ', N'3fdba35f04dc8c462986c992bcf875546257113072a909c162f7e470e581e278', 0, N'123                                               ', N'132                                               ', N'132                                               ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'2                                                               ', N'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35', 0, N'2                                                 ', N'2                                                 ', N'2                                                 ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'2222222222                                                      ', N'cc399d73903f06ee694032ab0538f05634ff7e1ce5e8e50ac330a871484f34cf', 0, N'2222                                              ', N'2222                                              ', N'2222                                              ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'333                                                             ', N'556d7dc3a115356350f1f9910b1af1ab0e312d4b3e4fc788d2da63668f36d017', 0, N'333                                               ', N'333                                               ', N'333                                               ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'4                                                               ', N'd4735e3a265e16eee03f59718b9b5d03019c07d8b6c51f90da3a666eec13ab35', 0, N'2                                                 ', N'2                                                 ', N'2                                                 ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'44                                                              ', N'71ee45a3c0db9a9865f7313dd3372cf60dca6479d46261f3542eb9346e4a04d6', 0, N'44                                                ', N'44                                                ', N'444                                               ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'4444444                                                         ', N'bb0f6a26de562e481bcbfcc0380fe6ddc7f6bcb2a2fa5cda912087863efef205', 0, N'444444444                                         ', N'44444444                                          ', N'4444444                                           ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'6666                                                            ', N'd7697570462f7562b83e81258de0f1e41832e98072e44c36ec8efec46786e24e', 0, N'6666                                              ', N'6666                                              ', N'6666                                              ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'777                                                             ', N'eaf89db7108470dc3f6b23ea90618264b3e8f8b6145371667c4055e9c5ce9f52', 0, N'777                                               ', N'777                                               ', N'777                                               ', NULL, 1, NULL)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'a                                                               ', N'32b8399b03667400a7ffbb68958a8b7978f559b13e2cc7332fcfc1743058472e', 0, N'1111111111                                        ', N'prueba                                            ', N'prueba                                            ', NULL, 1, 0)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'Admin                                                           ', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 0, N'1111                                              ', N'111                                               ', N'111                                               ', 1, 1, 0)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'Admin2                                                          ', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 0, N'admin                                             ', N'admin                                             ', N'admin                                             ', 1, 0, 0)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'Admin3                                                          ', N'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 0, N'aaaa                                              ', N'aaaa                                              ', N'aaaa                                              ', 1, 1, 1)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'Juan                                                            ', N'f43b4f3f45c2cef1882addf1d010c232ec7072b834303dfa3687e75a16d41f6f', 0, N'1111                                              ', N'11111                                             ', N'11111                                             ', 1, 1, 1)
INSERT [dbo].[Usuarios] ([Username], [Password], [Block], [DNI], [Apellido], [Nombre], [Cod_Perfil], [Activo], [Idioma]) VALUES (N'Leo                                                             ', N'5bc426e8d81e2f4136a562fac893c2229e3faa99d97df09ab604a2f8a0c0a60c', 0, NULL, NULL, NULL, 6, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (1, CAST(N'2023-10-21T15:46:45.280' AS DateTime), 30000)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (2, CAST(N'2023-10-21T15:49:04.983' AS DateTime), 30050)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (3, CAST(N'2023-10-21T15:50:46.513' AS DateTime), 150000)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (4, CAST(N'2023-10-21T15:51:26.890' AS DateTime), 50)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (5, CAST(N'2023-10-21T15:52:36.197' AS DateTime), 500)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (6, CAST(N'2023-10-29T19:07:38.753' AS DateTime), 10050)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (7, CAST(N'2023-10-29T19:08:45.240' AS DateTime), 50)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (8, CAST(N'2023-10-29T19:09:32.230' AS DateTime), 550)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (9, CAST(N'2023-10-29T19:10:35.090' AS DateTime), 10000)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (10, CAST(N'2023-11-24T20:26:52.217' AS DateTime), 20000)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (11, CAST(N'2023-11-25T12:47:02.670' AS DateTime), 1050000)
INSERT [dbo].[Ventas] ([Cod_Venta], [Fecha], [Precio]) VALUES (12, CAST(N'2023-11-25T14:21:57.073' AS DateTime), 10000)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Block]  DEFAULT ((0)) FOR [Block]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuarios_Activo]  DEFAULT ((1)) FOR [Activo]
GO
/****** Object:  StoredProcedure [dbo].[CalcularVerificador]    Script Date: 27/11/2023 11:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[CalcularVerificador] 
	
AS
BEGIN
	SET IDENTITY_INSERT dvUsuarios ON

	


	
END
GO
/****** Object:  StoredProcedure [dbo].[getAlquileres]    Script Date: 27/11/2023 11:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[getAlquileres]
AS
SELECT * FROM Alquileres
GO
/****** Object:  StoredProcedure [dbo].[InsertarDatosEnTablaRebote]    Script Date: 27/11/2023 11:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertarDatosEnTablaRebote] 
	
	@TableName NVARCHAR(MAX)
AS
BEGIN
	DECLARE @column_names NVARCHAR(MAX);
    DECLARE @sql NVARCHAR(MAX);
	DBCC CHECKIDENT ('TablaRebote', RESEED, 0);

    -- Obtener los nombres de las columnas
    SELECT @column_names = COALESCE(@column_names + ',', '') + COLUMN_NAME
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = @TableName;

    -- Construir la consulta dinámica
    SET @sql = 'DELETE FROM TablaRebote;
                INSERT INTO TablaRebote (COLUMNA) SELECT CONCAT(' + @column_names + ') AS rowToHash FROM ' + @TableName;

    -- Ejecutar la consulta dinámica
    EXEC sp_executesql @sql;
END
GO
/****** Object:  StoredProcedure [dbo].[storeAlquiler]    Script Date: 27/11/2023 11:01:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[storeAlquiler]
    @estacion int,
	@precio int,
	@tiempo float,
	@fecha datetime
AS
INSERT INTO  Alquileres (Estacion, Precio, Tiempo, Fecha)
VALUES(@estacion, @precio, @tiempo, @fecha)
GO
USE [master]
GO
ALTER DATABASE [THECAVE] SET  READ_WRITE 
GO
