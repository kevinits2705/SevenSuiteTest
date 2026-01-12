<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Seveclie.Web.Clientes" %>

<!DOCTYPE html>
<html>
<head>
    <title>Clientes</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
<div class="container mt-4">
    <div class="row mb-3">
        <div class="col-md-8">
            <h3 class="mb-4">Gestión de Clientes</h3>
        </div>
        <div class="col-md-4">
            <button type="button" id="btnLogout" class="btn btn-danger">
                Cerrar sesión
            </button>
        </div>
    </div>

    <!-- FILTRO -->
    <div class="row mb-3">
        <div class="col-md-4">
            <input type="text" id="txtFiltro" class="form-control" placeholder="Buscar por nombre o cédula" />
        </div>
        <div class="col-md-2">
            <button class="btn btn-primary" onclick="cargarClientes()">Buscar</button>
        </div>
    </div>

    <!-- FORMULARIO -->
    <div class="card mb-4">
        <div class="card-body">

            <input type="hidden" id="hdnIdCliente" />

            <div class="row">
                <div class="col-md-3">
                    <label>Cédula</label>
                    <input type="text" id="txtCedula" class="form-control" data-toggle="tooltip" title="Ingrese su número de cédula sin guiones"/>
                    <span id="errCedula" class="text-danger small"></span>
                </div>

                <div class="col-md-4">
                    <label>Nombre</label>
                    <input type="text" id="txtNombre" class="form-control" data-toggle="tooltip" title="Ingrese su nombre"/>
                    <span id="errNombre" class="text-danger small"></span>
                </div>

                <div class="col-md-2">
                    <label>Género</label>
                    <select id="ddlGenero" class="form-control">
                        <option value="">Seleccione</option>
                        <option value="M">Masculino</option>
                        <option value="F">Femenino</option>
                    </select>
                    <span id="errGenero" class="text-danger small"></span>
                </div>

                <div class="col-md-3">
                    <label>Fecha Nacimiento</label>
                    <input type="date" id="txtFecha" class="form-control" />
                    <span id="errFecha" class="text-danger small"></span>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-md-4">
                    <label>Estado Civil</label>
                    <select id="ddlEstadoCivil" class="form-control"></select>
                    <span id="errEstado" class="text-danger small"></span>
                </div>
            </div>

            <div class="mt-3">
                <button id="btnGuardar" class="btn btn-success" disabled>Guardar</button>
                <button class="btn btn-secondary" onclick="limpiar()">Nuevo</button>
            </div>

        </div>
    </div>

    <!-- TABLA -->
    <table class="table table-bordered table-striped">
        <thead class="table-light">
            <tr>
                <th>Cédula</th>
                <th>Nombre</th>
                <th>Género</th>
                <th>Fecha Nacimiento</th>
                <th>Estado Civil</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody id="tblClientes"></tbody>
    </table>

</div>

<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.bundle.min.js"></script>
<script src="js/clientes.js"></script>

</body>
</html>
