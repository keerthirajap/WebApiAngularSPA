

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