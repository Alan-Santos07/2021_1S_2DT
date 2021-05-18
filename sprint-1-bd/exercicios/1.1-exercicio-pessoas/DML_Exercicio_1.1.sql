-- DML
USE Pessoas;

INSERT INTO Pessoas(Nome)
VALUES		 ('Alan')
			,('Samuel');

INSERT INTO Telefones(idPessoas, Numero)
VALUES		 (1, '11-94002-8922')
			,(2, '11-97070-7070');

INSERT INTO Emails(idPessoas, Email)
VALUES		 (1, 'alan@email.com')
			,(2, 'samuel@email.com');

INSERT INTO CNH(idPessoas, CNH)
VALUES		 (1, '000123456789')
			,(2, '001234567899');