USE [GDK_BCM]
GO
/****** 对象:  Table [dbo].[t_GalleryClassification]    脚本日期: 09/08/2012 05:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_GalleryClassification](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](16) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Description] [nvarchar](100) COLLATE Chinese_PRC_CI_AS NULL,
	[Sort] [int] NOT NULL CONSTRAINT [DF_t_GalleryClassification_Sort]  DEFAULT ((99999)),
 CONSTRAINT [PK_t_GalleryClassification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类Id' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_GalleryClassification', @level2type=N'COLUMN', @level2name=N'Id'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_GalleryClassification', @level2type=N'COLUMN', @level2name=N'Name'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类说明' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_GalleryClassification', @level2type=N'COLUMN', @level2name=N'Description'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序字段' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_GalleryClassification', @level2type=N'COLUMN', @level2name=N'Sort'

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图库分类表' ,@level0type=N'SCHEMA', @level0name=N'dbo', @level1type=N'TABLE', @level1name=N't_GalleryClassification'
