 

Declare @RoleId uniqueidentifier;

SELECT @RoleId = Id from Role where name = 'Administrator'

Update  [ProjectManagement].[dbo].[User] set RoleId = @RoleId where UserName = 'lenggiauit' 