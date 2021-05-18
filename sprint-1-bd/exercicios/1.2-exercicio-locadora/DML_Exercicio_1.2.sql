-- DML
USE Locadora;

INSERT INTO Empresas(Nome)
VALUES			('Ford')
			   ,('Toyota');

INSERT INTO Marcas(NomeMarca)
VALUES			('Marca01')
			   ,('Marca02');

INSERT INTO Modelos(idMarcas, Descricao)
VALUES			(1, 'Descrição01')
			   ,(2, 'Descrição02');

INSERT INTO Veiculos(idEmpresas, idModelos, Placa)
VALUES			(1, 1, 'ABC-1234')
			   ,(2, 2, 'XYZ-9876');

INSERT INTO Clientes(NomeClientes, CPF)
VALUES			('Alan', '111.222.333-44')
			   ,('Samuel', '999.888.777-66');

INSERT INTO Alugueis(idVeiculos, idClientes, DataInicio, DataFim)
VALUES			(1, 1, '03/03/2009', '17/04/2020')
			   ,(2, 2, '13/12/2004', '08/01/2021');

			   select * From Marcas
