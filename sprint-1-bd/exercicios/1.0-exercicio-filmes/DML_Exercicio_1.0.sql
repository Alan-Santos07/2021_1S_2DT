-- DML
USE Filmes;

INSERT INTO Generos(Nome)
VALUES			 ('Terror')
				,('Fantasia');

INSERT INTO Filmes(Titulo, idGenero)
VALUES			 ('Harry Potter', 2)
				,('Invoca��o do Mal', 1)
				,('Midsommar', 1);