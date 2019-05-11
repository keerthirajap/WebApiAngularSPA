CREATE PROC [dbo].[P_GetUserDetailsByUserName]
 @UserName [NVARCHAR](MAX)
AS
    BEGIN
        SELECT [UserId], 
               [UserName], 
               [FullName], 
               [FirstName], 
               [LastName], 
               [Email], 
               [Password], 
               [PasswordHash], 
               [PasswordSalt], 
               [IsActive], 
               [IsLocked], 
               [CreatedOn], 
               [CreatedBy], 
               [ModifiedOn], 
               [ModifiedBy]
        FROM [dbo].[User]
        WHERE UserName = @UserName
    END