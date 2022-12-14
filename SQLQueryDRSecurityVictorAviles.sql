USE [DRSecurityVictorAviles]

-------------------------------------------TABLA USUARIO--------------------------
CREATE TABLE Usuario
(
IdUsuario int primary key identity(1,1),
Nombre VARCHAR(50),
ApellidoPaterno VARCHAR(50),
ApellidoMaterno VARCHAR(50),
Correo VARCHAR(50),
Passwoord VARCHAR(50))

-------------------------------------------TABLA Color--------------------------
CREATE TABLE Color
(
	IdColor TINYINT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)
-------------------------------------------TABLA Marca--------------------------
CREATE TABLE Marca
(
	IdMarca INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)
-------------------------------------------TABLA Carro--------------------------
CREATE TABLE Carro
(
	IdCarro INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR (50),
	Modelo  VARCHAR(20), 
	NumeroSerie VARCHAR(50),
	IdColor TINYINT REFERENCES Color(IdColor),
	IdMarca INT REFERENCES Marca(IdMarca)

)


--------------------------INSERT--------------------------
ALTER PROCEDURE [dbo].[CarroAdd]
@Nombre VARCHAR(50),
@Modelo VARCHAR(50),
@NumeroSerie  VARCHAR(50),
@IdColor  VARCHAR(50),
@IdMarca VARCHAR(50)
AS
INSERT INTO Carro(Nombre, Modelo, NumeroSerie, IdColor,IdMarca)
VALUES (@Nombre, @Modelo, @NumeroSerie,@IdColor, @IdMarca)

-----------------------------DELETE------------------

ALTER procedure [dbo].[CarroDelete](
@IdCarro int
)
as
begin
	delete from Carro where IdCarro = @IdCarro
end

--------------------------------GETALL-----------------

ALTER procedure [dbo].[CarroGetAll]
as
begin
	select * from Carro
end
-------------------------------UPDATE--------------------
ALTER procedure [dbo].[CarroUpdate](
@IdCarro int,
@Nombre varchar(100),
@Modelo varchar(100),
@NumeroSerie varchar(100),
@IdColor int, 
@IdMarca int
)
as
begin
	update Carro set Nombre = @Nombre, Modelo = @Modelo , NumeroSerie = @NumeroSerie, IdColor = @IdColor, IdMarca = @IdMarca where IdCarro = @IdCarro
end
