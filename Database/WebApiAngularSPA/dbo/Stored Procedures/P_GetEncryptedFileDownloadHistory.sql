

CREATE PROC [dbo].[P_GetEncryptedFileDownloadHistory]
			@fileCryptId bigint
AS
    BEGIN

		SELECT fileCrypts.FileCryptId
			  ,fileCrypts.FileName
			  ,fileCrypts.[CreatedOn]
			  ,fileCrypts.[CreatedBy]
		FROM [dbo].[FileCrypt] fileCrypts
		INNER JOIN  [dbo].[FileCryptDownLoadHistory] fileCryptsHistory
		ON fileCrypts.FileCryptId = fileCryptsHistory.FileCryptId
		WHERE fileCrypts.FileCryptId = @fileCryptId

    END