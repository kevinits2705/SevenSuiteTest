CREATE PROCEDURE sp_ConsultarClientes
    @Filtro VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT c.IdCliente,
           c.Cedula,
           c.Nombre,
           c.Genero,
           c.FechaNacimiento,
           c.IdEstadoCivil,
           e.Descripcion AS EstadoCivil
    FROM Seveclie c
    INNER JOIN EstadoCivil e
        ON c.IdEstadoCivil = e.IdEstadoCivil
    WHERE (@Filtro IS NULL OR @Filtro = '')
       OR c.Nombre LIKE '%' + @Filtro + '%'
       OR c.Cedula LIKE '%' + @Filtro + '%'
END
