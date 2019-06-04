USE [WebApiAngularSPA]
GO
/****** Object:  StoredProcedure [dbo].[P_UpdateUser]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_UpdateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_UpdateUser]
GO
/****** Object:  StoredProcedure [dbo].[P_UpdateFileDetailsAfterEncryption]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_UpdateFileDetailsAfterEncryption]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_UpdateFileDetailsAfterEncryption]
GO
/****** Object:  StoredProcedure [dbo].[P_SaveFileDetailsForEncryption]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_SaveFileDetailsForEncryption]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_SaveFileDetailsForEncryption]
GO
/****** Object:  StoredProcedure [dbo].[P_SaveFileDecryptionHistory]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_SaveFileDecryptionHistory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_SaveFileDecryptionHistory]
GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_RegisterUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_RegisterUser]
GO
/****** Object:  StoredProcedure [dbo].[P_ModifyUserRoles]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_ModifyUserRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_ModifyUserRoles]
GO
/****** Object:  StoredProcedure [dbo].[P_GetUsers]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetUsers]
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserRoles]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUserRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetUserRoles]
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserDetailsForAuth]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUserDetailsForAuth]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetUserDetailsForAuth]
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserDetailsByUserName]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetUserDetailsByUserName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetUserDetailsByUserName]
GO
/****** Object:  StoredProcedure [dbo].[P_GetEncryptedFileDownloadHistory]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_GetEncryptedFileDownloadHistory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_GetEncryptedFileDownloadHistory]
GO
/****** Object:  StoredProcedure [dbo].[P_DeleteUser]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_DeleteUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_DeleteUser]
GO
/****** Object:  StoredProcedure [dbo].[P_DeleteEncryptedFile]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[P_DeleteEncryptedFile]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[P_DeleteEncryptedFile]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_LogError]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ELMAH_LogError]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_GetErrorXml]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ELMAH_GetErrorXml]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_GetErrorsXml]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ELMAH_GetErrorsXml]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserRoles_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserRoles]'))
ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Roles]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FileCryptDownLoadHistory_FileCrypt]') AND parent_object_id = OBJECT_ID(N'[dbo].[FileCryptDownLoadHistory]'))
ALTER TABLE [dbo].[FileCryptDownLoadHistory] DROP CONSTRAINT [FK_FileCryptDownLoadHistory_FileCrypt]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ELMAH_Error_ErrorId]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ELMAH_Error] DROP CONSTRAINT [DF_ELMAH_Error_ErrorId]
END
GO
/****** Object:  Index [PK_ELMAH_Error]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_Error]') AND name = N'PK_ELMAH_Error')
ALTER TABLE [dbo].[ELMAH_Error] DROP CONSTRAINT [PK_ELMAH_Error]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoles]') AND type in (N'U'))
DROP TABLE [dbo].[UserRoles]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U'))
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[RoleAssetMapping]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RoleAssetMapping]') AND type in (N'U'))
DROP TABLE [dbo].[RoleAssetMapping]
GO
/****** Object:  Table [dbo].[LogAspNetCoreWebApi]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogAspNetCoreWebApi]') AND type in (N'U'))
DROP TABLE [dbo].[LogAspNetCoreWebApi]
GO
/****** Object:  Table [dbo].[FileCryptDownLoadHistory]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileCryptDownLoadHistory]') AND type in (N'U'))
DROP TABLE [dbo].[FileCryptDownLoadHistory]
GO
/****** Object:  Table [dbo].[FileCrypt]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FileCrypt]') AND type in (N'U'))
DROP TABLE [dbo].[FileCrypt]
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ELMAH_Error]') AND type in (N'U'))
DROP TABLE [dbo].[ELMAH_Error]
GO
/****** Object:  UserDefinedTableType [dbo].[T_ModifyUserRoles]    Script Date: 04-06-2019 09:18:29 ******/
IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id WHERE st.name = N'T_ModifyUserRoles' AND ss.name = N'dbo')
DROP TYPE [dbo].[T_ModifyUserRoles]
GO
/****** Object:  UserDefinedTableType [dbo].[T_ModifyUserRoles]    Script Date: 04-06-2019 09:18:29 ******/
CREATE TYPE [dbo].[T_ModifyUserRoles] AS TABLE(
	[UserRoleId] [int] NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
	[RoleName] [nvarchar](max) NULL,
	[IsActive] [bit] NULL
)
GO
/****** Object:  Table [dbo].[ELMAH_Error]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ELMAH_Error](
	[ErrorId] [uniqueidentifier] NOT NULL,
	[Application] [nvarchar](60) NOT NULL,
	[TraceIdentifier] [nvarchar](100) NULL,
	[Host] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](60) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[User] [nvarchar](50) NOT NULL,
	[StatusCode] [int] NOT NULL,
	[TimeUtc] [datetime] NOT NULL,
	[Sequence] [int] IDENTITY(1,1) NOT NULL,
	[AllXml] [ntext] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileCrypt]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileCrypt](
	[FileCryptId] [bigint] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[EncryptedFileName] [nvarchar](max) NULL,
	[EncryptedFilePath] [nvarchar](max) NULL,
	[EncryptedFileFullPath] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.FileCrypt] PRIMARY KEY CLUSTERED 
(
	[FileCryptId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileCryptDownLoadHistory]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileCryptDownLoadHistory](
	[FileCryptDownLoadHistoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[FileCryptId] [bigint] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.FileCryptDownLoadHistory] PRIMARY KEY CLUSTERED 
(
	[FileCryptDownLoadHistoryId] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogAspNetCoreWebApi]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogAspNetCoreWebApi](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Application] [nvarchar](500) NOT NULL,
	[TraceIdentifier] [nvarchar](500) NOT NULL,
	[Logged] [datetime] NOT NULL,
	[Level] [nvarchar](50) NOT NULL,
	[RequestIPAddress] [nvarchar](500) NOT NULL,
	[Url] [nvarchar](200) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Logger] [nvarchar](250) NULL,
	[Callsite] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED 
(
	[Id] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAssetMapping]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAssetMapping](
	[AssetId] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [nvarchar](500) NOT NULL,
	[AssetType] [nvarchar](500) NOT NULL,
	[ScreenName] [nvarchar](500) NOT NULL,
	[AssetFileFullPath] [nvarchar](max) NOT NULL,
	[AssetFileFullName] [nvarchar](500) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsActiveForSuperUser] [int] NOT NULL,
	[IsActiveForAdmin] [int] NOT NULL,
	[IsActiveForManager] [int] NOT NULL,
	[IsActiveForUser] [int] NULL,
 CONSTRAINT [PK_dbo.RoleAssetMapping] PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC,
	[IsActive] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](500) NULL,
	[PasswordSalt] [nvarchar](100) NULL,
	[IsActive] [bit] NULL,
	[IsLocked] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[RoleName] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [bigint] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [bigint] NULL,
 CONSTRAINT [PK_dbo.UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC,
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleAssetMapping] ON 
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForSuperUser], [IsActiveForAdmin], [IsActiveForManager], [IsActiveForUser]) VALUES (1, N'UserManagement', N'View', N'UserManagement', N'Area\Admin\Views\Admin\', N'Index.cshtml', 1, 1, 0, 0, 0)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForSuperUser], [IsActiveForAdmin], [IsActiveForManager], [IsActiveForUser]) VALUES (4, N'Home', N'View', N'Home', N'View\Home\Index.cshtml', N'Index.cshtm', 1, 1, 1, 1, 1)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForSuperUser], [IsActiveForAdmin], [IsActiveForManager], [IsActiveForUser]) VALUES (5, N'Screen1', N'View', N'Screen1', N'123', N'Index.cshtml', 1, 1, 1, 0, 1)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForSuperUser], [IsActiveForAdmin], [IsActiveForManager], [IsActiveForUser]) VALUES (6, N'Screen2', N'View', N'Screen2', N'Screen2', N'Screen2', 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[RoleAssetMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'SuperUser')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Manager')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (4, N'User')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, N'SystemUserCreator', NULL, NULL, NULL, NULL, N'', NULL, NULL, 0, 1, CAST(N'2019-05-12T10:39:02.797' AS DateTime), NULL, CAST(N'2019-05-12T10:39:02.797' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10014, N'localhost:44396', NULL, NULL, NULL, NULL, N'localhost:44396', NULL, NULL, 1, 0, CAST(N'2019-05-20T23:05:46.897' AS DateTime), NULL, CAST(N'2019-05-20T23:05:46.897' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10015, N'RegisterUser', NULL, NULL, NULL, NULL, N'RegisterUser', NULL, NULL, 1, 0, CAST(N'2019-05-20T23:16:14.950' AS DateTime), NULL, CAST(N'2019-05-20T23:16:14.950' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10016, N'localhost', N'First Name Last Name', N'First Name', N'Last Name', N'Email', N'localhost', NULL, NULL, 1, 0, CAST(N'2019-05-20T23:40:46.817' AS DateTime), NULL, CAST(N'2019-05-20T23:40:46.817' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10017, N'localhostuser', N'localhostuser localhostuser', N'localhostuser', N'localhostuser', N'localhostuser', N'localhostuser', NULL, NULL, 1, 0, CAST(N'2019-05-20T23:42:23.977' AS DateTime), NULL, CAST(N'2019-05-20T23:42:23.977' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10018, N'localhostmanager', N'Manger MGR', N'Manger', N'MGR', N'satee', N'localhostmanager', NULL, NULL, 1, 0, CAST(N'2019-05-22T09:07:16.363' AS DateTime), NULL, CAST(N'2019-05-22T09:07:16.363' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10019, N'localhostadmin', N'localhostadmin localhostadmin', N'localhostadmin', N'localhostadmin', N'localhostadmin', N'localhostadmin', NULL, NULL, 1, 0, CAST(N'2019-05-22T23:57:07.733' AS DateTime), NULL, CAST(N'2019-05-23T00:09:05.463' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10021, N'UserManagement', N'UserManagement UserManagement', N'UserManagement', N'UserManagement', N'UserManagement', N'UserManagement', NULL, NULL, 1, 0, CAST(N'2019-05-23T22:57:05.343' AS DateTime), NULL, CAST(N'2019-05-23T22:57:05.343' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10022, N'KeerthiRaja', N'Keerthi Raja P123', N'Keerthi Raja', N'P123', N'string', N'string', NULL, NULL, 1, 0, CAST(N'2019-05-26T22:19:26.750' AS DateTime), NULL, CAST(N'2019-05-26T22:19:26.750' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10023, N'string', NULL, NULL, NULL, NULL, N'string', NULL, NULL, 1, 0, CAST(N'2019-06-02T13:22:03.523' AS DateTime), NULL, CAST(N'2019-06-02T13:22:03.523' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10024, N'string1', NULL, NULL, NULL, NULL, N'string', NULL, NULL, 1, 0, CAST(N'2019-06-02T13:22:14.333' AS DateTime), NULL, CAST(N'2019-06-02T13:22:14.333' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10025, N'sdvsdv', NULL, NULL, NULL, NULL, N'sdvsdv', NULL, NULL, 1, 0, CAST(N'2019-06-02T13:22:48.217' AS DateTime), NULL, CAST(N'2019-06-02T13:22:48.217' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10026, N'Register', NULL, NULL, NULL, NULL, N'Register', NULL, NULL, 1, 0, CAST(N'2019-06-02T13:26:55.563' AS DateTime), NULL, CAST(N'2019-06-02T13:26:55.563' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10027, N'string1string1', NULL, NULL, NULL, NULL, N'string1string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T13:49:06.287' AS DateTime), NULL, CAST(N'2019-06-02T13:49:06.287' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10028, N'string1111', NULL, NULL, NULL, NULL, N'string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T14:00:38.103' AS DateTime), NULL, CAST(N'2019-06-02T14:00:38.103' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10029, N'string122', NULL, NULL, NULL, NULL, N'string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T14:01:51.480' AS DateTime), NULL, CAST(N'2019-06-02T14:01:51.480' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10030, N'string144', NULL, NULL, NULL, NULL, N'string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T14:03:55.490' AS DateTime), NULL, CAST(N'2019-06-02T14:03:55.490' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10031, N'stringccc', NULL, NULL, NULL, NULL, N'string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T20:24:49.613' AS DateTime), NULL, CAST(N'2019-06-02T20:24:49.613' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10032, N'localhost dq', NULL, NULL, NULL, NULL, N'localhost', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10033, N'localhost dq', NULL, NULL, NULL, NULL, N'localhost', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10034, N'string1wwww', NULL, NULL, NULL, NULL, N'string1', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:20:20.853' AS DateTime), NULL, CAST(N'2019-06-02T22:20:20.853' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10035, N'string1yy', NULL, NULL, NULL, NULL, N'string', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:20:39.360' AS DateTime), NULL, CAST(N'2019-06-02T22:20:39.360' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10036, N'string1yystring1yy', NULL, NULL, NULL, NULL, N'string1yy', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:29:43.383' AS DateTime), NULL, CAST(N'2019-06-02T22:29:43.383' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10037, N'string1yyc', NULL, NULL, NULL, NULL, N'string1yy', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:30:15.213' AS DateTime), NULL, CAST(N'2019-06-02T22:30:15.213' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10038, N'string1yystring1yys', NULL, NULL, NULL, NULL, N'string1yy', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:31:41.827' AS DateTime), NULL, CAST(N'2019-06-02T22:31:41.827' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10039, N'IsUserAuthenticated', NULL, NULL, NULL, NULL, N'IsUserAuthenticated', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:33:06.993' AS DateTime), NULL, CAST(N'2019-06-02T22:33:06.993' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10040, N'IsUserAccountLocked', NULL, NULL, NULL, NULL, N'IsUserAccountLocked', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:34:40.853' AS DateTime), NULL, CAST(N'2019-06-02T22:34:40.853' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10041, N'asfasafd', NULL, NULL, NULL, NULL, N'adsfasdf', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:36:53.593' AS DateTime), NULL, CAST(N'2019-06-02T22:36:53.593' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10042, N'ExpiresOn', NULL, NULL, NULL, NULL, N'ExpiresOn', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:37:24.013' AS DateTime), NULL, CAST(N'2019-06-02T22:37:24.013' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10043, N'DidValidationError', NULL, NULL, NULL, NULL, N'DidValidationError', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:38:10.673' AS DateTime), NULL, CAST(N'2019-06-02T22:38:10.673' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10044, N'ErrorMessage', NULL, NULL, NULL, NULL, N'ErrorMessage', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:39:14.200' AS DateTime), NULL, CAST(N'2019-06-02T22:39:14.200' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10045, N'successfully', NULL, NULL, NULL, NULL, N'successfully', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:40:39.193' AS DateTime), NULL, CAST(N'2019-06-02T22:40:39.193' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10046, N'Redirecting', NULL, NULL, NULL, NULL, N'Redirecting', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:42:59.093' AS DateTime), NULL, CAST(N'2019-06-02T22:42:59.093' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10047, N'screen', NULL, NULL, NULL, NULL, N'screen', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:46:15.130' AS DateTime), NULL, CAST(N'2019-06-02T22:46:15.130' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10048, N'Authentication', NULL, NULL, NULL, NULL, N'Authentication', NULL, NULL, 1, 0, CAST(N'2019-06-02T22:48:50.107' AS DateTime), NULL, CAST(N'2019-06-02T22:48:50.107' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10049, N'Bootstrap', NULL, NULL, NULL, NULL, N'Bootstrap', NULL, NULL, 1, 0, CAST(N'2019-06-02T23:00:21.300' AS DateTime), NULL, CAST(N'2019-06-02T23:00:21.300' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10050, N'heading', NULL, NULL, NULL, NULL, N'heading', NULL, NULL, 1, 0, CAST(N'2019-06-02T23:00:57.507' AS DateTime), NULL, CAST(N'2019-06-02T23:00:57.507' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10051, N'localhosts', NULL, NULL, NULL, NULL, N'localhosts', NULL, NULL, 1, 0, CAST(N'2019-06-02T23:40:01.653' AS DateTime), NULL, CAST(N'2019-06-02T23:40:01.653' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10052, N'blockquote', NULL, NULL, NULL, NULL, N'blockquote', NULL, NULL, 1, 0, CAST(N'2019-06-02T23:40:41.810' AS DateTime), NULL, CAST(N'2019-06-02T23:40:41.810' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10053, N'localhostff', NULL, NULL, NULL, NULL, N'localhostff', NULL, NULL, 1, 0, CAST(N'2019-06-02T23:51:05.677' AS DateTime), NULL, CAST(N'2019-06-02T23:51:05.677' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1147, 10014, 1, N'SuperUser', 1, CAST(N'2019-05-20T23:05:46.897' AS DateTime), NULL, CAST(N'2019-05-20T23:05:46.897' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1148, 10015, 4, N'User', 1, CAST(N'2019-05-20T23:16:14.950' AS DateTime), NULL, CAST(N'2019-05-20T23:16:14.950' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1149, 10016, 4, N'User', 1, CAST(N'2019-05-20T23:40:46.817' AS DateTime), NULL, CAST(N'2019-05-20T23:40:46.817' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1150, 10016, 1, N'SuperUser', 1, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1151, 10016, 2, N'Admin', 1, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1152, 10016, 3, N'Manager', 1, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL, CAST(N'2019-05-20T23:40:57.003' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1153, 10017, 4, N'User', 1, CAST(N'2019-05-20T23:42:23.977' AS DateTime), NULL, CAST(N'2019-05-20T23:42:23.977' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1154, 10018, 4, N'User', 1, CAST(N'2019-05-22T09:07:16.363' AS DateTime), NULL, CAST(N'2019-05-22T09:07:16.363' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1155, 10018, 3, N'Manager', 1, CAST(N'2019-05-22T09:07:29.393' AS DateTime), NULL, CAST(N'2019-05-22T09:07:29.393' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1156, 10019, 4, N'User', 0, CAST(N'2019-05-22T23:57:07.733' AS DateTime), NULL, CAST(N'2019-05-23T00:08:56.880' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1157, 10019, 2, N'Admin', 1, CAST(N'2019-05-23T00:08:56.880' AS DateTime), NULL, CAST(N'2019-05-23T00:12:58.180' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1158, 10020, 4, N'User', 1, CAST(N'2019-05-23T22:56:13.220' AS DateTime), NULL, CAST(N'2019-05-23T22:56:13.220' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1159, 10020, 1, N'SuperUser', 1, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1160, 10020, 2, N'Admin', 1, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1161, 10020, 3, N'Manager', 1, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL, CAST(N'2019-05-23T22:56:22.913' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1162, 10021, 4, N'User', 1, CAST(N'2019-05-23T22:57:05.343' AS DateTime), NULL, CAST(N'2019-05-23T22:57:05.343' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1163, 10022, 4, N'User', 1, CAST(N'2019-05-26T22:19:26.750' AS DateTime), NULL, CAST(N'2019-05-26T22:19:26.750' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1164, 10023, 4, N'User', 1, CAST(N'2019-06-02T13:22:03.523' AS DateTime), NULL, CAST(N'2019-06-02T13:22:03.523' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1165, 10024, 4, N'User', 1, CAST(N'2019-06-02T13:22:14.333' AS DateTime), NULL, CAST(N'2019-06-02T13:22:14.333' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1166, 10025, 4, N'User', 1, CAST(N'2019-06-02T13:22:48.217' AS DateTime), NULL, CAST(N'2019-06-02T13:22:48.217' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1167, 10026, 4, N'User', 1, CAST(N'2019-06-02T13:26:55.563' AS DateTime), NULL, CAST(N'2019-06-02T13:26:55.563' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1168, 10027, 4, N'User', 1, CAST(N'2019-06-02T13:49:06.287' AS DateTime), NULL, CAST(N'2019-06-02T13:49:06.287' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1169, 10028, 4, N'User', 1, CAST(N'2019-06-02T14:00:38.103' AS DateTime), NULL, CAST(N'2019-06-02T14:00:38.103' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1170, 10029, 4, N'User', 1, CAST(N'2019-06-02T14:01:51.480' AS DateTime), NULL, CAST(N'2019-06-02T14:01:51.480' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1171, 10030, 4, N'User', 1, CAST(N'2019-06-02T14:03:55.490' AS DateTime), NULL, CAST(N'2019-06-02T14:03:55.490' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1172, 10031, 4, N'User', 1, CAST(N'2019-06-02T20:24:49.613' AS DateTime), NULL, CAST(N'2019-06-02T20:24:49.613' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1173, 10032, 4, N'User', 1, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1174, 10033, 4, N'User', 1, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL, CAST(N'2019-06-02T22:12:57.663' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1175, 10034, 4, N'User', 1, CAST(N'2019-06-02T22:20:20.853' AS DateTime), NULL, CAST(N'2019-06-02T22:20:20.853' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1176, 10035, 4, N'User', 1, CAST(N'2019-06-02T22:20:39.360' AS DateTime), NULL, CAST(N'2019-06-02T22:20:39.360' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1177, 10036, 4, N'User', 1, CAST(N'2019-06-02T22:29:43.383' AS DateTime), NULL, CAST(N'2019-06-02T22:29:43.383' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1178, 10037, 4, N'User', 1, CAST(N'2019-06-02T22:30:15.213' AS DateTime), NULL, CAST(N'2019-06-02T22:30:15.213' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1179, 10038, 4, N'User', 1, CAST(N'2019-06-02T22:31:41.827' AS DateTime), NULL, CAST(N'2019-06-02T22:31:41.827' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1180, 10039, 4, N'User', 1, CAST(N'2019-06-02T22:33:06.993' AS DateTime), NULL, CAST(N'2019-06-02T22:33:06.993' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1181, 10040, 4, N'User', 1, CAST(N'2019-06-02T22:34:40.853' AS DateTime), NULL, CAST(N'2019-06-02T22:34:40.853' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1182, 10041, 4, N'User', 1, CAST(N'2019-06-02T22:36:53.593' AS DateTime), NULL, CAST(N'2019-06-02T22:36:53.593' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1183, 10042, 4, N'User', 1, CAST(N'2019-06-02T22:37:24.013' AS DateTime), NULL, CAST(N'2019-06-02T22:37:24.013' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1184, 10043, 4, N'User', 1, CAST(N'2019-06-02T22:38:10.673' AS DateTime), NULL, CAST(N'2019-06-02T22:38:10.673' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1185, 10044, 4, N'User', 1, CAST(N'2019-06-02T22:39:14.200' AS DateTime), NULL, CAST(N'2019-06-02T22:39:14.200' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1186, 10045, 4, N'User', 1, CAST(N'2019-06-02T22:40:39.193' AS DateTime), NULL, CAST(N'2019-06-02T22:40:39.193' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1187, 10046, 4, N'User', 1, CAST(N'2019-06-02T22:42:59.093' AS DateTime), NULL, CAST(N'2019-06-02T22:42:59.093' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1188, 10047, 4, N'User', 1, CAST(N'2019-06-02T22:46:15.130' AS DateTime), NULL, CAST(N'2019-06-02T22:46:15.130' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1189, 10048, 4, N'User', 1, CAST(N'2019-06-02T22:48:50.107' AS DateTime), NULL, CAST(N'2019-06-02T22:48:50.107' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1190, 10049, 4, N'User', 1, CAST(N'2019-06-02T23:00:21.300' AS DateTime), NULL, CAST(N'2019-06-02T23:00:21.300' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1191, 10050, 4, N'User', 1, CAST(N'2019-06-02T23:00:57.507' AS DateTime), NULL, CAST(N'2019-06-02T23:00:57.507' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1192, 10051, 4, N'User', 1, CAST(N'2019-06-02T23:40:01.653' AS DateTime), NULL, CAST(N'2019-06-02T23:40:01.653' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1193, 10052, 4, N'User', 1, CAST(N'2019-06-02T23:40:41.810' AS DateTime), NULL, CAST(N'2019-06-02T23:40:41.810' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1194, 10053, 4, N'User', 1, CAST(N'2019-06-02T23:51:05.677' AS DateTime), NULL, CAST(N'2019-06-02T23:51:05.677' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
/****** Object:  Index [PK_ELMAH_Error]    Script Date: 04-06-2019 09:18:30 ******/
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [PK_ELMAH_Error] PRIMARY KEY NONCLUSTERED 
(
	[Sequence] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ELMAH_Error] ADD  CONSTRAINT [DF_ELMAH_Error_ErrorId]  DEFAULT (newid()) FOR [ErrorId]
GO
ALTER TABLE [dbo].[FileCryptDownLoadHistory]  WITH CHECK ADD  CONSTRAINT [FK_FileCryptDownLoadHistory_FileCrypt] FOREIGN KEY([FileCryptId])
REFERENCES [dbo].[FileCrypt] ([FileCryptId])
GO
ALTER TABLE [dbo].[FileCryptDownLoadHistory] CHECK CONSTRAINT [FK_FileCryptDownLoadHistory_FileCrypt]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles]
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorsXml]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELMAH_GetErrorsXml]
(@Application NVARCHAR(60), 
 @PageIndex   INT          = 0, 
 @PageSize    INT          = 15, 
 @TotalCount  INT OUTPUT
)
AS
     SET NOCOUNT ON;
     DECLARE @FirstTimeUTC DATETIME;
     DECLARE @FirstSequence INT;
     DECLARE @StartRow INT;
     DECLARE @StartRowIndex INT;
     SELECT @TotalCount = COUNT(1)
     FROM [ELMAH_Error]
     WHERE [Application] = @Application;

     -- Get the ID of the first error for the requested page

     SET @StartRowIndex = @PageIndex * @PageSize + 1;
     IF @StartRowIndex <= @TotalCount
         BEGIN
             SET ROWCOUNT @StartRowIndex;
             SELECT @FirstTimeUTC = [TimeUtc], 
                    @FirstSequence = [Sequence]
             FROM [ELMAH_Error]
             WHERE [Application] = @Application
             ORDER BY [TimeUtc] DESC, 
                      [Sequence] DESC;
     END;
         ELSE
         BEGIN
             SET @PageSize = 0;
     END;

     -- Now set the row count to the requested page size and get
     -- all records below it for the pertaining application.

     SET ROWCOUNT @PageSize;
     SELECT errorId = [ErrorId], 
            application = [Application], 
            host = [Host], 
            type = [Type], 
            source = [Source], 
            message = [Message], 
            [user] = [User], 
            statusCode = [StatusCode], 
            time = CONVERT(VARCHAR(50), [TimeUtc], 126) + 'Z'
     FROM [ELMAH_Error] error
     WHERE [Application] = @Application
           AND [TimeUtc] <= @FirstTimeUTC
           AND [Sequence] <= @FirstSequence
     ORDER BY [TimeUtc] DESC, 
              [Sequence] DESC FOR XML AUTO;
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_GetErrorXml]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ELMAH_GetErrorXml]
(@Application NVARCHAR(60), 
 @ErrorId     UNIQUEIDENTIFIER
)
AS
     SET NOCOUNT ON;
     SELECT [AllXml]
     FROM [ELMAH_Error]
     WHERE [ErrorId] = @ErrorId
           AND [Application] = @Application;
GO
/****** Object:  StoredProcedure [dbo].[ELMAH_LogError]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ELMAH_LogError]
(@ErrorId     UNIQUEIDENTIFIER, 
 @Application NVARCHAR(60), 
 @Host        NVARCHAR(30), 
 @Type        NVARCHAR(100), 
 @Source      NVARCHAR(60), 
 @Message     NVARCHAR(500), 
 @User        NVARCHAR(50), 
 @AllXml      NTEXT, 
 @StatusCode  INT, 
 @TimeUtc     DATETIME
)
AS
     SET NOCOUNT ON;
     DECLARE @temp1Elmah TABLE([AllXml] XML);
     INSERT INTO @temp1Elmah([AllXml])
     VALUES(CAST(@AllXml AS XML));
     DECLARE @TraceIdentifier NVARCHAR(100);
     SELECT @TraceIdentifier = EMP.ED.value('@string', 'nvarchar(100)')
     FROM @temp1Elmah
          CROSS APPLY [AllXml].nodes('/error/serverVariables/item[@name="TraceIdentifier"]/value') AS EMP(ED);
     INSERT INTO [ELMAH_Error]
     ([ErrorId], 
      [Application], 
      [TraceIdentifier], 
      [Host], 
      [Type], 
      [Source], 
      [Message], 
      [User], 
      [AllXml], 
      [StatusCode], 
      [TimeUtc]
     )
     VALUES
     (@ErrorId, 
      @Application, 
      @TraceIdentifier, 
      @Host, 
      @Type, 
      @Source, 
      @Message, 
      @User, 
      @AllXml, 
      @StatusCode, 
      @TimeUtc
     );
GO
/****** Object:  StoredProcedure [dbo].[P_DeleteEncryptedFile]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[P_DeleteEncryptedFile]
								  @FileCryptId   [BIGINT],								                            
								  @ModifiedBy    [BIGINT]

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	UPDATE [dbo].[FileCrypt]
	   SET [IsActive]   = 0
		  ,[ModifiedOn] = @TodaysDate
		  ,[ModifiedBy] = @ModifiedBy
	 WHERE  FileCryptId = @FileCryptId

	SELECT CAST(1 AS BIT) Success

    END
GO
/****** Object:  StoredProcedure [dbo].[P_DeleteUser]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROC [dbo].[P_DeleteUser]
								  @UserId       [BIGINT], 
                                  @UserName     [NVARCHAR](MAX),                                  
                                  @ModifiedBy    [BIGINT]

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

		 DELETE FROM [dbo].[User]
		 WHERE UserName = @UserName

		 SELECT CAST(1 AS BIT) Success

    END
GO
/****** Object:  StoredProcedure [dbo].[P_GetEncryptedFileDownloadHistory]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[P_GetEncryptedFileDownloadHistory]
			@fileCryptId bigint
AS
    BEGIN

		SELECT fileCrypts.FileCryptId
			  ,fileCrypts.FileName
			  ,fileCrypts.[CreatedOn]
			  ,fileCrypts.[CreatedBy]
		FROM [dbo].[FileCrypt] fileCrypts
		INNER JOIN  [dbo].[FileCryptDownLoadHistory] fileCryptsHistory
		ON fileCrypts.FileCryptId = fileCryptsHistory.FileCryptId
		WHERE fileCrypts.FileCryptId = @fileCryptId

    END
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserDetailsByUserName]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[P_GetUserDetailsByUserName]
 @UserName [NVARCHAR](MAX)
AS
    BEGIN
        SELECT [UserId], 
               [UserName], 
               [FullName], 
               [FirstName], 
               [LastName], 
               [Email], 
               [Password], 
               [PasswordHash], 
               [PasswordSalt], 
               [IsActive], 
               [IsLocked], 
               [CreatedOn], 
               [CreatedBy], 
               [ModifiedOn], 
               [ModifiedBy]
        FROM [dbo].[User]
        WHERE UserName = @UserName
    END
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserDetailsForAuth]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[P_GetUserDetailsForAuth]
 @UserName [NVARCHAR](MAX)
AS
    BEGIN
		DECLARE @UserId BIGINT =  (SELECT TOP 1 [UserId]
									FROM [dbo].[User]
									WHERE UserName = @UserName)

        SELECT [UserId], 
               [UserName], 
               [FullName], 
               [FirstName], 
               [LastName], 
               [Email], 
               [Password], 
               [PasswordHash], 
               [PasswordSalt], 
               [IsActive], 
               [IsLocked], 
               [CreatedOn], 
               [CreatedBy], 
               [ModifiedOn], 
               [ModifiedBy]
        FROM [dbo].[User]
        WHERE UserName = @UserName

		SELECT [UserRoleId]
			  ,[UserId]
			  ,[RoleId]
			  ,[RoleName]
			  ,[IsActive]
			  ,[CreatedOn]
			  ,[CreatedBy]
			  ,[ModifiedOn]
			  ,[ModifiedBy]
		  FROM [dbo].[UserRoles]
		  WHERE [UserId] = @UserId
    END
GO
/****** Object:  StoredProcedure [dbo].[P_GetUserRoles]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[P_GetUserRoles]
		  @UserId       [BIGINT], 
		  @UserName     [NVARCHAR](MAX)        
	
AS
    BEGIN
		SELECT [UserRoleId]
			  ,[UserId]
			  ,[RoleId]
			  ,[RoleName]
			  ,[IsActive]
			  ,[CreatedOn]
			  ,[CreatedBy]
			  ,[ModifiedOn]
			  ,[ModifiedBy]
		  FROM [dbo].[UserRoles]
		  WHERE UserId = @UserId
				AND IsActive  = 1
    END
GO
/****** Object:  StoredProcedure [dbo].[P_GetUsers]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[P_GetUsers]
	@IsActive BIT,
	@IsLocked BIT
AS
    BEGIN
        SELECT [UserId], 
               [UserName], 
               [FullName], 
               [FirstName], 
               [LastName], 
               [Email],               
               [IsActive], 
               [IsLocked], 
               [CreatedOn], 
               [CreatedBy], 
               [ModifiedOn], 
               [ModifiedBy]
        FROM [dbo].[User]
        WHERE IsActive	 = @IsActive
			  AND [IsLocked] = @IsLocked
    END
GO
/****** Object:  StoredProcedure [dbo].[P_ModifyUserRoles]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROC [dbo].[P_ModifyUserRoles]
								  @UserId       [BIGINT], 
                                  @UserName     [NVARCHAR](MAX),                                 
                                  @ModifiedBy    [BIGINT],
								  @T_ModifyUserRoles [dbo].[T_ModifyUserRoles] READONLY

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	-- DROP TABLE TT_ModifyUserRoles
	--select  *,@UserId AS UserIDD into TT_ModifyUserRoles from @T_ModifyUserRoles
	-- select  * from TT_ModifyUserRoles
	


		MERGE dbo.UserRoles AS TARGET
		USING  @T_ModifyUserRoles AS SOURCE
		ON TARGET.[UserId] = SOURCE.[UserId] AND TARGET.[RoleId] = SOURCE.[RoleId]
		WHEN MATCHED AND TARGET.[IsActive] <> SOURCE.[IsActive]
		THEN  
			UPDATE SET TARGET.[RoleName] = SOURCE.[RoleName]  
					 , TARGET.[IsActive] = SOURCE.[IsActive]  
					 ,TARGET.[ModifiedOn] = @TodaysDate
					 ,TARGET.[ModifiedBy] = @ModifiedBy
		WHEN NOT MATCHED BY TARGET AND  SOURCE.[IsActive] = 1
		THEN 
			INSERT ([UserId]
				   ,[RoleId]
				   ,[RoleName]
				   ,[IsActive]
				   ,[CreatedOn]
				   ,[CreatedBy]
				   ,[ModifiedOn]
				   ,[ModifiedBy]) 
			VALUES  
			   (@UserId
			   ,SOURCE.[RoleId]
			   ,SOURCE.[RoleName]
			   ,1
			   ,@TodaysDate
			   ,@ModifiedBy
			   ,@TodaysDate
			   ,@ModifiedBy)  
		 ; 
	

		 SELECT CAST(1 AS BIT) Success

    END
GO
/****** Object:  StoredProcedure [dbo].[P_RegisterUser]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[P_RegisterUser] @UserId       [BIGINT], 
                                  @UserName     [NVARCHAR](MAX), 
                                  @FirstName    [NVARCHAR](MAX), 
                                  @LastName     [NVARCHAR](MAX), 
                                  @Email        [NVARCHAR](MAX), 
                                  @Password     [NVARCHAR](MAX), 
                                  @PasswordHash [NVARCHAR](500), 
                                  @PasswordSalt [NVARCHAR](100), 
                                  @CreatedBy    [BIGINT]
AS
    BEGIN
        DECLARE @TodaysDate DATETIME= GETDATE();
        IF @CreatedBy = 0 OR @CreatedBy = NULL
            BEGIN
                SELECT @CreatedBy = 1;
        END;
        BEGIN TRANSACTION;

        INSERT INTO [dbo].[User]
        ([UserName], 
         [FullName], 
         [FirstName], 
         [LastName], 
         [Email], 
         [Password], 
         [PasswordHash], 
         [PasswordSalt], 
         [IsActive], 
         [IsLocked], 
         [CreatedOn], 
         [CreatedBy], 
         [ModifiedOn], 
         [ModifiedBy]
        )
               SELECT @UserName, 
                      @FirstName + ' ' + @LastName, 
                      @FirstName, 
                      @LastName, 
                      @Email, 
                      @Password, 
                      @PasswordHash, 
                      @PasswordSalt, 
                      1, 
                      0, 
                      @TodaysDate, 
                      @CreatedBy, 
                      @TodaysDate, 
                      @CreatedBy

        DECLARE @ID BIGINT= SCOPE_IDENTITY()

        INSERT INTO [dbo].[UserRoles]
				([UserId], 
				 [RoleId], 
				 [RoleName], 
				 [IsActive], 
				 [CreatedOn], 
				 [CreatedBy], 
				 [ModifiedOn], 
				 [ModifiedBy]
				)
               SELECT @ID, 
                      4, 
                      'User', 
                      1, 
                      @TodaysDate, 
                      @CreatedBy, 
                      @TodaysDate, 
                      @CreatedBy

        COMMIT TRANSACTION;
        SELECT @ID AS UserId;
    END;
GO
/****** Object:  StoredProcedure [dbo].[P_SaveFileDecryptionHistory]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[P_SaveFileDecryptionHistory]
								  @FileCryptId  [BIGINT], 
                                  @CreatedBy    [BIGINT]							

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	INSERT INTO [dbo].[FileCryptDownLoadHistory]
			   ([FileCryptId]
			   ,[CreatedOn]
			   ,[CreatedBy]
			   ,[ModifiedOn]
			   ,[ModifiedBy])

		SELECT @FileCryptId		  
			  ,@TodaysDate
			  ,@CreatedBy
			  ,@TodaysDate
			  ,@CreatedBy

	DECLARE @ID BIGINT= SCOPE_IDENTITY()
	SELECT @ID AS FileCryptDownLoadHistoryId;	

    END
GO
/****** Object:  StoredProcedure [dbo].[P_SaveFileDetailsForEncryption]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[P_SaveFileDetailsForEncryption]
								  @FileName     [NVARCHAR](MAX), 
                                  @CreatedBy    [BIGINT],
								  @ModifiedBy    [BIGINT]

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	INSERT INTO [dbo].[FileCrypt]
           ([FileName]          
           ,[IsActive]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifiedOn]
           ,[ModifiedBy])
	SELECT @FileName
		  ,1
		  ,@TodaysDate
		  ,@CreatedBy
		  ,@TodaysDate
		  ,@CreatedBy

	DECLARE @ID BIGINT= SCOPE_IDENTITY()
	SELECT @ID AS FileCryptId;	

    END
GO
/****** Object:  StoredProcedure [dbo].[P_UpdateFileDetailsAfterEncryption]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[P_UpdateFileDetailsAfterEncryption]
								  @FileCryptId bigint,
								  @EncryptedFileName     [NVARCHAR](MAX), 
								  @EncryptedFilePath     [NVARCHAR](MAX), 
								  @EncryptedFileFullPath     [NVARCHAR](MAX),                                  
								  @ModifiedBy    [BIGINT]

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	UPDATE [dbo].[FileCrypt]
	   SET [EncryptedFileName] = @EncryptedFileName
		  ,[EncryptedFilePath] = @EncryptedFilePath
		  ,[EncryptedFileFullPath] = @EncryptedFileFullPath	
		  ,[ModifiedOn] = @TodaysDate
		  ,[ModifiedBy] = @ModifiedBy
	 WHERE  FileCryptId = @FileCryptId

	SELECT CAST(1 AS BIT) Success

    END
GO
/****** Object:  StoredProcedure [dbo].[P_UpdateUser]    Script Date: 04-06-2019 09:18:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROC [dbo].[P_UpdateUser]
								  @UserId       [BIGINT], 
                                  @UserName     [NVARCHAR](MAX), 
                                  @FirstName    [NVARCHAR](MAX), 
                                  @LastName     [NVARCHAR](MAX), 
                                  @Email        [NVARCHAR](MAX), 
								  @IsActive BIT,
								  @IsLocked BIT, 
                                  @ModifiedBy    [BIGINT]

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

		UPDATE [dbo].[User]
		   SET [FullName] = @FirstName + ' ' + @LastName
			  ,[FirstName] = @FirstName
			  ,[LastName] = @LastName
			  ,[Email] = @Email
			  ,[IsActive] = @IsActive
			  ,[IsLocked] = @IsLocked	 
			  ,[ModifiedOn] = @TodaysDate
			  ,[ModifiedBy] = @ModifiedBy
		 WHERE [UserName] = @UserName

		 SELECT CAST(1 AS BIT) Success

    END
GO
