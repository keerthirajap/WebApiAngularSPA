
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