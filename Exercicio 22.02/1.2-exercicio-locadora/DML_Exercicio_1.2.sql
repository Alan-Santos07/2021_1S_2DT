-- DML
USE Locadora;

INSERT INTO Empresas(Nome)
VALUES			('Ford')
			   ,('Toyota');

INSERT INTO Marcas(NomeMarca)
VALUES			('Marca01')
			   ,('Marca02');

INSERT INTO Modelos(idMarcas, Descricao)
VALUES			(1, 'Descri��o01')
			   ,(2, 'Descri��o02');

INSERT INTO Veiculos(idEmpresas, idModelos, Placa)
VALUES			()