SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type IN (N'U'))
BEGIN
	CREATE TABLE [dbo].[Account](
		[AccountNumber] [nvarchar](200) NOT NULL,
		[AccountHolder] [nvarchar](200)NOT NULL,
		[CurrentBalance] [numeric](25, 2) NOT NULL,
		[BankName] [nvarchar](200) NOT NULL,
		[OpeningDate] [datetime] NOT NULL,
		[IsActive] [bit] NOT NULL
	 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
	(
		[AccountNumber] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END
GO