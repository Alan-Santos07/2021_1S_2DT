-- DML

USE Pclinics;

INSERT INTO Clinicas(RazaoSocial, CNPJ, Endereco)
VALUES		 ('Exemplo 01', '11.222.333/0001-55', 'Rua 01, Número 88')
			,('Exemplo 02', '11.666.222/0001-95', 'Rua 02, Número 44')
			,('Exemplo 03', '77.222.333/0771-35', 'Rua 03, Número 99');

INSERT INTO Veterinarios(idClinicas, Nomes, CRMV)
VALUES		 (1, 'Alan', '1234-BA')
			,(2, 'Samuel', '4578-SP')
			,(3, 'João', '7898-AL');

INSERT INTO Donos(NomeDonos)
VALUES		 ('Saulo')
			,('Caique')
			,('Alan');

INSERT INTO TiposPets(Descricao)
VALUES		 ('Cachorro')
			,('Tartaruga')
			,('Aves');

INSERT INTO Racas(idTiposPets, Descricao)
VALUES		 (1, 'Poodle')
			,(2, 'Sternotherus carinatus')
			,(1, 'Golden');

INSERT INTO Pets(idRacas, idDonos, NomePets, DataNascimento)
VALUES		 (2, 1, 'ChuChu', '05/11/1956')
			,(1, 2, 'Sasha', '03/04/2010')
			,(3, 3, 'Rell', '17/06/2015');

INSERT INTO Atendimentos(idVeterinarios, idPets, Descricao, DataAtendimento)
VALUES		 (3, 1, 'Sessão de fotos', '10/10/2010')
			,(2, 2, 'Farpa', '12/12/2012')
			,(1, 3, 'Abraços fofinhos', '03/03/2003');