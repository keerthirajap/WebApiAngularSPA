

CREATE PROC [dbo].[P_GetUsers]
	@IsActive BIT,
	@IsLocked BIT
AS
    BEGIN
        SELECT [UserId], 
               [UserName], 
               [FullName], 
               [FirstName], 
               [LastName], 
               [Email],               
               [IsActive], 
               [IsLocked], 
               [CreatedOn], 
               [CreatedBy], 
               [ModifiedOn], 
               [ModifiedBy]
        FROM [dbo].[User]
        WHERE IsActive	 = @IsActive
			  AND [IsLocked] = @IsLocked
    END