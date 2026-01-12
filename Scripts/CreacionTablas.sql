CREATE TABLE EstadoCivil (
    IdEstadoCivil INT IDENTITY PRIMARY KEY,
    Descripcion VARCHAR(50) NOT NULL
);

CREATE TABLE Seveclie (
    IdCliente INT IDENTITY PRIMARY KEY,
    Cedula VARCHAR(15) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Genero CHAR(1),
    FechaNacimiento DATE,
    IdEstadoCivil INT,
    FOREIGN KEY (IdEstadoCivil) REFERENCES EstadoCivil(IdEstadoCivil)
);

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY PRIMARY KEY,
    Username VARCHAR(50),
    Password VARCHAR(100)
);
