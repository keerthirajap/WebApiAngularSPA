create PROCEDURE [dbo].[ELMAH_LogError]
(@ErrorId     UNIQUEIDENTIFIER, 
 @Application NVARCHAR(60), 
 @Host        NVARCHAR(30), 
 @Type        NVARCHAR(100), 
 @Source      NVARCHAR(60), 
 @Message     NVARCHAR(500), 
 @User        NVARCHAR(50), 
 @AllXml      NTEXT, 
 @StatusCode  INT, 
 @TimeUtc     DATETIME
)
AS
     SET NOCOUNT ON;
     DECLARE @temp1Elmah TABLE([AllXml] XML);
     INSERT INTO @temp1Elmah([AllXml])
     VALUES(CAST(@AllXml AS XML));
     DECLARE @TraceIdentifier NVARCHAR(100);
     SELECT @TraceIdentifier = EMP.ED.value('@string', 'nvarchar(100)')
     FROM @temp1Elmah
          CROSS APPLY [AllXml].nodes('/error/serverVariables/item[@name="TraceIdentifier"]/value') AS EMP(ED);
     INSERT INTO [ELMAH_Error]
     ([ErrorId], 
      [Application], 
      [TraceIdentifier], 
      [Host], 
      [Type], 
      [Source], 
      [Message], 
      [User], 
      [AllXml], 
      [StatusCode], 
      [TimeUtc]
     )
     VALUES
     (@ErrorId, 
      @Application, 
      @TraceIdentifier, 
      @Host, 
      @Type, 
      @Source, 
      @Message, 
      @User, 
      @AllXml, 
      @StatusCode, 
      @TimeUtc
     );