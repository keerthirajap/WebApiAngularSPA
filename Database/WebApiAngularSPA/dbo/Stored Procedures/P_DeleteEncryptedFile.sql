

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