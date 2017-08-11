
CREATE TABLE [dbo].[ParentChildMenu](
	[ParentMenuId] [bigint] NULL,
	[ChildMenuId] [bigint] NULL,
	[MenuOrder] [int] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[ParentChildMenu]  WITH CHECK ADD FOREIGN KEY([ChildMenuId])
REFERENCES [dbo].[Menu] ([MenuId])
GO

ALTER TABLE [dbo].[ParentChildMenu]  WITH CHECK ADD FOREIGN KEY([ParentMenuId])
REFERENCES [dbo].[Menu] ([MenuId])
GO