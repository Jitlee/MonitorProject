USE [GDK_BCM]
GO
/****** 对象:  Table [dbo].[t_Element_RealTimeLine]    脚本日期: 10/25/2012 21:37:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_Element_RealTimeLine](
	[ID] [char](36) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ScreenID] [int] NOT NULL,
	[ElementID] [int] NOT NULL,
	[LineType] [int] NOT NULL,
	[LineName] [varchar](10) COLLATE Chinese_PRC_CI_AS NULL,
	[LineCZ] [int] NULL,
	[LineShowType] [int] NULL,
	[LineStyle] [int] NULL,
	[LinePointBJ] [int] NULL,
	[LineColor] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MinValue] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[MaxValue] [varchar](10) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[ValueDecimal] [int] NOT NULL,
	[ShowFormat] [varchar](20) COLLATE Chinese_PRC_CI_AS NULL,
	[TimeLen] [int] NOT NULL,
	[TimeLenType] [varchar](2) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[LineCYZQLent] [varchar](2) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[LineCYZQType] [varchar](2) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[DeviceID] [int] NULL,
	[ChannelNo] [int] NULL,
	[ComputeStr] [varchar](100) COLLATE Chinese_PRC_CI_AS NULL,
 CONSTRAINT [PK_t_Element_RealTimeLine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'场景ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ScreenID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无素ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ElementID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineName'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取值()' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineCZ'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型(直线、阶梯线)' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineShowType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'样式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineStyle'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标记,不画点' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LinePointBJ'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'线颜色' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineColor'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'MinValue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大值' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'MaxValue'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'小数位长度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ValueDecimal'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'显示格式' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ShowFormat'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间长度' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'TimeLen'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间长度类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'TimeLenType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'时间采样周期' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineCYZQLent'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采样周期类型' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'LineCYZQType'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取值设备ID' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'DeviceID'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取值设备通道' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ChannelNo'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取值表达试' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_Element_RealTimeLine', @level2type=N'COLUMN', @level2name=N'ComputeStr'
