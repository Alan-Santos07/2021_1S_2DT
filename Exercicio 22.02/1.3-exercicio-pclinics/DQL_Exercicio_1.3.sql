-- DQL

USE Pclinics;

SELECT * FROM Atendimentos;

SELECT Clinicas.RazaoSocial, Clinicas.Endereco, Clinicas.CNPJ, Veterinarios.Nomes, Veterinarios.CRMV, 
Donos.NomeDonos, TiposPets.Descricao, Racas.Descricao, Pets.NomePets, Pets.DataNascimento, Atendimentos.Descricao, Atendimentos.DataAtendimento FROM Pets
INNER JOIN Donos
ON Donos.idDonos = Pets.idDonos
INNER JOIN Racas
ON Racas.idRacas = Pets.idRacas
INNER JOIN TiposPets
ON TiposPets.idTiposPets = Racas.idTiposPets
INNER JOIN Atendimentos
ON Atendimentos.idPets = Pets.idPets
INNER JOIN Veterinarios
ON Veterinarios.idVeterinarios = Atendimentos.idVeterinarios
INNER JOIN Clinicas
ON Clinicas.idClinicas = Veterinarios.idClinicas;