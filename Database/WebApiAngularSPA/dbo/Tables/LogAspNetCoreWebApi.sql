CREATE TABLE [dbo].[LogAspNetCoreWebApi] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Application]      NVARCHAR (500) NOT NULL,
    [TraceIdentifier]  NVARCHAR (500) NOT NULL,
    [Logged]           DATETIME       NOT NULL,
    [Level]            NVARCHAR (50)  NOT NULL,
    [RequestIPAddress] NVARCHAR (500) NOT NULL,
    [Url]              NVARCHAR (200) NOT NULL,
    [UserName]         NVARCHAR (100) NOT NULL,
    [Message]          NVARCHAR (MAX) NOT NULL,
    [Logger]           NVARCHAR (250) NULL,
    [Callsite]         NVARCHAR (MAX) NULL,
    [Exception]        NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Log] PRIMARY KEY CLUSTERED ([Id] DESC)
);

