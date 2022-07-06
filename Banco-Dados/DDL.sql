CREATE DATABASE ProcessoSeletivo
GO 

USE ProcessoSeletivo
GO

CREATE TABLE TipoUsuario (
  idTipoUsuario SMALLINT PRIMARY KEY IDENTITY,
  nomeTipo VARCHAR(50) NOT NULL
);
GO

CREATE TABLE Usuario(
  idUsuario INT PRIMARY KEY IDENTITY,
  idTipoUsuario SMALLINT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
  nome VARCHAR(100) NOT NULL,
  email VARCHAR(256) UNIQUE NOT NULL,
  senha VARCHAR(15) NOT NULL, 
  statusSituacao BIT NOT NULL
);
GO

