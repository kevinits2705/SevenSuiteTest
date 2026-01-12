CREATE PROCEDURE sp_GuardarCliente
    @IdCliente INT,
    @Cedula VARCHAR(15),
    @Nombre VARCHAR(100),
    @Genero CHAR(1),
    @FechaNacimiento DATE,
    @IdEstadoCivil INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRAN

        IF @IdCliente = 0
        BEGIN
            INSERT INTO Seveclie
            (Cedula, Nombre, Genero, FechaNacimiento, IdEstadoCivil)
            VALUES
            (@Cedula, @Nombre, @Genero, @FechaNacimiento, @IdEstadoCivil)
        END
        ELSE
        BEGIN
            UPDATE Seveclie
            SET Cedula = @Cedula,
                Nombre = @Nombre,
                Genero = @Genero,
                FechaNacimiento = @FechaNacimiento,
                IdEstadoCivil = @IdEstadoCivil
            WHERE IdCliente = @IdCliente
        END

        COMMIT TRAN
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRAN

        THROW;
    END CATCH
END
