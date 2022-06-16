USE [Campo]
GO
/****** Object:  Table [dbo].[passwordTable]    Script Date: 30/04/2022 17:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[passwordTable](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[passHash] [nchar](100) NOT NULL,
 CONSTRAINT [PK_passwordTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userStatusTable]    Script Date: 30/04/2022 17:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userStatusTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isBlocked] [bit] NOT NULL,
	[attempts] [int] NOT NULL,
 CONSTRAINT [PK_userStatusTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userTable]    Script Date: 30/04/2022 17:58:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userTable](
	[id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[userName] [nchar](50) NOT NULL,
	[email] [nchar](50) NOT NULL,
 CONSTRAINT [PK_userTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[passwordTable]  WITH CHECK ADD  CONSTRAINT [FK_passwordTable_userTable] FOREIGN KEY([id])
REFERENCES [dbo].[userTable] ([id])
GO
ALTER TABLE [dbo].[passwordTable] CHECK CONSTRAINT [FK_passwordTable_userTable]
GO
ALTER TABLE [dbo].[userStatusTable]  WITH CHECK ADD  CONSTRAINT [FK_userStatusTable_userTable] FOREIGN KEY([id])
REFERENCES [dbo].[userTable] ([id])
GO
ALTER TABLE [dbo].[userStatusTable] CHECK CONSTRAINT [FK_userStatusTable_userTable]
GO
