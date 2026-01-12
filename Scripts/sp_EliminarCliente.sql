CREATE PROCEDURE sp_EliminarCliente
    @IdCliente INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN

        DELETE FROM Seveclie
        WHERE IdCliente = @IdCliente

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        THROW;
    END CATCH
END
