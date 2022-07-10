USE [master]
GO
/****** Object:  Database [Campo]    Script Date: 6/27/2022 5:08:38 PM ******/
CREATE DATABASE [Campo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Campo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Campo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Campo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Campo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Campo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Campo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Campo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Campo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Campo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Campo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Campo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Campo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Campo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Campo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Campo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Campo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Campo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Campo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Campo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Campo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Campo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Campo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Campo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Campo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Campo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Campo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Campo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Campo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Campo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Campo] SET  MULTI_USER 
GO
ALTER DATABASE [Campo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Campo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Campo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Campo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Campo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Campo] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Campo] SET QUERY_STORE = OFF
GO
USE [Campo]
GO
/****** Object:  Table [dbo].[account]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[FK_language_account] [int] NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_profile]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_profile](
	[id_profile] [int] NOT NULL,
	[id_account] [int] NOT NULL,
 CONSTRAINT [PK_account_profile] PRIMARY KEY CLUSTERED 
(
	[id_profile] ASC,
	[id_account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_skills]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_skills](
	[id_account] [int] NOT NULL,
	[id_skills] [int] NOT NULL,
 CONSTRAINT [PK_account_skills] PRIMARY KEY CLUSTERED 
(
	[id_account] ASC,
	[id_skills] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_team]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_team](
	[id_account] [int] NOT NULL,
	[id_team] [int] NOT NULL,
 CONSTRAINT [PK_account_team] PRIMARY KEY CLUSTERED 
(
	[id_account] ASC,
	[id_team] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accountStatus]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accountStatus](
	[isBlocked] [bit] NOT NULL,
	[attempts] [int] NOT NULL,
	[FK_account_accountstatus] [int] NOT NULL,
 CONSTRAINT [PK_accountStatus] PRIMARY KEY CLUSTERED 
(
	[FK_account_accountstatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[achievement]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[achievement](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](150) NOT NULL,
	[date] [datetime] NOT NULL,
	[value] [int] NOT NULL,
	[FK_sender_achievement] [int] NOT NULL,
	[FK_receiver_achievement] [int] NOT NULL,
 CONSTRAINT [PK_achievement] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[epic]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[epic](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](150) NULL,
 CONSTRAINT [PK_epic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eventLog]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eventLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](50) NULL,
	[description] [varchar](150) NULL,
	[type] [varchar](50) NOT NULL,
	[date] [datetime] NOT NULL,
	[FK_account_eventLog] [int] NULL,
 CONSTRAINT [PK_eventLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[family_license]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[family_license](
	[id_family] [int] NOT NULL,
	[id_license] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[language]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[language](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_language] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[license]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[license](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](150) NULL,
 CONSTRAINT [PK_licenses] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[passwordHash]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[passwordHash](
	[passHash] [varchar](150) NOT NULL,
	[FK_account_passwordhash] [int] NOT NULL,
	[addDate] [datetime] NULL,
 CONSTRAINT [PK_passwordHash] PRIMARY KEY CLUSTERED 
(
	[passHash] ASC,
	[FK_account_passwordhash] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[position]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[value] [nchar](10) NULL,
	[FK_profile_position] [int] NOT NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](150) NULL,
	[value] [int] NULL,
 CONSTRAINT [PK_profile] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profile_license]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profile_license](
	[id_profile] [int] NOT NULL,
	[id_license] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[skills]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[skills](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[value] [int] NOT NULL,
 CONSTRAINT [PK_skills] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[task]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[task](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](150) NULL,
	[dateCreated] [datetime] NULL,
	[dateDeadline] [datetime] NULL,
	[dateFinished] [datetime] NULL,
	[value] [int] NULL,
	[state] [varchar](50) NOT NULL,
	[archived] [bit] NOT NULL,
	[FK_epic_task] [int] NOT NULL,
	[FK_team_task] [int] NOT NULL,
	[FK_account_task] [int] NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[team]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[value] [int] NOT NULL,
 CONSTRAINT [PK_team] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[words]    Script Date: 6/27/2022 5:08:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[words](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tag] [varchar](50) NULL,
	[word] [nvarchar](500) NULL,
	[FK_language_words] [int] NOT NULL,
 CONSTRAINT [PK_words] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account] ON 

INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (19, N'test1', N'test1', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (20, N'test3', N'test3', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (21, N'test', N'test', 2)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (22, N'test5', N'test5', 4)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (23, N'test6', N'test6', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (24, N'test7', N'test7', 4)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (25, N'testlanguage', N'testlanguage', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (26, N'testDefault', N'testDefault', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (27, N'test8', N'test8', 4)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (28, N'admin', N'admin', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (29, N'admin2', N'admin', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (30, N'tupac', N'tupac', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (31, N'admin3', N'admin3', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (32, N'Test10', N'ewrwerwr', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (33, N'', N'', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (34, N'test11', N'test', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (35, N'tomas', N'tomas', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (36, N'gladys', N'gladys@test.com', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (37, N'agustin', N'agustin@test.com', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (38, N'supervisor', N'sup@sup.com', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (39, N'agustin2', N'agus', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (40, N'florencia', N'florencia', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (41, N'Roberto', N'Roberto', 1)
INSERT [dbo].[account] ([id], [username], [email], [FK_language_account]) VALUES (42, N'Carlos', N'Carlos', 1)
SET IDENTITY_INSERT [dbo].[account] OFF
GO
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 20)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 22)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 24)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 28)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 29)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 30)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (1, 31)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 20)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 21)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 23)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 24)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 25)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 26)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 27)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 30)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 31)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 32)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 33)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 34)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (2, 37)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (3, 41)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (4, 38)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (5, 42)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (6, 35)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (6, 36)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (7, 39)
INSERT [dbo].[account_profile] ([id_profile], [id_account]) VALUES (8, 40)
GO
INSERT [dbo].[account_team] ([id_account], [id_team]) VALUES (34, 1)
INSERT [dbo].[account_team] ([id_account], [id_team]) VALUES (35, 3)
GO
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 19)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 20)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (1, 3, 21)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 22)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 23)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 24)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 25)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 26)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 27)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 1, 28)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 29)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 30)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 31)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 32)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (1, 0, 33)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 34)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 35)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 36)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 37)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 38)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 39)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 40)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 41)
INSERT [dbo].[accountStatus] ([isBlocked], [attempts], [FK_account_accountstatus]) VALUES (0, 0, 42)
GO
SET IDENTITY_INSERT [dbo].[achievement] ON 

INSERT [dbo].[achievement] ([id], [description], [date], [value], [FK_sender_achievement], [FK_receiver_achievement]) VALUES (1, N'MVP', CAST(N'2022-06-23T00:00:00.000' AS DateTime), 10, 38, 40)
INSERT [dbo].[achievement] ([id], [description], [date], [value], [FK_sender_achievement], [FK_receiver_achievement]) VALUES (2, N'MVP', CAST(N'2022-05-22T00:00:00.000' AS DateTime), 10, 38, 42)
SET IDENTITY_INSERT [dbo].[achievement] OFF
GO
SET IDENTITY_INSERT [dbo].[eventLog] ON 

INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (6, N'USER_CREATED', N'Account test1 created successfully', N'3', CAST(N'2022-06-04T17:15:24.477' AS DateTime), 19)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (7, N'USERNAME_ERROR', N'Username already exists', N'2', CAST(N'2022-06-04T17:20:14.387' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (8, N'USERNAME_ERROR', N'Username already exists', N'2', CAST(N'2022-06-04T17:21:12.657' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (9, N'USERNAME_ERROR', N'Username already exists', N'2', CAST(N'2022-06-04T17:21:51.297' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (10, N'USER_CREATED', N'Account test7 created successfully', N'3', CAST(N'2022-06-04T17:59:09.073' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (11, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T00:19:16.850' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (12, N'USER_CREATED', N'Account testlanguage created successfully', N'3', CAST(N'2022-06-06T00:20:44.583' AS DateTime), 25)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (13, N'LOGIN_OK', N'Account testlanguage logged successfully', N'3', CAST(N'2022-06-06T00:20:51.620' AS DateTime), 25)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (14, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:10:45.290' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (15, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:13:07.077' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (16, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:18:43.863' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (17, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:24:35.197' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (18, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:26:31.547' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (19, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:27:30.350' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (20, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:28:02.730' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (21, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:28:32.277' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (22, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:28:57.143' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (23, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:29:29.163' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (24, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:30:22.640' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (25, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:30:49.103' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (26, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:32:18.167' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (27, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:32:57.653' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (28, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:34:23.337' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (29, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:35:47.727' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (30, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:36:08.550' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (31, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:47:51.377' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (32, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:49:16.283' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (33, N'LOGIN_ERROR', N'Login error. Please try again.', N'1', CAST(N'2022-06-06T19:51:13.480' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (34, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:51:18.713' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (35, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:54:42.793' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (36, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:55:34.497' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (37, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T19:57:19.233' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (38, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T20:09:02.330' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (39, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T20:10:27.113' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (40, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T20:11:38.460' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (41, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-06T20:12:26.667' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (42, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T20:55:10.603' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (43, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T20:56:39.997' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (44, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T20:57:47.077' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (45, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:24:36.783' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (46, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:47:10.143' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (47, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:49:41.530' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (48, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:51:12.363' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (49, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:51:43.407' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (50, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:52:15.523' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (51, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:52:45.827' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (52, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:53:30.790' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (53, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:53:56.220' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (54, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:56:19.147' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (55, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T21:57:44.483' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (56, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:00:58.473' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (57, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:05:27.817' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (58, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:06:12.547' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (59, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:06:56.577' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (60, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:07:50.317' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (61, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:12:44.203' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (62, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:13:37.327' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (63, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:14:22.923' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (64, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:14:52.720' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (65, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:17:29.173' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (66, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:47:34.150' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (67, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:48:33.497' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (68, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:51:35.350' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (69, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:57:11.203' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (70, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T22:58:36.297' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (71, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:01:17.210' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (72, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:03:28.783' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (73, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:33:43.067' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (74, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:37:40.373' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (75, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:43:37.460' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (76, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:48:26.960' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (77, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:48:57.263' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (78, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:50:16.350' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (79, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:51:51.653' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (80, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:53:10.207' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (81, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:55:25.227' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (82, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-07T23:55:59.487' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (83, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T00:01:18.203' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (84, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T00:04:18.280' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (85, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T00:13:57.500' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (86, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T19:06:04.893' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (87, N'USER_CREATED', N'Account testDefault created successfully', N'3', CAST(N'2022-06-08T19:06:51.950' AS DateTime), 26)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (88, N'USERNAME_ERROR', N'Username already exists', N'2', CAST(N'2022-06-08T19:37:46.870' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (89, N'USER_CREATED', N'Account test8 created successfully', N'3', CAST(N'2022-06-08T19:38:01.933' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (90, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T19:38:05.697' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (91, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T19:43:52.000' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (92, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-08T19:43:54.010' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (93, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T19:44:16.407' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (94, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T19:44:48.363' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (95, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-08T19:44:50.450' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (96, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T19:48:29.337' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (97, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-08T19:48:34.730' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (98, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T19:55:01.873' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (99, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T20:19:19.427' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (100, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-08T20:21:05.270' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (101, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:21:30.787' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (102, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:24:40.587' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (103, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:24:59.513' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (104, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:25:33.300' AS DateTime), 24)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (105, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:26:51.757' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (106, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:28:48.263' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (107, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:29:22.330' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (108, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:31:13.157' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (109, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:31:57.047' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (110, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:38:18.417' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (111, N'USER_CREATED', N'Account admin created successfully', N'3', CAST(N'2022-06-08T20:40:31.600' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (112, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T20:40:36.087' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (113, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-08T20:41:34.250' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (114, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T20:43:29.307' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (115, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:44:30.727' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (116, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:44:47.370' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (117, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:45:18.993' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (118, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:45:49.037' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (119, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:46:58.767' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (120, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:48:43.403' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (121, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T20:50:05.693' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (122, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T20:50:41.353' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (123, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T20:50:52.363' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (124, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T20:51:40.627' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (125, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T20:55:19.957' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (126, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:01:27.267' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (127, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:02:10.057' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (128, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:05:21.673' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (129, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:26:28.200' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (130, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:29:19.520' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (131, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:31:52.513' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (132, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T21:32:51.033' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (133, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:32:58.427' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (134, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:33:13.483' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (135, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T21:39:52.667' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (136, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:40:06.027' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (137, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T21:45:05.107' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (138, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:45:13.153' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (139, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:49:10.300' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (140, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:49:33.150' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (141, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T21:49:58.463' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (142, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:50:16.930' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (143, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:53:05.177' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (144, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T21:55:54.913' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (145, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:56:14.803' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (146, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T21:56:46.073' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (147, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T21:58:27.927' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (148, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T22:01:29.020' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (149, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T22:02:22.660' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (150, N'LOGIN_ERROR', N'Login error. Please try again.', N'1', CAST(N'2022-06-08T22:08:02.027' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (151, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-08T22:08:13.423' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (152, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-08T22:08:45.453' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (153, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T22:08:57.780' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (154, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-08T22:10:07.907' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (155, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:08:25.763' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (156, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:08:49.787' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (157, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:09:28.743' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (158, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:11:35.320' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (159, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-09T21:11:46.327' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (160, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:12:05.910' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (161, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:14:15.027' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (162, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:14:57.840' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (163, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:18:04.520' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (164, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:18:25.487' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (165, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:19:11.537' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (166, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:19:50.667' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (167, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:22:58.383' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (168, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:23:35.603' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (169, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:36:16.997' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (170, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:37:03.953' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (171, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:38:01.947' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (172, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:39:48.890' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (173, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:40:38.697' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (174, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:41:30.717' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (175, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:44:04.807' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (176, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:45:41.173' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (177, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:48:52.987' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (178, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:51:09.940' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (179, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:55:19.670' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (180, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T21:57:57.977' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (181, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:05:44.060' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (182, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:07:06.723' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (183, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:09:32.753' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (184, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:10:53.800' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (185, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:12:29.017' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (186, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:17:02.850' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (187, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:18:21.360' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (188, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-09T22:18:45.050' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (189, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:19:48.787' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (190, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:21:44.737' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (191, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:22:40.923' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (192, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:24:05.523' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (193, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:58:02.147' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (194, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T22:58:55.740' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (195, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:00:30.667' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (196, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:01:37.997' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (197, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:06:47.743' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (198, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:10:23.140' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (199, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:13:44.723' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (200, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:18:11.820' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (201, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:18:49.093' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (202, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:23:59.127' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (203, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:25:13.280' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (204, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:27:07.717' AS DateTime), 28)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (205, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:41:55.557' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (206, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:42:11.533' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (207, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:43:33.993' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (208, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:45:18.073' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (209, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:46:55.687' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (210, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:47:10.720' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (211, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-09T23:48:40.247' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (212, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:33:39.670' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (213, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:34:55.047' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (214, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:44:00.150' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (215, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:49:48.713' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (216, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:51:55.820' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (217, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:52:19.050' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (218, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:53:22.283' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (219, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:55:16.723' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (220, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T14:57:25.900' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (221, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-11T14:57:45.123' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (222, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-11T14:58:38.397' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (223, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-11T14:59:51.353' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (224, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:00:06.280' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (225, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:01:27.530' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (226, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:01:42.607' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (227, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:02:33.547' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (228, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:03:37.223' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (229, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:05:59.990' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (230, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:13:41.617' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (231, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:14:00.180' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (232, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:14:22.677' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (233, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:23:53.733' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (234, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:24:46.743' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (235, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:29:17.290' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (236, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:30:25.837' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (237, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T15:52:15.263' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (238, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T16:08:48.463' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (239, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T16:15:58.580' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (240, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:28:35.903' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (241, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:43:49.380' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (242, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:45:09.357' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (243, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:46:32.783' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (244, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:53:46.407' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (245, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:56:53.637' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (246, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:58:22.423' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (247, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T17:58:48.623' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (248, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T18:01:24.793' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (249, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T18:01:47.077' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (250, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T18:49:55.617' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (251, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T18:58:51.393' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (252, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T19:00:10.510' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (253, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T19:02:53.093' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (254, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T19:07:02.200' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (255, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-11T19:10:09.240' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (256, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T19:11:13.213' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (257, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-11T19:15:17.387' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (258, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T13:53:10.823' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (259, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:02:22.207' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (260, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:03:51.727' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (261, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:04:01.953' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (262, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:04:41.477' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (263, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:06:32.207' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (264, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:07:48.950' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (265, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:08:59.820' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (266, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:09:33.470' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (267, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:09:47.883' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (268, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:15:21.697' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (269, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:38:46.507' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (270, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:39:37.713' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (271, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:42:50.420' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (272, N'NEW_LICENSE_ADD_OK', N'Account admin added a new license', N'3', CAST(N'2022-06-12T14:44:02.873' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (273, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 3, Slave License ID: 11', N'3', CAST(N'2022-06-12T14:44:07.190' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (274, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 11', N'3', CAST(N'2022-06-12T14:44:10.097' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (275, N'NEW_LICENSE_DELETE_OK', N'Account admin removed an existing license', N'3', CAST(N'2022-06-12T14:44:12.533' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (276, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:46:25.847' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (277, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T14:53:59.030' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (278, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 3, Slave License ID: 9', N'3', CAST(N'2022-06-12T14:54:03.560' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (279, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:13:20.547' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (280, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 12', N'3', CAST(N'2022-06-12T15:13:27.567' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (281, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 9', N'3', CAST(N'2022-06-12T15:13:34.180' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (282, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:13:42.617' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (283, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:30:46.930' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (284, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:31:06.953' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (285, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:33:31.153' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (286, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:34:00.123' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (287, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:37:43.313' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (288, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:38:21.983' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (289, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:38:46.980' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (290, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T15:39:17.537' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (291, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T16:45:36.770' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (292, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T16:46:10.810' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (293, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T16:47:05.057' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (294, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T16:48:02.813' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (295, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T16:49:12.247' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (296, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:07:01.953' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (297, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:08:02.200' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (298, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:12:54.770' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (299, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:13:30.640' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (300, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:15:01.873' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (301, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:15:34.853' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (302, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:17:40.020' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (303, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:18:45.503' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (304, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:20:46.843' AS DateTime), 28)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (305, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:20:51.657' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (306, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:23:47.620' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (307, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:23:50.380' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (308, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:23:53.610' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (309, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:24:05.673' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (310, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:24:09.307' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (311, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:24:40.550' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (312, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:24:42.917' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (313, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:24:44.953' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (314, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:24:48.673' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (315, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:25:12.983' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (316, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:25:16.513' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (317, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:25:31.203' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (318, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:31:50.317' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (319, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:32:04.820' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (320, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:32:16.570' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (321, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-12T17:32:18.563' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (322, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:33:38.803' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (323, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-12T17:33:41.787' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (324, N'BLOCKED', N'Account test7 blocked due to repeated attempts.', N'2', CAST(N'2022-06-12T17:34:46.300' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (325, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T17:34:51.630' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (326, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-12T17:34:55.513' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (327, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-12T17:34:58.627' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (328, N'LOGIN_OK', N'Account test7 logged successfully', N'3', CAST(N'2022-06-12T17:35:01.653' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (329, N'LOGOUT', N'Account test7 logged out', N'3', CAST(N'2022-06-12T17:35:07.243' AS DateTime), 24)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (330, N'LOGIN_OK', N'Account test8 logged successfully', N'3', CAST(N'2022-06-12T17:35:10.617' AS DateTime), 27)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (331, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:09:00.530' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (332, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:10:11.210' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (333, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:11:40.517' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (334, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:13:35.323' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (335, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:16:55.293' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (336, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:23:53.973' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (337, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:24:36.780' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (338, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:25:03.620' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (339, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:25:18.053' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (340, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:46:05.993' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (341, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:47:36.033' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (342, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:50:39.453' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (343, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:55:19.107' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (344, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T18:59:05.580' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (345, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:00:05.463' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (346, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:02:55.223' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (347, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:03:41.720' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (348, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-12T19:04:07.073' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (349, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-12T19:04:09.283' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (350, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-12T19:04:11.463' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (351, N'LOGIN_OK', N'Account test5 logged successfully', N'3', CAST(N'2022-06-12T19:04:15.720' AS DateTime), 22)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (352, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:06:07.340' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (353, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:08:42.017' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (354, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-12T19:38:48.467' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (355, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T19:25:37.423' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (356, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T19:34:25.557' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (357, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 3, Slave License ID: 9', N'3', CAST(N'2022-06-13T19:34:31.570' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (358, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 9, Slave License ID: 6', N'3', CAST(N'2022-06-13T19:34:35.900' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (359, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 6', N'3', CAST(N'2022-06-13T19:34:43.717' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (360, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T19:34:54.480' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (361, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T19:34:57.110' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (362, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:04:13.927' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (363, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:12:21.037' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (364, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:15:56.303' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (365, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T20:16:09.097' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (366, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T20:16:19.700' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (367, N'ACCOUNT_BLOCKED_OK', N'Account admin blocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T20:16:21.543' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (368, N'ACCOUNT_UNBLOCKED_OK', N'Account admin unblocked the account ID:19 - Username:test1', N'3', CAST(N'2022-06-13T20:16:23.723' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (369, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-13T20:17:09.963' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (370, N'LOGIN_OK', N'Account test3 logged successfully', N'3', CAST(N'2022-06-13T20:17:15.183' AS DateTime), 20)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (371, N'LOGOUT', N'Account test3 logged out', N'3', CAST(N'2022-06-13T20:17:18.573' AS DateTime), 20)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (372, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:17:21.870' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (373, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-13T20:17:27.853' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (374, N'LOGIN_OK', N'Account test3 logged successfully', N'3', CAST(N'2022-06-13T20:17:32.370' AS DateTime), 20)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (375, N'NEW_LICENSE_RELATION_OK', N'Account test3 added a new license dependency Master License ID: 9, Slave License ID: 6', N'3', CAST(N'2022-06-13T20:17:48.127' AS DateTime), 20)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (376, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:20:45.860' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (377, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:41:14.690' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (378, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 6, Slave License ID: 7', N'3', CAST(N'2022-06-13T20:41:27.093' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (379, N'NEW_LICENSE_ADD_OK', N'Account admin added a new license', N'3', CAST(N'2022-06-13T20:41:46.553' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (380, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 6, Slave License ID: 13', N'3', CAST(N'2022-06-13T20:41:54.270' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (381, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 12', N'3', CAST(N'2022-06-13T20:42:00.503' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (382, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 3, Slave License ID: 13', N'3', CAST(N'2022-06-13T20:42:14.157' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (383, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-13T20:43:30.063' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (384, N'LOGIN_OK', N'Account test5 logged successfully', N'3', CAST(N'2022-06-13T20:43:35.170' AS DateTime), 22)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (385, N'NEW_LICENSE_RELATION_OK', N'Account test5 added a new license dependency Master License ID: 2, Slave License ID: 12', N'3', CAST(N'2022-06-13T20:43:45.053' AS DateTime), 22)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (386, N'LOGOUT', N'Account test5 logged out', N'3', CAST(N'2022-06-13T20:43:48.677' AS DateTime), 22)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (387, N'LOGIN_OK', N'Account test5 logged successfully', N'3', CAST(N'2022-06-13T20:43:58.237' AS DateTime), 22)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (388, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-13T20:47:55.093' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (389, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 13, Slave License ID: 9', N'3', CAST(N'2022-06-13T20:48:59.207' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (390, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 12, Slave License ID: 7', N'3', CAST(N'2022-06-13T20:49:21.873' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (391, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:29:23.270' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (392, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:34:24.660' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (393, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:52:55.433' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (394, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:53:42.533' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (395, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:55:56.123' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (396, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:56:10.927' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (397, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:56:39.543' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (398, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:57:37.593' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (399, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:58:11.927' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (400, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T19:58:55.357' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (401, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:03:20.127' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (402, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:03:47.263' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (403, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:04:24.193' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (404, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:05:22.123' AS DateTime), 28)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (405, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:06:52.353' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (406, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:07:16.160' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (407, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:07:46.467' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (408, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:08:08.330' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (409, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:09:10.150' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (410, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:10:59.690' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (411, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:19:55.517' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (412, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:20:23.500' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (413, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:20:44.030' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (414, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:21:12.523' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (415, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:21:51.057' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (416, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:22:32.507' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (417, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:25:00.673' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (418, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:26:19.590' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (419, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:26:48.883' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (420, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:27:15.863' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (421, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:27:36.853' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (422, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:29:42.317' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (423, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:33:05.387' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (424, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:34:52.220' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (425, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:36:22.103' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (426, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-14T20:36:24.980' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (427, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-14T20:36:38.017' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (428, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:36:41.030' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (429, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:37:48.327' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (430, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:37:59.887' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (431, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-14T20:38:02.803' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (432, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:38:24.330' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (433, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:40:32.183' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (434, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 15', N'3', CAST(N'2022-06-14T20:40:41.480' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (435, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 14', N'3', CAST(N'2022-06-14T20:40:45.603' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (436, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 13', N'3', CAST(N'2022-06-14T20:40:51.433' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (437, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 7', N'3', CAST(N'2022-06-14T20:40:53.750' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (438, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 4', N'3', CAST(N'2022-06-14T20:41:06.063' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (439, N'NEW_LICENSE_DELETE_OK', N'Account admin removed an existing license', N'3', CAST(N'2022-06-14T20:41:10.267' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (440, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:41:16.967' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (441, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:41:20.293' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (442, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 3', N'3', CAST(N'2022-06-14T20:41:27.950' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (443, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:41:30.330' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (444, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:41:35.027' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (445, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:42:23.400' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (446, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 15', N'3', CAST(N'2022-06-14T20:42:27.503' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (447, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:42:30.547' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (448, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:42:36.053' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (449, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 15', N'3', CAST(N'2022-06-14T20:42:40.437' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (450, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 12', N'3', CAST(N'2022-06-14T20:42:45.370' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (451, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:42:47.347' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (452, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:42:50.283' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (453, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 12', N'3', CAST(N'2022-06-14T20:42:55.393' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (454, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin moved license to orphan license pool License ID: 14', N'3', CAST(N'2022-06-14T20:42:58.437' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (455, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:43:00.713' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (456, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:43:03.867' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (457, N'NEW_LICENSE_RELATION_OK', N'Account admin added a new license dependency Master License ID: 2, Slave License ID: 14', N'3', CAST(N'2022-06-14T20:43:07.770' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (458, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-14T20:43:11.423' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (459, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-14T20:43:14.633' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (460, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-15T18:33:34.133' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (461, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T18:48:16.890' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (462, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T18:57:48.137' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (463, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T18:59:26.270' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (464, N'LOGOUT', N'Account test logged out', N'3', CAST(N'2022-06-15T18:59:41.910' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (465, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T18:59:47.567' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (466, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-15T18:59:57.307' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (467, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T19:05:27.413' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (468, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-15T19:05:54.563' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (469, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T19:06:16.123' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (470, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T19:10:45.773' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (471, N'LOGIN_OK', N'Account test logged successfully', N'3', CAST(N'2022-06-15T19:14:53.933' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (472, N'PASSWORD_CHANGE_ERROR', N'Account test COULD NOT CHANGE ITS PASSWORD', N'3', CAST(N'2022-06-15T19:14:58.323' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (473, N'PASSWORD_CHANGE_ERROR', N'Account test COULD NOT CHANGE ITS PASSWORD', N'3', CAST(N'2022-06-15T19:15:06.930' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (474, N'PASSWORD_CHANGE_OK', N'Account test changed its password successfully', N'3', CAST(N'2022-06-15T19:15:10.467' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (475, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-15T19:15:42.957' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (476, N'PASSWORD_CHANGE_OK', N'Account admin changed its password successfully', N'3', CAST(N'2022-06-15T19:16:37.313' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (477, N'LOGOUT', N'Account admin logged out', N'3', CAST(N'2022-06-15T19:16:41.650' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (478, N'LOGIN_OK', N'Account admin logged successfully', N'3', CAST(N'2022-06-15T19:16:45.103' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (479, N'PASSWORD_CHANGE_ERROR', N'Account admin COULD NOT CHANGE ITS PASSWORD', N'3', CAST(N'2022-06-15T19:16:51.193' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (480, N'PASSWORD_CHANGE_OK', N'Account admin changed its password successfully', N'3', CAST(N'2022-06-15T19:17:00.503' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (481, N'BLOCKED', N'Account test blocked due to repeated attempts.', N'2', CAST(N'2022-06-15T19:55:34.887' AS DateTime), 21)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (482, N'USER_CREATED', N'Account admin2 created successfully', N'3', CAST(N'2022-06-15T19:55:43.860' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (483, N'LOGIN_OK', N'Account admin2 logged successfully', N'3', CAST(N'2022-06-15T19:55:50.343' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (484, N'LOGOUT', N'Account admin2 logged out', N'3', CAST(N'2022-06-15T19:56:22.143' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (485, N'USER_CREATED', N'Account tupac created successfully', N'3', CAST(N'2022-06-15T19:56:30.787' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (486, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T19:56:35.473' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (487, N'LOGOUT', N'Account tupac logged out', N'3', CAST(N'2022-06-15T19:57:22.863' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (488, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T19:57:26.247' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (489, N'PASSWORD_CHANGE_OK', N'Account tupac changed its password successfully', N'3', CAST(N'2022-06-15T19:57:34.327' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (490, N'LOGOUT', N'Account tupac logged out', N'3', CAST(N'2022-06-15T19:57:36.543' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (491, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T19:57:40.807' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (492, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:06:57.607' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (493, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:07:22.457' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (494, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:07:59.890' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (495, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:08:35.347' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (496, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:09:08.740' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (497, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:23:30.613' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (498, N'NEW_LICENSE_RELATION_OK', N'Account tupac added a new license dependency Master License ID: 14, Slave License ID: 13', N'3', CAST(N'2022-06-15T20:23:43.487' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (499, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:24:59.483' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (500, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:27:34.940' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (501, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:28:30.983' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (502, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:30:59.250' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (503, N'LOGOUT', N'Account tupac logged out', N'3', CAST(N'2022-06-15T20:32:37.073' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (504, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:32:48.727' AS DateTime), 30)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (505, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:33:17.287' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (506, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:35:43.837' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (507, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:36:41.223' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (508, N'LOGIN_OK', N'Account tupac logged successfully', N'3', CAST(N'2022-06-15T20:37:15.090' AS DateTime), 30)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (509, N'BLOCKED', N'Account admin blocked due to repeated attempts.', N'2', CAST(N'2022-06-16T20:09:14.880' AS DateTime), 28)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (510, N'LOGIN_OK', N'Account admin2 logged successfully', N'3', CAST(N'2022-06-16T20:09:23.477' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (511, N'LOGIN_OK', N'Account test1 logged successfully', N'3', CAST(N'2022-06-16T20:11:35.363' AS DateTime), 19)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (512, N'USER_CREATED', N'Account admin3 created successfully', N'3', CAST(N'2022-06-16T20:12:18.657' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (513, N'LOGIN_OK', N'Account admin3 logged successfully', N'3', CAST(N'2022-06-16T20:12:41.013' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (514, N'LOGOUT', N'Account admin3 logged out', N'3', CAST(N'2022-06-16T20:13:34.027' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (515, N'LOGIN_OK', N'Account admin2 logged successfully', N'3', CAST(N'2022-06-16T20:13:50.893' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (516, N'LOGOUT', N'Account admin2 logged out', N'3', CAST(N'2022-06-16T20:14:11.037' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (517, N'LOGIN_OK', N'Account admin3 logged successfully', N'3', CAST(N'2022-06-16T20:14:23.790' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (518, N'PASSWORD_CHANGE_OK', N'Account admin3 changed its password successfully', N'3', CAST(N'2022-06-16T20:14:44.780' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (519, N'LOGOUT', N'Account admin3 logged out', N'3', CAST(N'2022-06-16T20:14:48.677' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (520, N'LOGIN_OK', N'Account admin3 logged successfully', N'3', CAST(N'2022-06-16T20:14:53.743' AS DateTime), 31)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (521, N'LOGIN_OK', N'Account admin2 logged successfully', N'Type', CAST(N'2022-06-19T17:34:48.730' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (522, N'LOGOUT', N'Account admin2 logged out', N'Type', CAST(N'2022-06-19T17:34:51.660' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (523, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-19T17:41:55.303' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (524, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-19T17:41:58.387' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (525, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T18:12:23.843' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (526, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-20T18:16:03.030' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (527, N'LOGIN_ERROR', N'Login error. Please try again.', N'Error', CAST(N'2022-06-20T18:19:26.863' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (528, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T18:22:27.753' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (529, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-20T18:22:30.853' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (530, N'USER_CREATED', N'Account Test10 created successfully', N'Control', CAST(N'2022-06-20T18:40:07.720' AS DateTime), 32)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (531, N'LOGIN_OK', N'Account Test10 logged successfully', N'Control', CAST(N'2022-06-20T18:40:17.223' AS DateTime), 32)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (532, N'LOGOUT', N'Account Test10 logged out', N'Control', CAST(N'2022-06-20T18:40:20.513' AS DateTime), 32)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (533, N'USER_CREATED', N'Account  created successfully', N'Control', CAST(N'2022-06-20T19:05:58.823' AS DateTime), 33)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (534, N'USER_CREATED', N'Account test11 created successfully', N'Control', CAST(N'2022-06-20T19:21:42.240' AS DateTime), 34)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (535, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T20:31:29.663' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (536, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T20:35:54.267' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (537, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T20:40:32.383' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (538, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T21:40:32.823' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (539, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T21:41:37.330' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (540, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T21:58:54.963' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (541, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T21:59:48.650' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (542, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:01:06.093' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (543, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:02:00.093' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (544, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:07:09.230' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (545, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:09:43.070' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (546, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:10:27.697' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (547, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:10:59.360' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (548, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:11:30.080' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (549, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:17:44.420' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (550, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:20:21.880' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (551, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:20:33.923' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (552, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:42:50.220' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (553, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:44:49.530' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (554, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:50:42.777' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (555, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:53:21.887' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (556, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:53:55.890' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (557, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:54:12.317' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (558, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T22:54:44.957' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (559, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:20:07.850' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (560, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:20:47.167' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (561, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:28:55.620' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (562, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:38:12.337' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (563, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:39:41.727' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (564, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:44:08.947' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (565, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:45:59.477' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (566, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:57:52.337' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (567, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-20T23:58:38.003' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (568, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-20T23:58:47.583' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (569, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:00:18.553' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (570, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:05:05.833' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (571, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T00:05:08.237' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (572, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:05:13.000' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (573, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:49:59.620' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (574, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:51:27.340' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (575, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:55:04.573' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (576, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:55:47.977' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (577, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:56:12.900' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (578, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:58:26.420' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (579, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:58:36.097' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (580, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:59:11.333' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (581, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T00:59:38.030' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (582, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:01:33.927' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (583, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:02:13.293' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (584, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:03:26.867' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (585, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:04:02.200' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (586, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:08:46.530' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (587, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:10:12.047' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (588, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:10:46.953' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (589, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:11:49.717' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (590, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:17:55.873' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (591, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:18:52.360' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (592, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:20:09.063' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (593, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:20:25.853' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (594, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:20:53.407' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (595, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:21:10.330' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (596, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:21:57.487' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (597, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:25:55.660' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (598, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:26:55.030' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (599, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:27:55.730' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (600, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:28:06.923' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (601, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:28:47.360' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (602, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:28:59.247' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (603, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:29:29.550' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (604, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:29:55.193' AS DateTime), 29)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (605, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:33:24.980' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (606, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:35:06.760' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (607, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:43:37.253' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (608, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:49:27.473' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (609, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T01:50:15.600' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (610, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T19:18:59.253' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (611, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T19:26:52.443' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (612, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T19:50:31.523' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (613, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:00:17.530' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (614, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:00:31.880' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (615, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:02:18.113' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (616, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:02:28.097' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (617, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:04:04.007' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (618, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:04:12.753' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (619, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:05:16.017' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (620, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:05:23.677' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (621, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:05:32.953' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (622, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:05:46.187' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (623, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:06:04.727' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (624, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:06:57.630' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (625, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:07:05.187' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (626, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:07:08.583' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (627, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-21T20:07:17.050' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (628, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:19:26.603' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (629, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:20:16.197' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (630, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:20:40.413' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (631, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:28:13.530' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (632, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-21T20:31:26.320' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (633, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-23T17:44:10.650' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (634, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-23T19:55:41.603' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (635, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-23T19:56:25.310' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (636, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T19:24:23.580' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (637, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:01:24.867' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (638, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:02:07.457' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (639, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:07:36.267' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (640, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:40:10.363' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (641, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:42:08.867' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (642, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:52:03.057' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (643, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T20:57:39.157' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (644, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T23:40:30.717' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (645, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T23:44:27.983' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (646, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T23:48:01.860' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (647, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-25T23:50:29.537' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (648, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T18:52:34.630' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (649, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:01:04.047' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (650, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:01:59.387' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (651, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:06:17.503' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (652, N'USER_CREATED', N'Account tomas created successfully', N'Control', CAST(N'2022-06-26T19:06:40.250' AS DateTime), 35)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (653, N'LOGIN_OK', N'Account tomas logged successfully', N'Control', CAST(N'2022-06-26T19:07:02.043' AS DateTime), 35)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (654, N'USER_CREATED', N'Account gladys created successfully', N'Control', CAST(N'2022-06-26T19:08:19.113' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (655, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T19:08:23.847' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (656, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:12:49.357' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (657, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-26T19:13:20.127' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (658, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T19:13:25.167' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (659, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:14:56.077' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (660, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:16:52.167' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (661, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:32:22.523' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (662, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:32:44.353' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (663, N'USER_CREATED', N'Account agustin created successfully', N'Control', CAST(N'2022-06-26T19:33:02.737' AS DateTime), 37)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (664, N'LOGIN_OK', N'Account tomas logged successfully', N'Control', CAST(N'2022-06-26T19:34:38.013' AS DateTime), 35)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (665, N'PASSWORD_CHANGE_OK', N'Account tomas changed its password successfully', N'Control', CAST(N'2022-06-26T19:34:51.593' AS DateTime), 35)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (666, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T19:40:34.487' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (667, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-26T19:40:39.243' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (668, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T19:40:42.477' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (669, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T19:41:29.990' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (670, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T19:54:55.263' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (671, N'LOGIN_OK', N'Account gladys logged successfully', N'Control', CAST(N'2022-06-26T20:04:26.237' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (672, N'LOGOUT', N'Account gladys logged out', N'Control', CAST(N'2022-06-26T20:04:30.017' AS DateTime), 36)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (673, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-26T20:04:32.467' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (674, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T00:20:40.977' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (675, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T00:22:30.977' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (676, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:00:27.983' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (677, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:01:23.760' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (678, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:03:23.693' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (679, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:04:27.400' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (680, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:07:31.070' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (681, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:09:26.597' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (682, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:10:31.717' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (683, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:14:58.043' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (684, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:22:49.757' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (685, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:26:03.267' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (686, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:27:07.987' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (687, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:27:25.350' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (688, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:32:19.987' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (689, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:35:27.653' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (690, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:39:09.103' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (691, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:39:23.767' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (692, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:40:18.677' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (693, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:41:53.563' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (694, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:46:26.350' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (695, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:47:29.157' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (696, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:48:55.860' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (697, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:49:37.967' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (698, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:50:27.177' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (699, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:51:34.657' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (700, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:53:31.017' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (701, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T02:55:33.893' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (702, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:04:05.480' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (703, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:04:51.373' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (704, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:06:01.980' AS DateTime), 29)
GO
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (705, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:06:31.370' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (706, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:07:16.180' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (707, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:08:05.767' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (708, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:08:51.153' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (709, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:09:42.537' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (710, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:14:10.160' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (711, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:17:06.000' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (712, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:18:48.340' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (713, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:42:42.950' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (714, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:44:36.110' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (715, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:48:54.000' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (716, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:50:02.743' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (717, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:53:29.097' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (718, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T03:54:44.117' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (719, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T04:20:41.373' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (720, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T04:21:32.927' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (721, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T04:23:04.160' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (722, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T04:24:18.410' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (723, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T04:25:44.173' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1633, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T11:52:35.597' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1634, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T11:53:19.680' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1635, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T11:54:47.610' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1636, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T11:55:35.720' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1637, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T12:00:00.647' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1638, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T12:07:33.260' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1639, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T12:50:05.190' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1640, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T13:37:15.227' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1641, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:23:46.123' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1642, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:30:18.607' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1643, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:35:23.157' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1644, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:35:55.387' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1645, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:36:28.270' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1646, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:37:03.370' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1647, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:37:46.687' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1648, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:40:04.663' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1649, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:41:45.457' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1650, N'ACCOUNT_UNBLOCKED_OK', N'Account admin2 unblocked the account ID:19 - Username:test1', N'Control', CAST(N'2022-06-27T15:42:15.793' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1651, N'ACCOUNT_BLOCKED_OK', N'Account admin2 blocked the account ID:19 - Username:test1', N'Control', CAST(N'2022-06-27T15:42:26.977' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1652, N'USER_CREATED', N'Account supervisor created successfully', N'Control', CAST(N'2022-06-27T15:42:48.620' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1653, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-27T15:43:02.523' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1654, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:43:11.700' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1655, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-27T15:43:50.983' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1656, N'LOGIN_OK', N'Account supervisor logged successfully', N'Control', CAST(N'2022-06-27T15:43:55.790' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1657, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:44:51.900' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1658, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 13', N'Control', CAST(N'2022-06-27T15:45:31.607' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1659, N'LOGOUT', N'Account admin2 logged out', N'Control', CAST(N'2022-06-27T15:45:47.513' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1660, N'LOGIN_OK', N'Account supervisor logged successfully', N'Control', CAST(N'2022-06-27T15:45:54.487' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1661, N'LOGOUT', N'Account supervisor logged out', N'Control', CAST(N'2022-06-27T15:46:21.653' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1662, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:46:24.520' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1663, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 3, Slave License ID: 13', N'Control', CAST(N'2022-06-27T15:48:43.997' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1664, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 3', N'Control', CAST(N'2022-06-27T15:48:46.770' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1665, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 2, Slave License ID: 13', N'Control', CAST(N'2022-06-27T15:48:51.613' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1666, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 2', N'Control', CAST(N'2022-06-27T15:48:53.963' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1667, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:51:41.353' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1668, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:53:15.643' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1669, N'NEW_LICENSE_ADD_OK', N'Account admin2 added a new license', N'Control', CAST(N'2022-06-27T15:53:39.863' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1670, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 2, Slave License ID: 16', N'Control', CAST(N'2022-06-27T15:54:09.237' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1671, N'NEW_LICENSE_ADD_OK', N'Account admin2 added a new license', N'Control', CAST(N'2022-06-27T15:54:43.180' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1672, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 2, Slave License ID: 17', N'Control', CAST(N'2022-06-27T15:54:46.870' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1673, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 2', N'Control', CAST(N'2022-06-27T15:54:54.287' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1674, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T15:56:05.277' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1675, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 15, Slave License ID: 17', N'Control', CAST(N'2022-06-27T15:56:20.213' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1676, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 17', N'Control', CAST(N'2022-06-27T15:56:26.727' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1677, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 3, Slave License ID: 16', N'Control', CAST(N'2022-06-27T15:57:01.783' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1678, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 16', N'Control', CAST(N'2022-06-27T15:57:05.600' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1679, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 2, Slave License ID: 16', N'Control', CAST(N'2022-06-27T15:57:20.997' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1680, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 2, Slave License ID: 17', N'Control', CAST(N'2022-06-27T15:57:26.523' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1681, N'LICENSE_TO_LICENSEPOOL_OK', N'Account admin2 moved license to orphan license pool License ID: 17', N'Control', CAST(N'2022-06-27T15:57:29.487' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1682, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 16, Slave License ID: 17', N'Control', CAST(N'2022-06-27T15:57:34.013' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1683, N'NEW_LICENSE_ADD_OK', N'Account admin2 added a new license', N'Control', CAST(N'2022-06-27T15:57:59.070' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1684, N'NEW_LICENSE_RELATION_OK', N'Account admin2 added a new license dependency Master License ID: 16, Slave License ID: 18', N'Control', CAST(N'2022-06-27T15:58:04.147' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1685, N'LOGIN_OK', N'Account supervisor logged successfully', N'Control', CAST(N'2022-06-27T15:59:03.070' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1686, N'LOGOUT', N'Account supervisor logged out', N'Control', CAST(N'2022-06-27T16:00:46.730' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1687, N'LOGIN_OK', N'Account supervisor logged successfully', N'Control', CAST(N'2022-06-27T16:00:51.750' AS DateTime), 38)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1688, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T16:03:55.403' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1689, N'USERNAME_ERROR', N'Username already exists', N'Warning', CAST(N'2022-06-27T16:04:07.490' AS DateTime), NULL)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1690, N'USER_CREATED', N'Account agustin2 created successfully', N'Control', CAST(N'2022-06-27T16:04:12.720' AS DateTime), 39)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1691, N'USER_CREATED', N'Account florencia created successfully', N'Control', CAST(N'2022-06-27T16:04:23.387' AS DateTime), 40)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1692, N'USER_CREATED', N'Account Roberto created successfully', N'Control', CAST(N'2022-06-27T16:04:35.787' AS DateTime), 41)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1693, N'USER_CREATED', N'Account Carlos created successfully', N'Control', CAST(N'2022-06-27T16:04:53.077' AS DateTime), 42)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1694, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T16:07:53.447' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1695, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T16:12:21.307' AS DateTime), 29)
INSERT [dbo].[eventLog] ([id], [code], [description], [type], [date], [FK_account_eventLog]) VALUES (1696, N'LOGIN_OK', N'Account admin2 logged successfully', N'Control', CAST(N'2022-06-27T16:13:33.400' AS DateTime), 29)
SET IDENTITY_INSERT [dbo].[eventLog] OFF
GO
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 16)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (16, 17)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (16, 18)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 3)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (8, 2)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 12)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 13)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 14)
INSERT [dbo].[family_license] ([id_family], [id_license]) VALUES (2, 15)
GO
SET IDENTITY_INSERT [dbo].[language] ON 

INSERT [dbo].[language] ([id], [name]) VALUES (1, N'English')
INSERT [dbo].[language] ([id], [name]) VALUES (2, N'Español')
INSERT [dbo].[language] ([id], [name]) VALUES (3, N'Deutsch')
INSERT [dbo].[language] ([id], [name]) VALUES (4, N'한국어')
INSERT [dbo].[language] ([id], [name]) VALUES (5, N'hola')
SET IDENTITY_INSERT [dbo].[language] OFF
GO
SET IDENTITY_INSERT [dbo].[license] ON 

INSERT [dbo].[license] ([id], [name], [description]) VALUES (2, N'Admin', N'Admin default license')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (3, N'License management', N'Allows user to manage account licenses')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (6, N'TestLicense', N'test')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (7, N'TestTestLicense', N'testForTest')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (8, N'Super User', N'Node License - No license can be above level 0. Top level licenses must be  Level 0 child')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (9, N'OrptahLicense', N'OrphanLicenseTest')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (12, N'User management', N'Allows user to manage user accounts')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (13, N'nueva license', N'laksdjlaksjdl')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (14, N'Profile manager', N'Allows user to edit profile licenses')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (15, N'Language manager', N'Allows user to manage system languages')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (16, N'Supervisor', N'Supervisor Privileges')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (17, N'Team manager', N'Team creation privileges')
INSERT [dbo].[license] ([id], [name], [description]) VALUES (18, N'Add accounts', N'Create account privileges')
SET IDENTITY_INSERT [dbo].[license] OFF
GO
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'0281c104ff8e659f95c814a834ddcdd84ec7a0baa1852c0441d505859bda0e5c', 30, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'0834c2d60725ac5902257b3b78dd161ad26d1c0290dbf1e47cc14add5b8c8142', 38, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'18cf880444961401df6d5b09b3b0f6f662be30f34518d83822966da18cab4be5', 35, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'1b4f0e9851971998e732078544c96b36c3d01cedf7caa332359d6f1d83567014', 19, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'1f9bfeb15fee8a10c4d0711c7eb0c083962123e1918e461b6a508e7146c189b2', 27, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'25f43b1486ad95a1398e3eeb3d83bc4010015fcc9bedb35b432e00298d5021f7', 28, CAST(N'2022-06-15T19:17:00.503' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'37268335dd6931045bdcdf92623ff819a64244b53d0e746d438797349d4da578', 21, CAST(N'2022-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'3f5eaa6b1941960bfef1386936dc8c2d951fc40296bb36e7888a4ea5c985e1bd', 21, CAST(N'2022-06-15T18:52:04.903' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'5fd924625f6ab16a19cc9807c7c506ae1813490e4ba675f843d5a10e0baacdb8', 28, CAST(N'2022-06-15T19:16:37.310' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'72534c4a93ddc043fe3229ed46b1d526c4ccc747febdcd0f284f7f6057a37858', 41, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'7b85175b455060e3237e925f023053ca9515e8682a83c8b09911c724a1f8b75f', 42, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'7e6ea62ad413e64265919670246b2992f4d15ca38b994c27298b63a588dd8ba8', 31, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 28, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 29, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 31, CAST(N'2022-06-16T20:14:44.777' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 21, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 32, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'a140c0c1eda2def2b830363ba362aa4d7d255c262960544821f556e16661b6ff', 21, CAST(N'2022-06-15T19:15:10.463' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'a140c0c1eda2def2b830363ba362aa4d7d255c262960544821f556e16661b6ff', 22, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'a4e624d686e03ed2767c0abd85c14426b0b1157d2ce81d27bb4fe4f6f01d688a', 21, CAST(N'2022-06-15T18:59:37.537' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'aeddd4f60ed666e9e80e9a1faf07c116291fd350b0a314a340642892b8eccda9', 37, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'aeddd4f60ed666e9e80e9a1faf07c116291fd350b0a314a340642892b8eccda9', 39, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'b1d72f1fa5ad851f2396615b44ec031314dedb8552993613a13f0c2149e07ed6', 21, CAST(N'2022-06-15T00:00:00.000' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'bd7c911264aae15b66d4291b6850829aa96986b1d3ead34d1fdbfef27056c112', 24, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'c9affe7f758723c3eb9fe8b143520c7d3c73fa7cacdbf1a76b34e18624cc6ecf', 35, CAST(N'2022-06-26T19:34:51.587' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855', 33, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'e80b0c67e6fd0ccbeb50d914157ebc606ca470bb57f1ec704fe261091b2ac6cc', 34, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'ed0cb90bdfa4f93981a7d03cff99213a86aa96a6cbcf89ec5e8889871f088727', 23, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'edce770bb37357756ee5cff4bc6d024ac14af008c5d1670ff2dbb8de151711a9', 26, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'ee3b2b0bd449adb75d34ff6342aa196a9918aa6b0d3fbaf247ec4f34c564ea84', 36, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'efd133099a394451fd47bd63d3cfdc8aac23c719d599ee881c9a802725ba3a33', 25, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'f1b4864f64ca8fdfb99f563b8e323646522a0f640d811452343afcc42eb328d9', 40, NULL)
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'fad51e7f12ba62fa52975a4f213edd0a87785e1fb9b5ff30b2ae244b99c43294', 30, CAST(N'2022-06-15T19:57:34.323' AS DateTime))
INSERT [dbo].[passwordHash] ([passHash], [FK_account_passwordhash], [addDate]) VALUES (N'fd61a03af4f77d870fc21e05e7e80678095c92d808cfb3b5c279ee04c74aca13', 20, NULL)
GO
SET IDENTITY_INSERT [dbo].[position] ON 

INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (1, N'Developer Jr', N'3         ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (2, N'Developer Ssr', N'6         ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (3, N'Developer Sr', N'10        ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (4, N'Team Ower', N'15        ', 3)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (5, N'Product Owner', N'18        ', 3)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (6, N'Manager', N'20        ', 4)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (7, N'QA Tester Jr', N'3         ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (8, N'QA Tester Ssr', N'6         ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (9, N'QA Tester Sr', N'10        ', 2)
INSERT [dbo].[position] ([id], [name], [value], [FK_profile_position]) VALUES (10, N'Scrum Master', N'10        ', 2)
SET IDENTITY_INSERT [dbo].[position] OFF
GO
SET IDENTITY_INSERT [dbo].[profile] ON 

INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (1, N'Admin', N'System administrator', 0)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (2, N'Default', N'Default user, without administrator privileges', 0)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (3, N'Team Owner', N'Team leader position', 15)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (4, N'Supervisor', N'Business administrator', 25)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (5, N'Product Owner', N'Owner of the product, leader capabilities', 20)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (6, N'Developer Jr', N'Beginner developer', 3)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (7, N'Developer Ssr', N'Intermedia developer', 6)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (8, N'Developer Sr', N'Experienced developer', 10)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (9, N'QA Tester', N'Tests the product', 10)
INSERT [dbo].[profile] ([id], [name], [description], [value]) VALUES (10, N'Scrum Master', N'Manages agile methodologies', 10)
SET IDENTITY_INSERT [dbo].[profile] OFF
GO
INSERT [dbo].[profile_license] ([id_profile], [id_license]) VALUES (1, 2)
INSERT [dbo].[profile_license] ([id_profile], [id_license]) VALUES (1, 8)
INSERT [dbo].[profile_license] ([id_profile], [id_license]) VALUES (4, 16)
GO
SET IDENTITY_INSERT [dbo].[skills] ON 

INSERT [dbo].[skills] ([id], [name], [value]) VALUES (1, N'JavaScript Sr Developer', 10)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (3, N'JavaScript Ssr Developer', 6)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (4, N'JavaScript Jr Developer', 3)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (5, N'Java Sr Developer', 10)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (6, N'Java Ssr Developer', 6)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (7, N'Java Jr Developer', 3)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (8, N'Git Control', 3)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (9, N'Web Design Sr', 10)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (10, N'Web Design Ssr', 6)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (11, N'Web Design Jr', 3)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (12, N'Unit Testing', 10)
INSERT [dbo].[skills] ([id], [name], [value]) VALUES (13, N'SQL Server', 6)
SET IDENTITY_INSERT [dbo].[skills] OFF
GO
SET IDENTITY_INSERT [dbo].[team] ON 

INSERT [dbo].[team] ([id], [name], [value]) VALUES (1, N'Test', 1)
INSERT [dbo].[team] ([id], [name], [value]) VALUES (2, N'Test2', 1)
INSERT [dbo].[team] ([id], [name], [value]) VALUES (3, N'test3', 1)
SET IDENTITY_INSERT [dbo].[team] OFF
GO
SET IDENTITY_INSERT [dbo].[words] ON 

INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (1, N'Login', N'Login', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (2, N'Login', N'Iniciar Sesión', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (3, N'Register', N'Register', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (4, N'Logout', N'Logout', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (5, N'Register', N'Registrarse', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (6, N'Logout', N'Cerrar Sesion', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (7, N'Login', N'Anmeldung', 3)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (8, N'Logout', N'Ausloggen', 3)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (9, N'Register', N'Registrieren', 3)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (11, N'Login', N'로그인', 4)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (12, N'Logout', N'끝', 4)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (13, N'Register', N'등록하다', 4)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (14, N'Add', N'Add', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (15, N'Remove', N'Remove', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (16, N'LicenseId', N'License ID', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (17, N'LicenseName', N'License Name', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (18, N'LicenseDesc', N'License Descript', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (19, N'LicenseList', N'License List', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (20, N'LicensePoolList', N'License Pool List', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (21, N'Add', N'Agregar', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (22, N'Remove', N'Eliminar', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (23, N'LicenseId', N'Id de licencia:', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (24, N'LicenseName', N'Nombre de licencia:', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (25, N'LicenseDesc', N'Descr. de  licencia:', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (26, N'LicenseList', N'Lista de licencias', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (27, N'LicensePoolList', N'Reserva de Licencias', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (28, N'Block', N'Block', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (29, N'Unblock', N'Unblock', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (30, N'UserList', N'User list', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (31, N'Block', N'Bloquear', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (32, N'Unblock', N'Desbloquear', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (33, N'UserList', N'Lista de usuarios', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (34, N'UserProfileList', N'User profile list', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (35, N'UserProfileList', N'Lista de perfiles de usuario', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (36, N'ProfileList', N'Profile List', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (37, N'ProfileList', N'Lista de perfiles', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (38, N'Password', N'Password', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (39, N'Password', N'Contraseña', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (40, N'PasswordConfirm', N'Confirmation', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (41, N'PasswordConfirm', N'Confirmacion', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (42, N'Accept', N'Accept', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (43, N'Accept', N'Aceptar', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (44, N'LoadWords', N'Load Words', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (45, N'LoadWords', N'Cargar', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (47, N'AddLanguage', N'Add new language:', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (48, N'AddLanguage', N'Agregar nuevo idioma:', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (49, N'ChooseLanguage', N'Choose a language:', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (50, N'ChooseLanguage', N'Elija un idioma:', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (52, N'ShowPassword', N'Show Password', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (53, N'ShowPassword', N'Mostrar Contraseña', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (55, N'Main', N'Main', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (56, N'Main', N'Principal', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (57, N'Confirmation', N'Are you sure?', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (58, N'Confirmation', N'¿Estás seguro?', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (59, N'Confirm', N'Confirm', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (60, N'Confirm', N'Confirmar', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (61, N'Profile', N'Profile', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (62, N'Profile', N'Perfil', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (63, N'Administrator', N'Administrator', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (64, N'Administrator', N'Administrador', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (65, N'ChangePassword', N'Change password', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (66, N'ChangePassword', N'Cambiar Contraseña', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (67, N'LanguageEditor', N'Language Editor', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (68, N'LanguageEditor', N'Editor de Lenguajes', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (69, N'ProfileManager', N'Profile Manager', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (70, N'ProfileManager', N'Gestor de Perfiles', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (71, N'LicenseManager', N'License Manager', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (72, N'LicenseManager', N'Gestor de Licencias', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (73, N'UserManager', N'User Manager', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (74, N'UserManager', N'Gestor de Usuarios', 2)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (75, N'Information', N'Information', 1)
INSERT [dbo].[words] ([id], [tag], [word], [FK_language_words]) VALUES (76, N'Information', N'Información', 2)
SET IDENTITY_INSERT [dbo].[words] OFF
GO
ALTER TABLE [dbo].[profile] ADD  DEFAULT ((0)) FOR [value]
GO
ALTER TABLE [dbo].[account]  WITH CHECK ADD  CONSTRAINT [FK_account_language] FOREIGN KEY([FK_language_account])
REFERENCES [dbo].[language] ([id])
GO
ALTER TABLE [dbo].[account] CHECK CONSTRAINT [FK_account_language]
GO
ALTER TABLE [dbo].[account_profile]  WITH CHECK ADD  CONSTRAINT [FK_account_profile_account] FOREIGN KEY([id_account])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account_profile] CHECK CONSTRAINT [FK_account_profile_account]
GO
ALTER TABLE [dbo].[account_profile]  WITH CHECK ADD  CONSTRAINT [FK_account_profile_profile] FOREIGN KEY([id_profile])
REFERENCES [dbo].[profile] ([id])
GO
ALTER TABLE [dbo].[account_profile] CHECK CONSTRAINT [FK_account_profile_profile]
GO
ALTER TABLE [dbo].[account_skills]  WITH CHECK ADD  CONSTRAINT [FK_account_skills_account] FOREIGN KEY([id_account])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account_skills] CHECK CONSTRAINT [FK_account_skills_account]
GO
ALTER TABLE [dbo].[account_skills]  WITH CHECK ADD  CONSTRAINT [FK_account_skills_skills] FOREIGN KEY([id_skills])
REFERENCES [dbo].[skills] ([id])
GO
ALTER TABLE [dbo].[account_skills] CHECK CONSTRAINT [FK_account_skills_skills]
GO
ALTER TABLE [dbo].[account_team]  WITH CHECK ADD  CONSTRAINT [FK_account_team_account] FOREIGN KEY([id_account])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[account_team] CHECK CONSTRAINT [FK_account_team_account]
GO
ALTER TABLE [dbo].[account_team]  WITH CHECK ADD  CONSTRAINT [FK_account_team_team] FOREIGN KEY([id_team])
REFERENCES [dbo].[team] ([id])
GO
ALTER TABLE [dbo].[account_team] CHECK CONSTRAINT [FK_account_team_team]
GO
ALTER TABLE [dbo].[accountStatus]  WITH CHECK ADD  CONSTRAINT [FK_accountStatus_account] FOREIGN KEY([FK_account_accountstatus])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[accountStatus] CHECK CONSTRAINT [FK_accountStatus_account]
GO
ALTER TABLE [dbo].[achievement]  WITH CHECK ADD  CONSTRAINT [FK_achievement_account] FOREIGN KEY([FK_sender_achievement])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[achievement] CHECK CONSTRAINT [FK_achievement_account]
GO
ALTER TABLE [dbo].[achievement]  WITH CHECK ADD  CONSTRAINT [FK_achievement_account1] FOREIGN KEY([FK_receiver_achievement])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[achievement] CHECK CONSTRAINT [FK_achievement_account1]
GO
ALTER TABLE [dbo].[eventLog]  WITH CHECK ADD  CONSTRAINT [FK_eventLog_account] FOREIGN KEY([FK_account_eventLog])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[eventLog] CHECK CONSTRAINT [FK_eventLog_account]
GO
ALTER TABLE [dbo].[family_license]  WITH CHECK ADD  CONSTRAINT [FK_family_license_license] FOREIGN KEY([id_family])
REFERENCES [dbo].[license] ([id])
GO
ALTER TABLE [dbo].[family_license] CHECK CONSTRAINT [FK_family_license_license]
GO
ALTER TABLE [dbo].[family_license]  WITH CHECK ADD  CONSTRAINT [FK_family_license_license1] FOREIGN KEY([id_license])
REFERENCES [dbo].[license] ([id])
GO
ALTER TABLE [dbo].[family_license] CHECK CONSTRAINT [FK_family_license_license1]
GO
ALTER TABLE [dbo].[passwordHash]  WITH CHECK ADD  CONSTRAINT [FK_passwordHash_account] FOREIGN KEY([FK_account_passwordhash])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[passwordHash] CHECK CONSTRAINT [FK_passwordHash_account]
GO
ALTER TABLE [dbo].[profile_license]  WITH CHECK ADD  CONSTRAINT [FK_profile_license_license] FOREIGN KEY([id_license])
REFERENCES [dbo].[license] ([id])
GO
ALTER TABLE [dbo].[profile_license] CHECK CONSTRAINT [FK_profile_license_license]
GO
ALTER TABLE [dbo].[profile_license]  WITH CHECK ADD  CONSTRAINT [FK_profile_license_profile] FOREIGN KEY([id_profile])
REFERENCES [dbo].[profile] ([id])
GO
ALTER TABLE [dbo].[profile_license] CHECK CONSTRAINT [FK_profile_license_profile]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_account] FOREIGN KEY([FK_account_task])
REFERENCES [dbo].[account] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_account]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_epic] FOREIGN KEY([FK_epic_task])
REFERENCES [dbo].[epic] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_epic]
GO
ALTER TABLE [dbo].[task]  WITH CHECK ADD  CONSTRAINT [FK_task_team] FOREIGN KEY([FK_team_task])
REFERENCES [dbo].[team] ([id])
GO
ALTER TABLE [dbo].[task] CHECK CONSTRAINT [FK_task_team]
GO
ALTER TABLE [dbo].[words]  WITH CHECK ADD  CONSTRAINT [FK_words_language] FOREIGN KEY([FK_language_words])
REFERENCES [dbo].[language] ([id])
GO
ALTER TABLE [dbo].[words] CHECK CONSTRAINT [FK_words_language]
GO
USE [master]
GO
ALTER DATABASE [Campo] SET  READ_WRITE 
GO
