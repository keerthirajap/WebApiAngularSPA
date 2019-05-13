






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