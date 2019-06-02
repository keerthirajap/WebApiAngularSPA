CREATE TABLE [dbo].[FileCryptDownLoadHistory] (
    [FileCryptDownLoadHistoryId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [FileCryptId]                BIGINT   NOT NULL,
    [CreatedOn]                  DATETIME NULL,
    [CreatedBy]                  BIGINT   NULL,
    [ModifiedOn]                 DATETIME NULL,
    [ModifiedBy]                 BIGINT   NULL,
    CONSTRAINT [PK_dbo.FileCryptDownLoadHistory] PRIMARY KEY CLUSTERED ([FileCryptDownLoadHistoryId] DESC),
    CONSTRAINT [FK_FileCryptDownLoadHistory_FileCrypt] FOREIGN KEY ([FileCryptId]) REFERENCES [dbo].[FileCrypt] ([FileCryptId])
);



