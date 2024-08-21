
USE DBTarea1
GO
--Testeo del sp para listar empleados
DECLARE @message VARCHAR(100), @result INT

EXEC dbo.SP_ListarEmpleados @message OUTPUT, @result OUTPUT

SELECT @message, @result


--Testeo del sp para agregar empleados
USE DBTarea1
GO
DECLARE @messageAgregar VARCHAR(128), @resultAgregar INT

EXEC dbo.SP_AgregarEmpleados 'Alejandro Gómez', 123.00, @messageAgregar OUTPUT, @resultAgregar OUTPUT

SELECT @messageAgregar, @resultAgregar