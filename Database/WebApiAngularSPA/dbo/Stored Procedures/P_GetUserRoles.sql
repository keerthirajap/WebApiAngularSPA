


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