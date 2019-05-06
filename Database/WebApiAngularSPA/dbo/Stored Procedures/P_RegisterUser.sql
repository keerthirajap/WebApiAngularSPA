




CREATE PROC [dbo].[P_RegisterUser] 
	@UserId 		[bigint] ,
	@UserName 		[nvarchar](max) ,

	@FirstName		[nvarchar](max) ,
	@LastName 		[nvarchar](max) ,
	@Email 			[nvarchar](max) ,
	@Password 		[nvarchar](max) ,
	@PasswordHash   [nvarchar](500) ,
	@PasswordSalt	[nvarchar](100) ,
	@CreatedBy 		[bigint] 
		
  AS
begin

DECLARE @TodaysDate DATETIME = GETDATE()

INSERT INTO [dbo].[User]
           ([UserName]
           ,[FullName]
           ,[FirstName]
           ,[LastName]
           ,[Email]
           ,[Password]
           ,[PasswordHash]
           ,[PasswordSalt]
           ,[IsActive]
           ,[IsLocked]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifiedOn]
           ,[ModifiedBy])
		SELECT
			@UserName 		
			,@FirstName	+ ' ' + @LastName	
			,@FirstName		
			,@LastName 		
			,@Email 			
			,@Password 		
			,@PasswordHash	
			,@PasswordSalt	
			,1 		
			,0 
			,@TodaysDate			
			,@CreatedBy 		
			,@TodaysDate
			,@CreatedBy
	
	
	DECLARE @ID BIGINT = SCOPE_IDENTITY()
			
SELECT @ID AS UserId
end