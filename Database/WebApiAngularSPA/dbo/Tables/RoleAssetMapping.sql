CREATE TABLE [dbo].[RoleAssetMapping] (
    [AssetId]              INT            IDENTITY (1, 1) NOT NULL,
    [AssetName]            NVARCHAR (500) NOT NULL,
    [AssetType]            NVARCHAR (500) NOT NULL,
    [ScreenName]           NVARCHAR (500) NOT NULL,
    [AssetFileFullPath]    NVARCHAR (MAX) NOT NULL,
    [AssetFileFullName]    NVARCHAR (500) NOT NULL,
    [IsActive]             BIT            NOT NULL,
    [IsActiveForSuperUser] INT            NOT NULL,
    [IsActiveForAdmin]     INT            NOT NULL,
    [IsActiveForManager]   INT            NOT NULL,
    [IsActiveForUser]      INT            NULL,
    CONSTRAINT [PK_dbo.RoleAssetMapping] PRIMARY KEY CLUSTERED ([AssetId] ASC, [IsActive] ASC)
);



