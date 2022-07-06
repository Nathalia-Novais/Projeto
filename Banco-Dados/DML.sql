USE ProcessoSeletivo;

INSERT into TipoUsuario(nomeTipo)
VALUES ('geral'),('admin'),('root');
go

Select * From TipoUsuario

INSERT into Usuario(idTipoUsuario,nome,email,senha,statusSituacao)
VALUES (3,'Root','root@email.com','root123',1),(2,'Admin','admin@email.com','admin123',1)
,(1,'Maria','maria@email.com','geral123',1),(1,'João','joao@email.com','joao123',1);
go

Select * From Usuario