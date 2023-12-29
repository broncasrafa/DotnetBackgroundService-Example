create database DB_Background_Solicitacoes;
GO

create table tbStatus
(
	Id int IDENTITY(1,1) NOT NULL,
	Descricao varchar(255) not null,
	constraint PK_tbStatus PRIMARY KEY (Id)
)

GO
insert into tbStatus (Descricao)
values 
('Solicitado'),
('Aguardando Processamento'),
('Em Processamento'),
('Concluido'),
('Não Executado'),
('Erro')

GO
create table tbSolicitacao
(
	Id int IDENTITY(1,1) NOT NULL,
	DataSolicitacao datetime2 default(getdate()),
	Documento varchar(15) not null,
	IdUsuario int not null,
	IdStatus int not null,

	DataProcessamento_1_Inicio datetime2 null,
	DataProcessamento_1_Fim datetime2 null,
	IdStatusProcessamento_1 int not null,

	DataProcessamento_2_Inicio datetime2 null,
	DataProcessamento_2_Fim datetime2 null,
	IdStatusProcessamento_2 int not null,

	DataProcessamento_3_Inicio datetime2 null,
	DataProcessamento_3_Fim datetime2 null,
	IdStatusProcessamento_3 int not null,

	CONSTRAINT PK_tbSolicitacao PRIMARY KEY (Id),

	CONSTRAINT [FK_tbSolicitacao_tbStatus] FOREIGN KEY([IdStatus]) REFERENCES tbStatus ([Id]),
	CONSTRAINT [FK_tbSolicitacao_tbStatus_Processamento_1] FOREIGN KEY([IdStatusProcessamento_1]) REFERENCES tbStatus ([Id]),
	CONSTRAINT [FK_tbSolicitacao_tbStatus_Processamento_2] FOREIGN KEY([IdStatusProcessamento_2]) REFERENCES tbStatus ([Id]),
	CONSTRAINT [FK_tbSolicitacao_tbStatus_Processamento_3] FOREIGN KEY([IdStatusProcessamento_3]) REFERENCES tbStatus ([Id])
)