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
-- Author:		��Ʒ��
-- Create date: 2012-10-28
-- Description:	���ݳ���ID��ȡԪ�ص����ԣ�����������Ԫ�ص�����
-- =============================================
CREATE PROCEDURE P_GetElementPropertiesByScreenID
	-- Add the parameters for the stored procedure here
	@ScreenID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [t_ElementProperty] AS A
		WHERE EXISTS(SELECT NULl FROM [t_Element] AS B 
			WHERE A.[ElementID] = B.[ElementID] AND B.[ScreenID] = @ScreenID)
	UNION
	SELECT * FROM [t_ElementProperty] AS A
		WHERE EXISTS(SELECT NULL FROM [t_Element] AS B WHERE 
				A.[ElementID] = B.[ElementID] AND
				EXISTS(SELECT NULL FROM [t_Element] C 
					WHERE C.[ScreenID]=@ScreenID AND B.[ScreenID] = C.[ElementID] * -1))
END
GO
