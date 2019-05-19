CREATE TABLE [dbo].[FileCrypt] (
    [FileCryptId]           BIGINT         IDENTITY (1, 1) NOT NULL,
    [FileName]              NVARCHAR (MAX) NULL,
    [EncryptedFileName]     NVARCHAR (MAX) NULL,
    [EncryptedFilePath]     NVARCHAR (MAX) NULL,
    [EncryptedFileFullPath] NVARCHAR (MAX) NULL,
    [IsActive]              BIT            NULL,
    [CreatedOn]             DATETIME       NULL,
    [CreatedBy]             BIGINT         NULL,
    [ModifiedOn]            DATETIME       NULL,
    [ModifiedBy]            BIGINT         NULL,
    CONSTRAINT [PK_dbo.FileCrypt] PRIMARY KEY CLUSTERED ([FileCryptId] DESC)
);

