CREATE TABLE [dbo].[Menu](	
	[MenuId] [bigint] NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[MenuDescription] [nvarchar](max) NULL,
	[IsMenuActive] [bit] NOT NULL,
	[IsAckcezioneUser] [bit] NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO