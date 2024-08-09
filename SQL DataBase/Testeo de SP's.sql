
USE DBTarea1
GO

DECLARE @message VARCHAR(100), @result INT

EXEC dbo.SP_ListarEmpleados @message OUTPUT, @result OUTPUT

SELECT @message, @result

