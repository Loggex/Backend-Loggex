USE [DB_Loggex]

INSERT INTO tiposUsuarios(nomeTipoUsuario)
VALUES ('Gestor'), ('Motorista')
GO

INSERT INTO usuarios(idTipoUsuario, nome, sexo, imgPerfil, cpf)
VALUES
(1, 'André Melo','Masculino', 'teste.png', '975.561.650-00'),
(2, 'José João Barros', 'Masculino', 'teste.png', '035.669.960-92')
GO

INSERT INTO motoristas(idUsuario, cnh,numCelular)
VALUES
	(2, '33122560859', '11918273645')
GO

INSERT INTO gestor(idUsuario, email,senha)
VALUES
	(1, 'andremelo@email.com', 'andresenhas')
GO

INSERT INTO tiposVeiculos(tipoCarreta, tipoVeiculo, modeloVeiculo, tipoCarroceria)
VALUES
	('Rodotrem', 'Caminhão 4x2', 'R 620', 'Baú Frigorifico'),
	('Vanderleia', 'Caminhão 6x2', 'F-4000', 'Caçamba')
GO

INSERT INTO veiculos(idTipoVeiculo, placa, anoFabricacao, seguro, cor, chassi, estadoVeiculo, quilometragem, descricao)
VALUES
	(1, 'CZN4342', 2018, 1, 'Prata', '3AA eAG510 2c 6B1818', 1, 15000,''),
	(2, 'EHI8409', 2022, 1, 'Preto', '1r4 lhh7Jf A8 328460', 0, 25320,'teste')
GO

INSERT INTO imgVeiculos(idVeiculo, enderecoImagem)
VALUES
	(1, '../teste.png'), (2, '../teste.png')
GO

INSERT INTO situacoes(tituloSituacao)
VALUES
	('Agendada'), ('Em progresso'), ('Finalizada')
GO


INSERT INTO rotas(idSituacao, idVeiculo, idMotorista, origem, destino, dataPartida, dataChegada, carga, pesoBrutoCarga, volumeCarga, descricao)
VALUES
	(2, 1, 1, 'Paraty-RJ', 'São Paulo-SP', 22/03/2022, 23/03/2022, 'Alimentícios', 50.000, 30.00, 'Essa carga leva carnes de Paraty até São Paulo')
GO

INSERT INTO tiposPecas(idSituacao, nomePeça)
VALUES
	(1, 'Pneus'), (1, 'Parachoque'), (1, 'Parabrisa'), (1, 'Retrovisores'), (1, 'Refrigeracao'), (1, 'Cinto de segurança'), (1, 'Escapamento')
GO

INSERT INTO Pecas(idTipoPeca, idVeiculo, estadoPeca, imgPeca)
VALUES
	(1, 1, 1, '.../teste.png'),
	(2, 1, 1, '.../teste.png'),
	(3, 1, 0, '.../teste.png'),
	(4, 1 ,1, '.../teste.png'),
	(5, 1, 1, '.../teste.png'),
	(6, 1, 0, '.../teste.png'),
	(7, 1, 1, '.../teste.png')
GO

INSERT INTO logAlteracao(idPeca, estadoAlteracao, dataAlteracao)
VALUES
	(2,  0, 25/03/2022),
	(2,  0, 26/03/2022),
	(3,  1, 27/03/2022),
	(4, 0, 28/03/2022),
	(5,  1, 29/03/2022),
	(6,  1, 30/03/2022),
	(7,  0, 31/03/2022)
GO
