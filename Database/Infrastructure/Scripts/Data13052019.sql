USE [WebApiAngularSPA]
GO
SET IDENTITY_INSERT [dbo].[RoleAssetMapping] ON 
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForAdmin], [IsActiveForAccess2], [IsActiveForAccess1], [IsActiveForManager]) VALUES (1, N'UserManagement', N'View', N'UserManagement', N'Area\Admin\Views\Admin\', N'Index.cshtml', 1, 1, 0, 0, 0)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForAdmin], [IsActiveForAccess2], [IsActiveForAccess1], [IsActiveForManager]) VALUES (4, N'Home', N'View', N'Home', N'View\Home\Index.cshtml', N'Index.cshtm', 1, 1, 1, 1, 1)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForAdmin], [IsActiveForAccess2], [IsActiveForAccess1], [IsActiveForManager]) VALUES (5, N'Screen1', N'View', N'Screen1', N'123', N'Index.cshtml', 1, 1, 1, 0, 1)
GO
INSERT [dbo].[RoleAssetMapping] ([AssetId], [AssetName], [AssetType], [ScreenName], [AssetFileFullPath], [AssetFileFullName], [IsActive], [IsActiveForAdmin], [IsActiveForAccess2], [IsActiveForAccess1], [IsActiveForManager]) VALUES (6, N'Screen2', N'View', N'Screen2', N'Screen2', N'Screen2', 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[RoleAssetMapping] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (1, N'Admin')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Manager')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Access1')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (4, N'Access2')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1, N'SystemUserCreator', NULL, NULL, NULL, NULL, N'', NULL, NULL, 0, 1, CAST(N'2019-05-12T10:39:02.797' AS DateTime), NULL, CAST(N'2019-05-12T10:39:02.797' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (2, N'Register', N'Register Register', N'Register', N'Register', N'Register', N'Register', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T10:42:58.830' AS DateTime), NULL, CAST(N'2019-05-12T18:22:40.590' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (3, N'RegisterAdmin', N'Admin User Admin User', N'Admin User', N'Admin User', N'Admin User', N'RegisterAdmin', NULL, NULL, 1, 0, CAST(N'2019-05-12T12:50:08.533' AS DateTime), NULL, CAST(N'2019-05-13T00:35:17.367' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (4, N'Registeree', NULL, NULL, NULL, NULL, N'Registeree', NULL, NULL, 1, 0, CAST(N'2019-05-12T14:24:29.860' AS DateTime), NULL, CAST(N'2019-05-12T14:24:29.860' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (5, N'sdvsdvsdvsdv', N'sdvsdv sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:40:18.833' AS DateTime), NULL, CAST(N'2019-05-12T16:40:18.833' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (6, N'sdvsdv', N'sdvsdv sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:40:33.100' AS DateTime), NULL, CAST(N'2019-05-12T16:40:33.100' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (7, N'sdvsdv1', N'sdvsdv sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', N'sdvsdv', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:41:16.593' AS DateTime), NULL, CAST(N'2019-05-12T19:01:16.150' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (8, N'publicMethod.Redirec', N'publicMethod.Redirec publicMethod.Redirec', N'publicMethod.Redirec', N'publicMethod.Redirec', N'publicMethod.RedirectToUrl = function (url) {                 // JsMain.ShowLoaddingIndicator();                  window.location.href = url;             },', N'publicMethod.Redirec', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T16:43:24.457' AS DateTime), NULL, CAST(N'2019-05-12T18:20:20.473' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (9, N'reloadCurrentPage', N'reloadCurrentPage reloadCurrentPage', N'reloadCurrentPage', N'reloadCurrentPage', N'reloadCurrentPage', N'reloadCurrentPage', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:44:24.390' AS DateTime), NULL, CAST(N'2019-05-12T16:44:24.390' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10, N'publicMethod', N'publicMethod publicMethod', N'publicMethod', N'publicMethod', N'publicMethod', N'publicMethod', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:44:55.700' AS DateTime), NULL, CAST(N'2019-05-12T16:44:55.700' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (11, N'confirmButtonText', N'confirmButtonText confirmButtonText', N'confirmButtonText', N'confirmButtonText', N'confirmButtonText', N'confirmButtonText', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:45:42.903' AS DateTime), NULL, CAST(N'2019-05-12T16:45:42.903' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (12, N'secondary', N'secondary secondary', N'secondary', N'secondary', N'secondary', N'secondary', NULL, NULL, 1, 1, CAST(N'2019-05-12T16:47:23.773' AS DateTime), NULL, CAST(N'2019-05-12T18:48:28.250' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (13, N'showCancelButton: tr', N'showCancelButton: tr showCancelButton: tr', N'showCancelButton: tr', N'showCancelButton: tr', N'showCancelButton: true,', N'showCancelButton: tr', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:47:55.793' AS DateTime), NULL, CAST(N'2019-05-12T16:47:55.793' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (14, N'showCancelButton', N'showCancelButton showCancelButton', N'showCancelButton', N'showCancelButton', N'showCancelButton', N'showCancelButton', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T16:48:39.363' AS DateTime), NULL, CAST(N'2019-05-12T18:17:30.993' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (15, N'showCancelButton1', N'showCancelButton showCancelButton', N'showCancelButton', N'showCancelButton', N'showCancelButton', N'showCancelButton', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T16:49:35.573' AS DateTime), NULL, CAST(N'2019-05-12T18:18:22.470' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (16, N'RegisterAdmin22', N'RegisterAdmin RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', NULL, NULL, 1, 0, CAST(N'2019-05-12T16:56:02.743' AS DateTime), NULL, CAST(N'2019-05-12T16:56:02.743' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (17, N'UserManagement', N'UserManagement UserManagement', N'UserManagement', N'UserManagement', N'UserManagement', N'UserManagement', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T16:57:04.067' AS DateTime), NULL, CAST(N'2019-05-12T18:15:54.403' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (18, N'xhrcxhr', N'xhrcxhr xhrcxhr', N'xhrcxhr', N'xhrcxhr', N'xhrcxhr', N'xhrcxhr', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:05:13.623' AS DateTime), NULL, CAST(N'2019-05-12T17:05:13.623' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (19, N'RegisterAdmin111', N'RegisterAdmin111 RegisterAdmin111', N'RegisterAdmin111', N'RegisterAdmin111', N'RegisterAdmin111', N'RegisterAdmin111', NULL, NULL, NULL, NULL, CAST(N'2019-05-12T17:08:43.397' AS DateTime), NULL, CAST(N'2019-05-12T18:22:22.890' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (20, N'message', N'message message', N'message', N'message', N'message', N'message', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:10:16.793' AS DateTime), NULL, CAST(N'2019-05-12T17:10:16.793' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (21, N'requestId', N'requestId requestId', N'requestId', N'requestId', N'requestId', N'requestId', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:11:17.767' AS DateTime), NULL, CAST(N'2019-05-12T17:11:17.767' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (22, N'requestIdrequestId', N'requestId requestId', N'requestId', N'requestId', N'requestId', N'requestId', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:12:07.130' AS DateTime), NULL, CAST(N'2019-05-12T17:12:07.130' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (23, N'requestIdww', N'requestIdww requestIdww', N'requestIdww', N'requestIdww', N'requestIdww', N'requestIdww', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:13:29.943' AS DateTime), NULL, CAST(N'2019-05-12T17:13:29.943' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (24, N'requestIdwwq', N'requestIdww requestIdww', N'requestIdww', N'requestIdww', N'requestIdww', N'requestIdww', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:14:08.527' AS DateTime), NULL, CAST(N'2019-05-12T20:07:25.683' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (25, N'getSignarRConnection', N'getSignarRConnection getSignarRConnection', N'getSignarRConnection', N'getSignarRConnection', N'getSignarRConnectionIdgetSignarRConnection', N'getSignarRConnection', NULL, NULL, 1, 0, CAST(N'2019-05-12T17:15:15.687' AS DateTime), NULL, CAST(N'2019-05-12T20:06:46.550' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (26, N'RegisterAdminRegiste', N'RegisterAdmin RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', N'RegisterAdmin', NULL, NULL, 1, 1, CAST(N'2019-05-12T17:19:04.270' AS DateTime), NULL, CAST(N'2019-05-12T18:50:26.193' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10004, N'UseCookieAuthenticat', N'UseCookieAuthenticat UseCookieAuthenticat', N'UseCookieAuthenticat', N'UseCookieAuthenticat', N'UseCookieAuthentication', N'UseCookieAuthenticat', NULL, NULL, 1, 0, CAST(N'2019-05-12T20:06:12.493' AS DateTime), NULL, CAST(N'2019-05-12T20:06:12.493' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10005, N'AuthenticationScheme', N'AuthenticationScheme AuthenticationScheme', N'AuthenticationScheme', N'AuthenticationScheme', N'AuthenticationScheme ', N'AuthenticationScheme', NULL, NULL, 1, 0, CAST(N'2019-05-12T20:09:57.477' AS DateTime), NULL, CAST(N'2019-05-12T20:09:57.477' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([UserId], [UserName], [FullName], [FirstName], [LastName], [Email], [Password], [PasswordHash], [PasswordSalt], [IsActive], [IsLocked], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (10006, N'AuthenticationSchem1', N'AuthenticationScheme AuthenticationScheme', N'AuthenticationScheme', N'AuthenticationScheme', N'AuthenticationScheme ', N'AuthenticationScheme', NULL, NULL, 1, 0, CAST(N'2019-05-12T20:10:14.207' AS DateTime), NULL, CAST(N'2019-05-12T20:10:14.207' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserRoles] ON 
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (58, 2, 3, N'Access1', 1, CAST(N'2019-05-12T10:42:58.830' AS DateTime), NULL, CAST(N'2019-05-12T10:42:58.830' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (59, 3, 3, N'Access1', 1, CAST(N'2019-05-12T12:50:08.533' AS DateTime), NULL, CAST(N'2019-05-12T12:50:08.533' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (60, 3, 1, N'Admin', 1, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (61, 4, 3, N'Access1', 1, CAST(N'2019-05-12T14:24:29.860' AS DateTime), NULL, CAST(N'2019-05-12T14:24:29.860' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (62, 5, 3, N'Access1', 1, CAST(N'2019-05-12T16:40:18.833' AS DateTime), NULL, CAST(N'2019-05-12T16:40:18.833' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (63, 6, 3, N'Access1', 1, CAST(N'2019-05-12T16:40:33.100' AS DateTime), NULL, CAST(N'2019-05-12T16:40:33.100' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (64, 7, 3, N'Access1', 1, CAST(N'2019-05-12T16:41:16.593' AS DateTime), NULL, CAST(N'2019-05-12T16:41:16.593' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (65, 8, 3, N'Access1', 1, CAST(N'2019-05-12T16:43:24.457' AS DateTime), NULL, CAST(N'2019-05-12T16:43:24.457' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (66, 9, 3, N'Access1', 1, CAST(N'2019-05-12T16:44:24.390' AS DateTime), NULL, CAST(N'2019-05-12T16:44:24.390' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (67, 10, 3, N'Access1', 1, CAST(N'2019-05-12T16:44:55.700' AS DateTime), NULL, CAST(N'2019-05-12T16:44:55.700' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (68, 11, 3, N'Access1', 1, CAST(N'2019-05-12T16:45:42.903' AS DateTime), NULL, CAST(N'2019-05-12T16:45:42.903' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (69, 12, 3, N'Access1', 1, CAST(N'2019-05-12T16:47:23.773' AS DateTime), NULL, CAST(N'2019-05-12T16:47:23.773' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (70, 13, 3, N'Access1', 1, CAST(N'2019-05-12T16:47:55.793' AS DateTime), NULL, CAST(N'2019-05-12T16:47:55.793' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (71, 14, 3, N'Access1', 1, CAST(N'2019-05-12T16:48:39.363' AS DateTime), NULL, CAST(N'2019-05-12T16:48:39.363' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (72, 15, 3, N'Access1', 1, CAST(N'2019-05-12T16:49:35.573' AS DateTime), NULL, CAST(N'2019-05-12T16:49:35.573' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (73, 16, 3, N'Access1', 1, CAST(N'2019-05-12T16:56:02.743' AS DateTime), NULL, CAST(N'2019-05-12T16:56:02.743' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (74, 17, 3, N'Access1', 1, CAST(N'2019-05-12T16:57:04.067' AS DateTime), NULL, CAST(N'2019-05-12T16:57:04.067' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (75, 18, 3, N'Access1', 1, CAST(N'2019-05-12T17:05:13.623' AS DateTime), NULL, CAST(N'2019-05-12T17:05:13.623' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (76, 19, 3, N'Access1', 1, CAST(N'2019-05-12T17:08:43.397' AS DateTime), NULL, CAST(N'2019-05-12T17:08:43.397' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (77, 20, 3, N'Access1', 1, CAST(N'2019-05-12T17:10:16.793' AS DateTime), NULL, CAST(N'2019-05-12T17:10:16.793' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (78, 21, 3, N'Access1', 1, CAST(N'2019-05-12T17:11:17.767' AS DateTime), NULL, CAST(N'2019-05-12T17:11:17.767' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (79, 22, 3, N'Access1', 1, CAST(N'2019-05-12T17:12:07.130' AS DateTime), NULL, CAST(N'2019-05-12T17:12:07.130' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (80, 23, 3, N'Access1', 1, CAST(N'2019-05-12T17:13:29.943' AS DateTime), NULL, CAST(N'2019-05-12T17:13:29.943' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (81, 24, 3, N'Access1', 1, CAST(N'2019-05-12T17:14:08.527' AS DateTime), NULL, CAST(N'2019-05-12T17:14:08.527' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (82, 25, 3, N'Access1', 1, CAST(N'2019-05-12T17:15:15.687' AS DateTime), NULL, CAST(N'2019-05-12T17:15:15.687' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (83, 26, 3, N'Access1', 1, CAST(N'2019-05-12T17:19:04.270' AS DateTime), NULL, CAST(N'2019-05-12T17:19:04.270' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (84, 27, 3, N'Access1', 1, CAST(N'2019-05-12T18:55:35.500' AS DateTime), NULL, CAST(N'2019-05-12T18:55:35.500' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1001, 10002, 3, N'Access1', 1, CAST(N'2019-05-12T20:03:51.183' AS DateTime), NULL, CAST(N'2019-05-12T20:03:51.183' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1002, 10003, 3, N'Access1', 1, CAST(N'2019-05-12T20:04:26.390' AS DateTime), NULL, CAST(N'2019-05-12T20:04:26.390' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1003, 10004, 3, N'Access1', 1, CAST(N'2019-05-12T20:06:12.493' AS DateTime), NULL, CAST(N'2019-05-12T20:06:12.493' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1004, 10005, 3, N'Access1', 1, CAST(N'2019-05-12T20:09:57.477' AS DateTime), NULL, CAST(N'2019-05-12T20:09:57.477' AS DateTime), NULL)
GO
INSERT [dbo].[UserRoles] ([UserRoleId], [UserId], [RoleId], [RoleName], [IsActive], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy]) VALUES (1005, 10006, 3, N'Access1', 1, CAST(N'2019-05-12T20:10:14.207' AS DateTime), NULL, CAST(N'2019-05-12T20:10:14.207' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
GO
