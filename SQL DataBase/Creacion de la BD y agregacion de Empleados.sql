CREATE DATABASE DBTarea1
GO

USE DBTarea1
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.Empleado
(
	id INT IDENTITY(1, 1) PRIMARY KEY
	, Nombre VARCHAR(128) NOT NULL
	, Salario MONEY NOT NULL
);

CREATE TABLE [dbo].[DBErrors](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](100) NULL,
	[ErrorNumber] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorLine] [int] NULL,
	[ErrorProcedure] [varchar](max) NULL,
	[ErrorMessage] [varchar](max) NULL,
	[ErrorDateTime] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]



INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Juan Perez', 200000.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Alejandro Gómez', 21275890.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Valentina Rojas', 1134567.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Sebastián Torres', 568943.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Camila López', 1487654.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Daniel Ramírez', 912345.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Sofía Fernández', 1035678.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Mateo García', 372890.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Martina Sánchez', 692134.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Nicolás Herrera', 1428901.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Isabella Morales', 843276.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Santiago Ruiz', 1056789.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('María Pérez', 498123.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Diego Castro', 1198456.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Gabriela Ortiz', 637890.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Lucas Mendoza', 1342109.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Victoria Jiménez', 852743.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Javier Navarro', 214578.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Emilia Romero', 783495.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Andrés Flores', 1416290.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Natalia Cruz', 957431.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Miguel Paredes', 1078654.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Paula Vargas', 529843.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Juan Ramírez', 1263578.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Laura Guzmán', 689475.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Carlos Aguirre', 1412567.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Mariana Delgado', 356789.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Rodrigo Peña', 835467.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Lucía Herrera', 1230456.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('José Villanueva', 784329.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Antonia Reyes', 1498765.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Francisco Salinas', 315678.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Carolina Vega', 1297543.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Pablo Sosa', 764892.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Andrea Molina', 1354678.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Martín Ríos', 402347.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Julia Serrano', 1176890.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Enrique Espinoza', 875234.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Daniela Domínguez', 1123456.00)

INSERT INTO dbo.Empleado(Nombre, Salario)
VALUES('Manuel Calderón', 698345.00)

