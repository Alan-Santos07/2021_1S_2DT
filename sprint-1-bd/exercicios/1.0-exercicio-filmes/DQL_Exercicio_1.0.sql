-- DQL
USE Filmes;

SELECT * FROM Generos;

SELECT * FROM Filmes;

-- INNER JOIN
SELECT Filmes.Titulo AS Titulo, Generos.Nome AS Genero FROM Filmes
INNER JOIN Generos
ON Filmes.idGenero = Generos.idGenero;