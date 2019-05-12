CREATE TABLE [dbo].[RoleAssetMapping] (
    [AssetId]            INT            IDENTITY (1, 1) NOT NULL,
    [AssetName]          NVARCHAR (500) NOT NULL,
    [AssetType]          NVARCHAR (500) NOT NULL,
    [ScreenName]         NVARCHAR (500) NOT NULL,
    [AssetFileFullPath]  NVARCHAR (MAX) NOT NULL,
    [AssetFileFullName]  NVARCHAR (500) NOT NULL,
    [IsActive]           BIT            DEFAULT ((1)) NOT NULL,
    [IsActiveForAdmin]   INT            DEFAULT ((0)) NOT NULL,
    [IsActiveForAccess2] INT            DEFAULT ((0)) NOT NULL,
    [IsActiveForAccess1] INT            DEFAULT ((0)) NOT NULL,
    [IsActiveForManager] INT            NULL,
    CONSTRAINT [PK_dbo.RoleAssetMapping] PRIMARY KEY CLUSTERED ([AssetId] ASC, [IsActive] ASC),
    CHECK ([IsActiveForAccess1]<=(1)),
    CHECK ([IsActiveForAccess2]<=(1)),
    CHECK ([IsActiveForAdmin]<=(1)),
    CHECK ([IsActiveForManager]<=(1))
);

