 

Declare @RoleId uniqueidentifier;

SELECT @RoleId = Id from Role where name = 'Administrator'

Update [dbo].[User] set RoleId = @RoleId where UserName = 'lenggiauit' 

