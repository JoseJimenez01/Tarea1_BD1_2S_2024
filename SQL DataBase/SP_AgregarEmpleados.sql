USE DBTarea1
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.SP_AgregarEmpleados
(
	@inNombre VARCHAR(128)
	, @inSalario MONEY
	, @outMessage VARCHAR(128) OUTPUT
	, @outResult INT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON;
		IF EXISTS (SELECT 1 FROM dbo.Empleado AS E WHERE E.Nombre = @inNombre)
		BEGIN
			SET @outMessage = 'El empleado ya existe';
			SET @outResult = 1;
			RETURN;
		END;

		INSERT INTO dbo.Empleado(
			Nombre
			, Salario)
		VALUES(
			@inNombre
			, @inSalario
		);
		SET @outResult = 0
		SET @outMessage = 'Empleados agregados exitosamente.'

		SET NOCOUNT OFF;
	END TRY
	BEGIN CATCH
		SET @outResult = 50005
		SET @outMessage = ERROR_MESSAGE()
		SET NOCOUNT OFF;
	END CATCH
END