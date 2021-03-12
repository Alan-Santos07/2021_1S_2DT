-- DDL
CREATE DATABASE Locadora;

USE Locadora;

CREATE TABLE Empresas
(
		 idEmpresas INT PRIMARY KEY IDENTITY
		,Nome VARCHAR(200) NOT NULL
);

CREATE TABLE Marcas
(
		idMarcas INT PRIMARY KEY IDENTITY
	   ,NomeMarca VARCHAR(200) NOT NULL
);

CREATE TABLE Modelos
(
		idModelos INT PRIMARY KEY IDENTITY
	   ,idMarcas INT FOREIGN KEY REFERENCES Marcas(idMarcas)
	   ,Descricao VARCHAR(200) NOT NULL
);

CREATE TABLE Veiculos
(
		idVeiculos INT PRIMARY KEY IDENTITY
	   ,idEmpresas INT FOREIGN KEY REFERENCES Empresas(idEmpresas)
	   ,idModelos INT FOREIGN KEY REFERENCES Modelos(idModelos)
	   ,Placa VARCHAR(200) NOT NULL
);

CREATE TABLE Clientes
(	
		idClientes INT PRIMARY KEY IDENTITY
	   ,NomeClientes VARCHAR(200) NOT NULL
	   ,CPF VARCHAR(200) NOT NULL
);

CREATE TABLE ALugueis
(
		idAlugueis INT PRIMARY KEY IDENTITY
	   ,idVeiculos INT FOREIGN KEY REFERENCES Veiculos(idVeiculos)
	   ,idCllientes INT FOREIGN KEY REFERENCES Clientes(idClientes)
	   ,DataInicio DATE NOT NULL
	   ,DataFim DATE NOT NULL
);