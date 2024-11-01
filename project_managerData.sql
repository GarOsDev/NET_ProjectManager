USE [master]
GO
/****** Object:  Database [publicationsManager]    Script Date: 06/06/2024 17:13:20 ******/
CREATE DATABASE [publicationsManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'publicationsManager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\publicationsManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'publicationsManager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\publicationsManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [publicationsManager] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [publicationsManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [publicationsManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [publicationsManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [publicationsManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [publicationsManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [publicationsManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [publicationsManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [publicationsManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [publicationsManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [publicationsManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [publicationsManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [publicationsManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [publicationsManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [publicationsManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [publicationsManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [publicationsManager] SET  ENABLE_BROKER 
GO
ALTER DATABASE [publicationsManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [publicationsManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [publicationsManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [publicationsManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [publicationsManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [publicationsManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [publicationsManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [publicationsManager] SET RECOVERY FULL 
GO
ALTER DATABASE [publicationsManager] SET  MULTI_USER 
GO
ALTER DATABASE [publicationsManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [publicationsManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [publicationsManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [publicationsManager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [publicationsManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [publicationsManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'publicationsManager', N'ON'
GO
ALTER DATABASE [publicationsManager] SET QUERY_STORE = ON
GO
ALTER DATABASE [publicationsManager] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [publicationsManager]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/06/2024 17:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[archivos]    Script Date: 06/06/2024 17:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[archivos](
	[id_archivo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](300) NOT NULL,
	[tipo] [nvarchar](50) NOT NULL,
	[ruta] [nvarchar](500) NOT NULL,
	[id_publicacion] [int] NOT NULL,
 CONSTRAINT [PK_archivos] PRIMARY KEY CLUSTERED 
(
	[id_archivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publicaciones]    Script Date: 06/06/2024 17:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publicaciones](
	[id_publicacion] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](200) NOT NULL,
	[contenido] [nvarchar](max) NOT NULL,
	[fecha] [date] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_publicaciones] PRIMARY KEY CLUSTERED 
(
	[id_publicacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 06/06/2024 17:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UNQ_NomRol] UNIQUE NONCLUSTERED 
(
	[nombre_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 06/06/2024 17:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](200) NOT NULL,
	[email] [nvarchar](250) NOT NULL,
	[contrasena] [nvarchar](max) NOT NULL,
	[id_rol] [int] NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[archivos]  WITH CHECK ADD  CONSTRAINT [FK_archivos_publicaciones] FOREIGN KEY([id_publicacion])
REFERENCES [dbo].[publicaciones] ([id_publicacion])
GO
ALTER TABLE [dbo].[archivos] CHECK CONSTRAINT [FK_archivos_publicaciones]
GO
ALTER TABLE [dbo].[publicaciones]  WITH CHECK ADD  CONSTRAINT [FK_publicaciones_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[publicaciones] CHECK CONSTRAINT [FK_publicaciones_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_roles] FOREIGN KEY([id_rol])
REFERENCES [dbo].[roles] ([id_rol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_roles]
GO
USE [master]
GO
ALTER DATABASE [publicationsManager] SET  READ_WRITE 
GO
