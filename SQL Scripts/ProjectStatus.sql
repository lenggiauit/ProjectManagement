USE [ProjectManagement]
GO

INSERT INTO [dbo].[ProjectStatus]
           ([Id]
           ,[Name]
           ,[Description]
           ,[IsActive]
           ,[CreatedDate]
           )
     VALUES
           ( NEWID()
           , 'OPEN'
           , 'Open'
           , 1
           , GETDATE()
           ),
		   ( NEWID()
           , 'Hold'
           , 'Hold'
           , 1
           , GETDATE()
           ),
		   ( NEWID()
           , 'Closed'
           , 'Closed'
           , 1
           , GETDATE()
           )
GO


