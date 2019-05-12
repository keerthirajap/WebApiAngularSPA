





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