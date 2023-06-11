-- Organizations

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [PK_NewTable] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

-- Messages

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[Priority] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[Text01] [nvarchar](50) NULL,
	[Text02] [nvarchar](50) NULL,
	[Text03] [nvarchar](50) NULL,
	[Text04] [nvarchar](50) NULL,
	[Text05] [nvarchar](50) NULL,
	[Text06] [nvarchar](50) NULL,
	[Text07] [nvarchar](50) NULL,
	[Text08] [nvarchar](50) NULL,
	[Text09] [nvarchar](50) NULL,
	[Text10] [nvarchar](50) NULL,
	[Text11] [nvarchar](50) NULL,
	[Text12] [nvarchar](50) NULL,
	[Text13] [nvarchar](50) NULL,
	[Text14] [nvarchar](50) NULL,
	[Text15] [nvarchar](50) NULL,
	[Text16] [nvarchar](50) NULL,
	[Text17] [nvarchar](50) NULL,
	[Text18] [nvarchar](50) NULL,
	[Text19] [nvarchar](50) NULL,
	[Text20] [nvarchar](50) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Message] ADD  CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[rowid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

