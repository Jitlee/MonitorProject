USE [GDK_BCM]
IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Screen') 
		AND NAME=N'Width')
BEGIN
	ALTER TABLE [t_Screen] ADD [Width] int
	PRINT N'����t_Screen�����Width�ֶ�'
END

IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Screen') 
		AND NAME=N'Height')
BEGIN
	ALTER TABLE [t_Screen] ADD [Height] int
	PRINT N'����t_Screen�����Height�ֶ�'
END

IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Screen') 
		AND NAME=N'BackColor')
BEGIN
	ALTER TABLE [t_Screen] ADD [BackColor] nchar(20)
	PRINT N'����t_Screen�����BackColor�ֶ�'
END

IF NOT EXISTS(SELECT NULL FROM syscolumns 
		WHERE ID = (SELECT ID FROM sysobjects WHERE TYPE='U' AND NAME=N't_Screen') 
		AND NAME=N'AutoSize')
BEGIN
	ALTER TABLE [t_Screen] ADD [AutoSize] bit
	PRINT N'����t_Screen�����AutoSize�ֶ�'
END