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
VALUES			()