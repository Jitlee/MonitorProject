USE [GDK_BCM]
IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Element') 
		AND NAME=N'ElementType')
BEGIN
	ALTER TABLE [t_Element] ADD [ElementType] nvarchar(50)
	PRINT N'给表t_Element添加了ElementType字段'
END

IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Element') 
		AND NAME=N'ParentID')
BEGIN
	ALTER TABLE [t_Element] ADD [ParentID] int
	PRINT N'给表t_Element添加了ParentID字段'
END

IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Screen') 
		AND NAME=N'AutoSize')
BEGIN
	ALTER TABLE [t_Screen] ADD [AutoSize] bit
	PRINT N'给表t_Screen添加了AutoSize字段'
END
