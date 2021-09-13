USE [master]
GO
/****** Object:  Database [BlogEngine]    Script Date: 13/09/2021 11:02:44 a. m. ******/
CREATE DATABASE [BlogEngine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogEngine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogEngine.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BlogEngine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BlogEngine_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BlogEngine] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogEngine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogEngine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogEngine] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogEngine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogEngine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogEngine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogEngine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogEngine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogEngine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogEngine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogEngine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogEngine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogEngine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogEngine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogEngine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogEngine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogEngine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogEngine] SET RECOVERY FULL 
GO
ALTER DATABASE [BlogEngine] SET  MULTI_USER 
GO
ALTER DATABASE [BlogEngine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogEngine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogEngine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogEngine] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogEngine] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlogEngine] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BlogEngine', N'ON'
GO
ALTER DATABASE [BlogEngine] SET QUERY_STORE = OFF
GO
USE [BlogEngine]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[Content] [varchar](500) NOT NULL,
	[State] [tinyint] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogPost]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogPost](
	[LogPostId] [bigint] IDENTITY(1,1) NOT NULL,
	[PostId] [int] NOT NULL,
	[PostStateId] [smallint] NOT NULL,
	[AuthorId] [int] NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[Message] [varchar](1000) NULL,
 CONSTRAINT [PK_LogPost] PRIMARY KEY CLUSTERED 
(
	[LogPostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostId] [int] IDENTITY(1,1) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[PostStateId] [smallint] NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[Content] [varchar](2000) NOT NULL,
	[PublishingDate] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostState]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostState](
	[PostStateId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[State] [tinyint] NOT NULL,
 CONSTRAINT [PK_PostState] PRIMARY KEY CLUSTERED 
(
	[PostStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [smallint] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL,
	[State] [tinyint] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 13/09/2021 11:02:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [smallint] NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[State] [tinyint] NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 
GO
INSERT [dbo].[Comment] ([CommentId], [PostId], [Content], [State]) VALUES (1, 1, N'prueba', 1)
GO
INSERT [dbo].[Comment] ([CommentId], [PostId], [Content], [State]) VALUES (2, 1, N'prueba 1', 1)
GO
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[LogPost] ON 
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (1, 1, 1, 2, CAST(N'2021-09-07T18:56:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (2, 4, 1, 2, CAST(N'2021-09-09T07:15:29.093' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (3, 5, 1, 2, CAST(N'2021-09-09T07:17:16.007' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (4, 5, 2, 2, CAST(N'2021-09-09T07:49:55.130' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (5, 6, 1, 2, CAST(N'2021-09-10T07:15:28.137' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (6, 6, 2, 2, CAST(N'2021-09-10T07:16:48.483' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (7, 6, 4, 2, CAST(N'2021-09-10T07:21:34.890' AS DateTime), N'corregir')
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (8, 6, 2, 2, CAST(N'2021-09-10T07:23:15.773' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (9, 6, 3, 2, CAST(N'2021-09-10T07:24:11.487' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (10, 5, 4, 2, CAST(N'2021-09-10T08:18:12.623' AS DateTime), N'todo mal')
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (11, 7, 1, 2, CAST(N'2021-09-13T15:32:45.190' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (12, 7, 2, 2, CAST(N'2021-09-13T15:32:55.300' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (13, 7, 4, 3, CAST(N'2021-09-13T15:33:53.567' AS DateTime), N'test1')
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (14, 7, 2, 2, CAST(N'2021-09-13T15:43:36.483' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (15, 7, 3, 3, CAST(N'2021-09-13T15:44:19.920' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (16, 8, 1, 2, CAST(N'2021-09-13T15:45:03.083' AS DateTime), NULL)
GO
INSERT [dbo].[LogPost] ([LogPostId], [PostId], [PostStateId], [AuthorId], [LogDate], [Message]) VALUES (17, 8, 2, 2, CAST(N'2021-09-13T15:45:26.777' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[LogPost] OFF
GO
SET IDENTITY_INSERT [dbo].[Post] ON 
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (1, 2, 1, N'My First Post', N'Hello World!', NULL)
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (2, 2, 1, N'title 1', N'content 1', NULL)
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (3, 2, 1, N'title 2', N'content 2', NULL)
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (4, 2, 1, N'title 3', N'content 3', NULL)
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (5, 2, 4, N'title edit', N'content edit', NULL)
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (6, 2, 3, N'post flow new', N'hola mundo!!', CAST(N'2021-09-11T07:23:39.033' AS DateTime))
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (7, 2, 3, N'Test1', N'Test1', CAST(N'2021-09-15T15:43:49.957' AS DateTime))
GO
INSERT [dbo].[Post] ([PostId], [AuthorId], [PostStateId], [Title], [Content], [PublishingDate]) VALUES (8, 2, 2, N'Test2', N'Test2', NULL)
GO
SET IDENTITY_INSERT [dbo].[Post] OFF
GO
SET IDENTITY_INSERT [dbo].[PostState] ON 
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (1, N'Created', 1)
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (2, N'Submitted', 1)
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (3, N'Approved', 1)
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (4, N'Rejected', 1)
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (5, N'Published', 1)
GO
INSERT [dbo].[PostState] ([PostStateId], [Description], [State]) VALUES (6, N'Deleted', 1)
GO
SET IDENTITY_INSERT [dbo].[PostState] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([RoleId], [Description], [State]) VALUES (1, N'Public', 1)
GO
INSERT [dbo].[Role] ([RoleId], [Description], [State]) VALUES (2, N'Writer', 1)
GO
INSERT [dbo].[Role] ([RoleId], [Description], [State]) VALUES (3, N'Editor', 1)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [RoleId], [Username], [Password], [Name], [State]) VALUES (1, 1, N'Public1', N'Public123', N'Rodrigo Saraya', 1)
GO
INSERT [dbo].[User] ([UserId], [RoleId], [Username], [Password], [Name], [State]) VALUES (2, 2, N'Writer1', N'Writer123', N'Jaime Baily', 1)
GO
INSERT [dbo].[User] ([UserId], [RoleId], [Username], [Password], [Name], [State]) VALUES (3, 3, N'Editor1', N'Editor123', N'Hugo Savinovich', 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post]
GO
ALTER TABLE [dbo].[LogPost]  WITH CHECK ADD  CONSTRAINT [FK_LogPost_Post] FOREIGN KEY([PostId])
REFERENCES [dbo].[Post] ([PostId])
GO
ALTER TABLE [dbo].[LogPost] CHECK CONSTRAINT [FK_LogPost_Post]
GO
ALTER TABLE [dbo].[LogPost]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_PostState] FOREIGN KEY([PostStateId])
REFERENCES [dbo].[PostState] ([PostStateId])
GO
ALTER TABLE [dbo].[LogPost] CHECK CONSTRAINT [FK_Table_1_PostState]
GO
ALTER TABLE [dbo].[LogPost]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_User] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LogPost] CHECK CONSTRAINT [FK_Table_1_User]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_PostState] FOREIGN KEY([PostStateId])
REFERENCES [dbo].[PostState] ([PostStateId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_PostState]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [BlogEngine] SET  READ_WRITE 
GO
