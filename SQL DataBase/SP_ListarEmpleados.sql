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

		SELECT  E.id, E.Nombre, E.Salario
		FROM dbo.Empleado AS E
		ORDER BY E.Nombre ASC

		SET @outResult = 0
		SET @outMessage = 'Empleados listados exitosamente.'

		SET NOCOUNT OFF;
	END TRY
	BEGIN CATCH
		SET @outResult = 50005
		SET @outMessage = ERROR_MESSAGE()

		SET NOCOUNT OFF;
	END CATCH
END