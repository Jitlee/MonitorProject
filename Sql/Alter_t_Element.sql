USE [GDK_BCM]
IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Element') 
		AND NAME=N'ElementType')
BEGIN
	ALTER TABLE [t_Element] ADD [ElementType] nvarchar(50)
	PRINT N'����t_Element������ElementType�ֶ�'
END