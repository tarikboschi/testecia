create table TesteSeusConhecimentos.EnterpriseXUserData (
	IdEnterpriseXUser int identity(1,1) not null primary key,
	IdEnterprise int not null foreign key references TesteSeusConhecimentos.EnterpriseData(IdEnterprise),
	IdUser int not null foreign key references TesteSeusConhecimentos.UserData(IdUser)
)