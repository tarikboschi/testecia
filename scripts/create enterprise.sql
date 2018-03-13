create table TesteSeusConhecimentos.EnterpriseData (
	IdEnterprise int identity(1,1) not null primary key,
	StreetAdress varchar(100),
	City varchar(100),
	State varchar(100),
	ZipCode varchar(100),
	CorporateActivity varchar(100)
);