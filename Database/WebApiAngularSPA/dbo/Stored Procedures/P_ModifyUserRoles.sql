





CREATE PROC [dbo].[P_ModifyUserRoles]
								  @UserId       [BIGINT], 
                                  @UserName     [NVARCHAR](MAX),                                 
                                  @ModifiedBy    [BIGINT],
								  @T_ModifyUserRoles [dbo].[T_ModifyUserRoles] READONLY

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

		MERGE dbo.UserRoles AS TARGET
		USING  @T_ModifyUserRoles AS SOURCE
		ON TARGET.[UserId] = SOURCE.[UserId]
		WHEN MATCHED AND TARGET.[IsActive] <> SOURCE.[IsActive]
		THEN  
			UPDATE SET TARGET.[RoleName] = SOURCE.[RoleName]  
					 ,TARGET.[ModifiedOn] = @TodaysDate
					 ,TARGET.[ModifiedBy] = @ModifiedBy
		WHEN NOT MATCHED BY TARGET 
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
			   (SOURCE.[UserId]
			   ,SOURCE.[RoleId]
			   ,SOURCE.[RoleName]
			   ,SOURCE.[IsActive]
			   ,@TodaysDate
			   ,@ModifiedBy
			   ,@TodaysDate
			   ,@ModifiedBy)  
		 ; 
	

		 SELECT CAST(1 AS BIT) Success

    END