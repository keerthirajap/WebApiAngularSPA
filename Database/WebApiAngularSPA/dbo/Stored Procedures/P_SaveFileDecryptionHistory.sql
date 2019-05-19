


CREATE PROC [dbo].[P_SaveFileDecryptionHistory]
								  @FileCryptId  [BIGINT], 
                                  @CreatedBy    [BIGINT]							

AS
    BEGIN

	DECLARE @TodaysDate DATETIME= GETDATE();

	INSERT INTO [dbo].[FileCryptDownLoadHistory]
			   ([FileCryptId]
			   ,[CreatedOn]
			   ,[CreatedBy]
			   ,[ModifiedOn]
			   ,[ModifiedBy])

		SELECT @FileCryptId		  
			  ,@TodaysDate
			  ,@CreatedBy
			  ,@TodaysDate
			  ,@CreatedBy

	DECLARE @ID BIGINT= SCOPE_IDENTITY()
	SELECT @ID AS FileCryptDownLoadHistoryId;	

    END