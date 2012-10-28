USE [GDK_BCM]
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		万品佳
-- Create date: 2012-10-28
-- Description:	根据场景ID获取元素列表
-- =============================================
CREATE PROCEDURE P_GetElementsByScreenID
	-- Add the parameters for the stored procedure here
	@ScreenID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [t_Element] WHERE [ScreenID]=@ScreenID
	UNION ALL
	SELECT * FROM [t_Element] AS A WHERE 
		EXISTS(SELECT NULL FROM [t_Element] B 
			WHERE B.[ScreenID]=@ScreenID AND A.[ScreenID] = B.[ElementID] * -1)
END
GO
