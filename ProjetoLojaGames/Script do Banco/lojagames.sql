-- // CRIANDO O BANCO DE DADOS // --

CREATE DATABASE db_LojaGames;

USE db_LojaGames;

-- // CRIANDO UM USUÁRIO E TENTANDO MUDAR A SENHA DO USUÁRIO ROOT PARA USÁ-LO // --

CREATE USER 'ademir'@'localhost' IDENTIFIED WITH mysql_native_password BY 'Guti1402.';
GRANT ALL PRIVILEGES ON db_lojagames. * TO 'ademir'@'localhost' WITH GRANT OPTION;

ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password
BY 'abacate';
GRANT ALL PRIVILEGES ON db_lojagames. * TO 'root'@'localhost' WITH GRANT OPTION;


-- // CRIANDO AS TABELAS DO BANCO // --

CREATE TABLE tbl_Jogo
(
codjogo int primary key not null,
nomejogo varchar(50) not null,
versaojogo varchar(30),
desenvolvedor varchar(50) not null,
generojogo varchar(40) not null,
faixaetaria varchar(20) not null,
plataforma varchar(20) not null,
anolanc int not null,
sinopse varchar(100) not null
);

CREATE TABLE tbl_Cliente
(
nomecli varchar(50) not null,
cpfcli varchar(14) primary key not null,
dtnasccli datetime not null,
emailcli varchar(30) not null,
cellcli varchar(14) not null,
endecli varchar(100) not null
);

alter table tbl_Cliente modify column cellcli varchar(14);

CREATE TABLE tbl_Func
(
codfunc int primary key not null,
nomefunc varchar(50) not null,
cpffunc varchar(14) not null,
rgfunc varchar(12) not null,
dtnascfunc datetime not null,
endefunc varchar(100) not null,
cellfunc varchar(14) not null,
emailfunc varchar(30) not null,
cargofunc varchar(25) not null
);

alter table tbl_Func modify column cellfunc varchar(14);

alter table tbl_Func change emailfun emailfunc varchar(30);

select* from tbl_Jogo;

select * from tbl_Func;

select * from tbl_Cliente;