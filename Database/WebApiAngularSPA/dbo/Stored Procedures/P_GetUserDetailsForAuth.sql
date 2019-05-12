
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