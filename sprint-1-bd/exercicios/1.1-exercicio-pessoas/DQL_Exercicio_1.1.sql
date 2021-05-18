-- DQL
USE Pessoas;

SELECT Pessoas.Nome, Telefones.Numero, Emails.Email, CNH.CNH FROM Pessoas
INNER JOIN Telefones
ON Pessoas.idPessoas = Telefones.idPessoas
INNER JOIN Emails
ON Pessoas.idPessoas = Emails.idEmails
INNER JOIN CNH
ON Pessoas.idPessoas = CNH.idPessoas;
