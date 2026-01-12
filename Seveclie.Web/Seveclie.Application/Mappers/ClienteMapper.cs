using Seveclie.Domain.Entities;
using System;

public static class ClienteMapper
{
    public static Cliente ToEntity(ClienteDto dto)
    {
        return new Cliente
        {
            IdCliente = dto.IdCliente,
            Cedula = dto.Cedula,
            Nombre = dto.Nombre,
            Genero = dto.Genero,
            FechaNacimiento = DateTime.Parse(dto.FechaNacimiento),
            EstadoCivilId = dto.EstadoCivilId
        };
    }
}
