$(function () {
    // Cargar estados civiles y clientes al iniciar
    cargarEstados();
    cargarClientes();

    // Limitar fecha máxima a hoy
    const hoy = new Date().toISOString().split("T")[0];
    $("#txtFecha").attr("max", hoy);

    // Validar formulario SOLO para los campos del formulario de cliente
    $("#txtCedula, #txtNombre, #ddlGenero, #txtFecha, #ddlEstadoCivil")
        .on("keyup change", function () {
            validarFormulario();
        });

    // Botón Guardar
    $("#btnGuardar").click(function () {
        Guardar();
    });
});

// ==========================
// Cargar estados civiles
// ==========================
function cargarEstados() {
    $.ajax({
        url: "Clientes.aspx/EstadosCivil",
        type: "POST",
        contentType: "application/json",
        success: function (r) {
            $("#ddlEstadoCivil").empty();
            $("#ddlEstadoCivil").append('<option value="">Seleccione</option>');
            $.each(r.d, function (i, e) {
                $("#ddlEstadoCivil").append(
                    `<option value="${e.IdEstadoCivil}">${e.Descripcion}</option>`
                );
            });
        }
    });
}

// ==========================
// Cargar clientes en la tabla
// ==========================
function cargarClientes() {
    $.ajax({
        url: "Clientes.aspx/Consultar",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ filtro: $("#txtFiltro").val() }),
        success: function (r) {
            let html = "";
            $.each(r.d, function (i, c) {
                // Formatear fecha sin problemas de zona horaria
                const fecha = c.FechaNacimiento
                    ? c.FechaNacimiento.split("-").reverse().join("/")
                    : "";

                html += `
                <tr>
                    <td>${c.Cedula}</td>
                    <td>${c.Nombre}</td>
                    <td>${c.Genero}</td>
                    <td>${fecha}</td>
                    <td>${c.EstadoCivil}</td>
                    <td>
                        <button class="btn btn-sm btn-warning" onclick="editar(${c.IdCliente})">Editar</button>
                        <button class="btn btn-sm btn-danger" onclick="eliminar(${c.IdCliente})">Eliminar</button>
                    </td>
                </tr>`;
            });
            $("#tblClientes").html(html);
        }
    });
}

// ==========================
// Limpiar formulario
// ==========================
function limpiar() {
    $("#hdnIdCliente").val(0);
    $("#txtCedula, #txtNombre, #ddlGenero, #txtFecha, #ddlEstadoCivil").val("");
    $(".text-danger").text(""); // limpiar errores
    $("#btnGuardar").prop("disabled", true);
}

// ==========================
// Validar formulario
// ==========================
function validarFormulario() {
    let valido = true;
    const hoy = new Date().toISOString().split("T")[0];

    // Cédula
    const cedula = $("#txtCedula").val().trim();
    if (!cedula) {
        $("#errCedula").text("La cédula es obligatoria");
        valido = false;
    } else if (!/^[0-9]+$/.test(cedula)) {
        $("#errCedula").text("La cédula solo debe contener números");
        valido = false;
    } else {
        $("#errCedula").text("");
    }

    // Nombre
    const nombre = $("#txtNombre").val().trim();
    if (!nombre) {
        $("#errNombre").text("El nombre es obligatorio");
        valido = false;
    } else if (!/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(nombre)) {
        $("#errNombre").text("El nombre solo debe contener letras");
        valido = false;
    } else {
        $("#errNombre").text("");
    }

    // Género
    if (!$("#ddlGenero").val()) {
        $("#errGenero").text("Seleccione un género");
        valido = false;
    } else {
        $("#errGenero").text("");
    }

    // Fecha
    const fecha = $("#txtFecha").val();
    if (!fecha) {
        $("#errFecha").text("La fecha es obligatoria");
        valido = false;
    } else if (fecha >= hoy) {
        $("#errFecha").text("La fecha no puede ser hoy ni futura");
        valido = false;
    } else {
        $("#errFecha").text("");
    }

    // Estado Civil
    if (!$("#ddlEstadoCivil").val()) {
        $("#errEstado").text("Seleccione estado civil");
        valido = false;
    } else {
        $("#errEstado").text("");
    }

    // Habilitar o deshabilitar botón Guardar
    $("#btnGuardar").prop("disabled", !valido);
    return valido;
}

// ==========================
// Guardar cliente
// ==========================
function Guardar() {
    if (!validarFormulario()) return;

    const cliente = {
        IdCliente: $("#hdnIdCliente").val() || 0,
        Cedula: $("#txtCedula").val(),
        Nombre: $("#txtNombre").val(),
        Genero: $("#ddlGenero").val(),
        FechaNacimiento: $("#txtFecha").val(),
        EstadoCivilId: $("#ddlEstadoCivil").val()
    };

    $.ajax({
        type: "POST",
        url: "Clientes.aspx/Guardar",
        data: JSON.stringify({ dto: cliente }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            if (r.d) {
                alert("Guardado correctamente");
                limpiar();
                cargarClientes();
            } else {
                alert("Error al guardar");
            }
        },
        error: function () {
            alert("Ocurrió un error al guardar");
        }
    });
}

// ==========================
// Editar cliente
// ==========================
function editar(id) {
    $.ajax({
        type: "POST",
        url: "Clientes.aspx/ObtenerPorId",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id: id }),
        dataType: "json",
        success: function (r) {
            const c = r.d;
            if (c) {
                $("#hdnIdCliente").val(c.IdCliente);
                $("#txtCedula").val(c.Cedula);
                $("#txtNombre").val(c.Nombre);
                $("#ddlGenero").val(c.Genero);
                $("#txtFecha").val(c.FechaNacimiento);
                $("#ddlEstadoCivil").val(c.EstadoCivilId || "");
                validarFormulario();
            } else {
                alert("Cliente no encontrado");
            }
        },
        error: function () {
            alert("Ocurrió un error al cargar el cliente");
        }
    });
}

// ==========================
// Eliminar cliente
// ==========================
function eliminar(id) {
    if (!confirm("¿Desea eliminar este cliente?")) return;

    $.ajax({
        type: "POST",
        url: "Clientes.aspx/Eliminar",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id: id }),
        dataType: "json",
        success: function (r) {
            if (r.d) {
                alert("Cliente eliminado correctamente");
                cargarClientes();
            } else {
                alert("Error al eliminar");
            }
        },
        error: function () {
            alert("Ocurrió un error al eliminar");
        }
    });
}

$(function () {
    $('[data-toggle="tooltip"]').tooltip();
});


$(document).ready(function () {

    $("#btnLogout").click(function () {
        cerrarSesion();
    });

});

function cerrarSesion() {
    $.ajax({
        type: "POST",
        url: "Clientes.aspx/CerrarSesion",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            window.location.href = "Login.aspx";
        },
        error: function () {
            alert("Error al cerrar sesión");
        }
    });
}
