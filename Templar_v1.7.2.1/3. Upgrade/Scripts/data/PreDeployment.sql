

If(ISNULL((Select MAX(len(UserName)) from ActivityLog),0)< 50)
Begin
	Alter Table ActivityLog Alter column UserName varchar(50) Not NULL
End
else
	print N'Column UserName[ActivityLog] contain a data of length more than varchar(50).'
Go

If(ISNULL((Select MAX(len(UserName)) from AuditLog),0)< 50)
Begin
	Alter Table AuditLog Alter column UserName varchar(50) Not NULL
End
else
	print N'Column UserName[AuditLog] contain a data of length more than varchar(50).'
Go

If(ISNULL((Select MAX(len(SiteURL)) from AuditLog),0)< 500)
Begin
	Alter Table AuditLog Alter column SiteURL varchar(500)
End
else
	print N'Column SiteURL[AuditLog] contain a data of length more than varchar(500).'
Go



Begin
declare @ConstraintName nvarchar(256)
Set @ConstraintName=(select Top 1 d.name
from sys.tables t
    join
    sys.default_constraints d
        on d.parent_object_id = t.object_id
    join
    sys.columns c
        on c.object_id = t.object_id
        and c.column_id = d.parent_column_id
where t.name = 'AuditLog'
and c.name = 'AdditionalInfo')
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(@ConstraintName) AND type = 'D')
	If(ISNULL((Select MAX(len(SiteURL)) from AuditLog),0)< 4000)
		EXEC('ALTER TABLE [dbo].[AuditLog] DROP CONSTRAINT '+ @ConstraintName)
	Else
		print N'Column AdditionalInfo[AuditLog] contain a data of length more than varchar(4000).'
End
Go

IF EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'AuditLog'
                 AND COLUMN_NAME = 'AdditionalInfo') 
                 Begin
                 If((Select MAX(len(SiteURL)) from AuditLog)< 4000)
					Begin
					Alter Table AuditLog Alter column AdditionalInfo varchar(4000)
					ALTER TABLE [dbo].[AuditLog] ADD  DEFAULT ('') FOR [AdditionalInfo]
					End
				Else
					print N'Column AdditionalInfo[AuditLog] contain a data of length more than varchar(4000).'
				End
Go



Alter Table Content Alter column BinaryData varbinary(max) Not NULL
GO

If(ISNULL((Select MAX(len(Comment)) from Content),0)< 4000)
Begin
	Alter Table Content Alter column Comment nvarchar(4000)
End
Else
		print N'Column AdditionalInfo[AuditLog] contain a data of length more than varchar(4000).'
GO

Alter Table CultureContentForLive Alter column BinaryData varbinary(max) Not Null
GO

If(ISNULL((Select MAX(len(Comment)) from CultureResource),0)< 4000)
Begin
	Alter Table CultureResource Alter column Comment nvarchar(4000)
End
Else
		print N'Column AdditionalInfo[AuditLog] contain a data of length more than varchar(4000).'
GO

If(ISNULL((Select MAX(len(Comment)) from CultureResourceForLive),0)< 4000)
Begin
	Alter Table CultureResourceForLive Alter column Comment nvarchar(4000)
End
GO

IF EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'Exception'
                 AND COLUMN_NAME = 'MachineName')
If(ISNULL((Select MAX(len(MachineName)) from Exception),0)< 256)
Begin
	Alter Table Exception Alter column MachineName varchar(256)
End
Else
		print N'Column MachineName[Exception] contain a data of length more than varchar(256).'
GO

If(ISNULL((Select MAX(len(URL)) from Site),0)< 500)
Begin
	Alter Table Site Alter column URL varchar(500) Not NULL
End
Else
		print N'Column URL[Site] contain a data of length more than varchar(256).'
GO

If(ISNULL((Select MAX(len(MappedToDomain)) from Site),0)< 4000)
Begin
	Alter Table Site Alter column MappedToDomain nvarchar(4000)
End
Else
		print N'Column MappedToDomain[Site] contain a data of length more than varchar(4000).'
GO

If(ISNULL((Select MAX(len(URL)) from SiteForLive),0)< 500)
Begin 
	Alter Table SiteForLive Alter column URL varchar(500) Not NULL
End
Else
		print N'Column URL[SiteForLive] contain a data of length more than varchar(500).'
GO

If(ISNULL((Select MAX(len(MappedToDomain)) from SiteForLive),0)< 4000)
Begin
	Alter Table SiteForLive Alter column MappedToDomain nvarchar(4000)
End
Else
		print N'Column MappedToDomain[SiteForLive] contain a data of length more than varchar(4000).'
GO

If(ISNULL((Select MAX(len(State)) from Users),0)< 4000)
Begin
	Alter Table Users Alter column State nvarchar(4000)
End
Else
		print N'Column State[Users] contain a data of length more than varchar(4000).'
GO

IF EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'WebEvent'
                 AND COLUMN_NAME = 'EventSequence')
Alter Table WebEvent Alter column EventSequence int Not NULL
GO

IF EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'WebEvent'
                 AND COLUMN_NAME = 'EventOccurrence')
Alter Table WebEvent Alter column EventOccurrence int Not NULL
GO

IF EXISTS(SELECT *
          FROM   INFORMATION_SCHEMA.COLUMNS
          WHERE  TABLE_NAME = 'WebEvent'
                 AND COLUMN_NAME = 'Details')
Alter Table WebEvent Alter column Details nvarchar(max)
GO