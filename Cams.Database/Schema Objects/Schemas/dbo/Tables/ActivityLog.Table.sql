
CREATE TABLE [dbo].[ActivityLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LoggedBy] [nvarchar](255) NOT NULL,
	[LoggedDate] [datetime] NOT NULL DEFAULT GETDATE(),
	[ActivityRelatedTo] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
