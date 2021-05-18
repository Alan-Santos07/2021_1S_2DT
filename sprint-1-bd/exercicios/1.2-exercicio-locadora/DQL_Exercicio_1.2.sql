-- DQL
USE Locadora;

SELECT Empresas.Nome, Modelos.Descricao, Marcas.NomeMarca, Veiculos.Placa, Clientes.NomeClientes, Clientes.CPF, ALugueis.DataInicio, ALugueis.DataFim FROM Empresas
INNER JOIN Veiculos
ON Empresas.idEmpresas = Veiculos.idEmpresas
INNER JOIN ALugueis
ON Veiculos.idVeiculos = ALugueis.idVeiculos
INNER JOIN Clientes
ON ALugueis.idClientes = Clientes.idClientes
INNER JOIN Modelos
ON Modelos.idModelos = Veiculos.idVeiculos
INNER JOIN Marcas
ON Marcas.idMarcas = Modelos.idMarcas;