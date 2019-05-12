




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