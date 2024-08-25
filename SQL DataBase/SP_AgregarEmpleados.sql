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
		--Se valida que no exista un empleado en la base de datos
		IF EXISTS (SELECT 1 FROM dbo.Empleado AS E WHERE E.Nombre = @inNombre)
		BEGIN
			SET @outMessage = 'El empleado ya existe';
			SET @outResult = 1;
			RETURN;
		END;

		--En caso de no haberlo, se agrega el empleado
		INSERT INTO dbo.Empleado(
			Nombre
			, Salario)
		VALUES(
			@inNombre
			, @inSalario
		);
    
		--Se guardan los valores de salida del SP
		SET @outResult = 0
		SET @outMessage = 'Empleados agregados exitosamente.'

		SET NOCOUNT OFF;
	END TRY
	BEGIN CATCH
		
		--En caso de que existan errores, se guardan la informaci�n en una tabla
		INSERT INTO dbo.DBErrors
		(
			ErrorNumber
			, ErrorState
			, ErrorSeverity
			, ErrorLine
			, ErrorProcedure
			, ErrorMessage
			, ErrorDateTime
		)
		VALUES 
		(
			ERROR_NUMBER()
			, ERROR_STATE()
			, ERROR_SEVERITY()
			, ERROR_LINE()
			, ERROR_PROCEDURE()
			, ERROR_MESSAGE()
			, GETDATE()
		);

		--Se guardan los valores de salida del SP
		SET @outResult = 50005
		SET @outMessage = ERROR_MESSAGE()
		SET NOCOUNT OFF;
	END CATCH
END