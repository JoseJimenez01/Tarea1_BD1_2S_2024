USE DBTarea1
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE dbo.SP_ListarEmpleados
(
	@outMessage VARCHAR(128) OUTPUT
	, @outResult INT OUTPUT
)
AS
BEGIN
	BEGIN TRY
		SET NOCOUNT ON;

		--Se listan todos los empleados de la base de datos
		SELECT  E.id, E.Nombre, E.Salario
		FROM dbo.Empleado AS E
		ORDER BY E.Nombre ASC

		--Se guardan los valores de salida del SP
		SET @outResult = 0
		SET @outMessage = 'Empleados listados exitosamente.'

		SET NOCOUNT OFF;
	END TRY
	BEGIN CATCH
		
		--En caso de que existan errores, se guardan la información en una tabla
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
		)

		--Se guardan los valores de salida del SP
		SET @outResult = 50005
		SET @outMessage = ERROR_MESSAGE()
		SET NOCOUNT OFF;
	END CATCH
END