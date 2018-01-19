CREATE TABLE [TesteSeusConhecimentos].[CompanyData] (
    [IdCompany]         INT         IDENTITY (1, 1) NOT NULL,
    [Name]              NCHAR (250) NOT NULL,
    [StreetAddress]     NCHAR (500) NULL,
    [City]              NCHAR (250) NULL,
    [State]             NCHAR (250) NULL,
    [ZipCode]           NCHAR (10)  NULL,
    [CorporateActivity] NCHAR (250) NULL,
    CONSTRAINT [PK_CompanyData] PRIMARY KEY CLUSTERED ([IdCompany] ASC)
);

CREATE TABLE [TesteSeusConhecimentos].[RelationShipData] (
    [IdUser]    INT NOT NULL,
    [IdCompany] INT NOT NULL,
    CONSTRAINT [PK_RelationShipData] PRIMARY KEY CLUSTERED ([IdUser] ASC, [IdCompany] ASC),
    CONSTRAINT [FK_UserCompany_Company] FOREIGN KEY ([IdCompany]) REFERENCES [TesteSeusConhecimentos].[CompanyData] ([IdCompany]),
    CONSTRAINT [FK_UserCompany_User] FOREIGN KEY ([IdUser]) REFERENCES [TesteSeusConhecimentos].[UserData] ([IdUser])
);

