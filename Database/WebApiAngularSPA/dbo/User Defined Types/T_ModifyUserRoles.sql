CREATE TYPE [dbo].[T_ModifyUserRoles] AS TABLE (
    [UserRoleId] INT            NULL,
    [UserId]     INT            NULL,
    [RoleId]     INT            NULL,
    [RoleName]   NVARCHAR (MAX) NULL,
    [IsActive]   BIT            NULL);



