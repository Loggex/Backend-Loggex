CREATE DATABASE [DB_Loggex]
GO

USE [DB_Loggex]
GO

CREATE TABLE tiposUsuarios (
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	nomeTipoUsuario VARCHAR(10) UNIQUE NOT NULL 
);
GO

CREATE TABLE usuarios(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tiposUsuarios(idTipoUsuario),
	nome VARCHAR(50),
	sexo VARCHAR(10),	
	imgPerfil VARCHAR(255),
	cpf VARCHAR(20) UNIQUE
); 
GO

CREATE TABLE motoristas (
	idMotorista INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	cnh VARCHAR(50) UNIQUE NOT NULL,
	numCelular VARCHAR(25) UNIQUE NOT NULL,
);
GO

CREATE TABLE gestor (
	idGestor INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	email VARCHAR(100) UNIQUE,
	senha VARCHAR(100) NOT NULL
);
GO

CREATE TABLE tiposVeiculos(
	idTipoVeiculo INT PRIMARY KEY IDENTITY,
	tipoCarreta VARCHAR (100),
	tipoVeiculo VARCHAR (100),
	modeloVeiculo VARCHAR (100),
	tipoCarroceria VARCHAR (100)
);
GO

CREATE TABLE veiculos(
	idVeiculo INT PRIMARY KEY IDENTITY,
	idTipoVeiculo INT FOREIGN KEY REFERENCES tiposVeiculos(idTipoVeiculo) NOT NULL,
	placa VARCHAR (8) NOT NULL UNIQUE,
	anoFabricacao INT,
	seguro BIT,
	cor VARCHAR(20),
	chassi VARCHAR(20),
	estadoVeiculo BIT NOT NULL,
	quilometragem  DECIMAL (10,1),
	descricao VARCHAR(255)
);
GO

CREATE TABLE imgVeiculos (
	idImagem INT PRIMARY KEY IDENTITY,
	idVeiculo INT FOREIGN KEY REFERENCES veiculos(idVeiculo),
	enderecoImagem VARCHAR(255)  NOT NULL
); 
GO

CREATE TABLE situacoes (
	idSituacao INT PRIMARY KEY IDENTITY,
	tituloSituacao VARCHAR(20)  NOT NULL
); 
GO

CREATE TABLE rotas(
	idRota INT PRIMARY KEY IDENTITY,
	idSituacao INT FOREIGN KEY REFERENCES situacoes(idSituacao),
	idVeiculo INT FOREIGN KEY REFERENCES veiculos(idVeiculo),
	idMotorista INT FOREIGN KEY REFERENCES motoristas(idMotorista),
	origem VARCHAR(100) NOT NULL,
	destino VARCHAR(100) NOT NULL,
	dataPartida DATETIME,
	dataChegada DATETIME,
	carga VARCHAR(100),
	pesoBrutoCarga DECIMAL(5,3),
	volumeCarga DECIMAL(10,2),
	descricao VARCHAR(300)
); 
GO

CREATE TABLE tiposPecas (
	idTipoPeca INT PRIMARY KEY IDENTITY,
	idTipoVeiculo INT FOREIGN KEY REFERENCES tiposVeiculos(idTipoVeiculo),
	nomePeça VARCHAR(50)  NOT NULL
); 
GO

CREATE TABLE Pecas (
	idPeca INT PRIMARY KEY IDENTITY,
	idTipoPeca INT FOREIGN KEY REFERENCES tiposPecas(idTipoPeca),
	idVeiculo INT FOREIGN KEY REFERENCES veiculos(idVeiculo),
	estadoPeca BIT NOT NULL,
	imgPeca VARCHAR(255),
	imgPecaC VARCHAR(255),
	semelhanca DECIMAL(6,5) 
); 
GO

CREATE TABLE logAlteracao (
	idLog INT PRIMARY KEY IDENTITY,
	idPeca INT FOREIGN KEY REFERENCES Pecas(idPeca),
	estadoAlteracao BIT NOT NULL,
	dataAlteracao DATETIME NOT NULL
); 
GO

