-- DDL
CREATE DATABASE Pclinics;

USE Pclinics;

CREATE TABLE Clinicas
(
		idClinicas INT PRIMARY KEY IDENTITY
	   ,RazaoSocial VARCHAR(200) NOT NULL
	   ,CNPJ VARCHAR(200) NOT NULL
	   ,Endereco VARCHAR(200) NOT NULL
);

CREATE TABLE Veterinarios
(
		idVeterinarios INT PRIMARY KEY IDENTITY
	   ,idClinicas INT FOREIGN KEY REFERENCES Clinicas(idClinicas)
	   ,Nomes VARCHAR(200) NOT NULL
	   ,CRMV VARCHAR(200) NOT NULL
);

CREATE TABLE Donos
(
		idDonos INT PRIMARY KEY IDENTITY
	   ,NomeDonos VARCHAR(200) NOT NULL
);

CREATE TABLE TiposPets
(
		idTiposPets INT PRIMARY KEY IDENTITY
	   ,Descricao VARCHAR(200) NOT NULL
);

CREATE TABLE Racas
(
		idRacas INT PRIMARY KEY IDENTITY
	   ,idTiposPets INT FOREIGN KEY REFERENCES TiposPets(idTiposPets)
	   ,Descricao VARCHAR(200) NOT NULL
);

CREATE TABLE Pets
(
		idPets INT PRIMARY KEY IDENTITY
	   ,idRacas INT FOREIGN KEY REFERENCES Racas(idRacas)
	   ,idDonos INT FOREIGN KEY REFERENCES Donos(idDonos)
	   ,NomePets VARCHAR(200) NOT NULL
	   ,DataNascimento DATE NOT NULL
);

CREATE TABLE Atendimentos
(
		idAtendimentos INT PRIMARY KEY IDENTITY
	   ,idVeterinarios INT FOREIGN KEY REFERENCES Veterinarios(idVeterinarios)
	   ,idPets INT FOREIGN KEY REFERENCES Pets(idPets)
	   ,Descricao VARCHAR(200) NOT NULL
	   ,DataAtendimento DATE NOT NULL
);