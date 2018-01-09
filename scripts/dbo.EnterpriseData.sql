CREATE TABLE [TesteSeusConhecimentos].[EnterpriseData](
	[IdEnterprise] [int] IDENTITY(1,1) NOT NULL,
	[Company] VARCHAR(100) NULL,
	[StreetAdress] [varchar](100) NULL,
	[City] [varchar](100) NULL,
	[State] [varchar](2) NULL,
	[ZipCode] [varchar](8) NULL,
	[CorporateActivity] [varchar](100) NULL,
 CONSTRAINT [PK_EnterpriseData] PRIMARY KEY CLUSTERED 
(
	[IdEnterprise] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
