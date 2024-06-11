drop table Agenda


create table emprestimos
(
	idUsuario int,
    idEmprestimo int primary key,
    vlrEmprestimo decimal(10,4),
    dtValidade date
);


alter table usuario
add cpf varchar(20)

select * from usuario

exec pr_usuario_inclui '<xml><dadoshome><home cpf="587585669" email="leo@email.com" senha="123" /></dadoshome></xml>', 1

alter table usuario
add constraint 
identity (idUsuario)

drop table usuario
create table usuario
(
	idUsuario int primary key identity,
    dsemail varchar(100),
	dssenha varchar(100),
	dscpf varchar(100)
);

create table historico
(
	idHistorico int primary key,
    idTipoAcao int,
    idUsuario int,
    idTransferencia int
);

create table tipoAcoes
(
	idtransacao int primary key,
    Descricao varchar(200)
);

create table transferencia
(
	idTransferencia int primary key,
    descricao varchar(100)
);

drop table despesas
(
	idDespesa int primary key,
    descricao varchar(200)
);


