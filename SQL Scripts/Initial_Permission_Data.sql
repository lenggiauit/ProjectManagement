USE [ProjectManagement]
GO

INSERT INTO [dbo].[Permission]
           ([Id]
           ,[Name]
           ,[Code]
           ,[Description]
           ,[IsActive]
           ,[CreatedDate] )
     VALUES
           (NEWID()
           ,'Create a team'
           ,'CreateTeam'
           ,'Create a team'
           ,1
           ,GETDATE()
            ),
			(NEWID()
           ,'Get all team'
           ,'GetAllTeam'
           ,'Get all team'
           ,1
           ,GETDATE()
            ),
			(NEWID()
           ,'Delete a team'
           ,'DeleteTeam'
           ,'Delete a team'
           ,1
           ,GETDATE()
            ),
			(NEWID()
           ,'Invite team member'
           ,'InviteTeamMember'
           ,'Invite team member'
           ,1
           ,GETDATE()
            ),
			(NEWID()
           ,'Remove team member'
           ,'RemoveTeamMember'
           ,'Remove team member'
           ,1
           ,GETDATE()
            ),
			(NEWID()
           ,'Update team member'
           ,'UpdateTeamMember'
           ,'Update team member'
           ,1
           ,GETDATE()
            ) 
GO


