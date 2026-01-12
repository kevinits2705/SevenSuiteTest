$(function () {
    $("#btnLogin").click(function () {
        if (!validarLogin()) return;

        const usuario = $("#txtUsuario").val().trim();
        const password = $("#txtPassword").val().trim();

        $.ajax({
            type: "POST",
            url: "Login.aspx/Autenticar",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ usuario: usuario, password: password }),
            success: function (r) {
                if (r.d) {
                    // Login exitoso
                    // Guardar cookie simple (ejemplo)
                    document.cookie = "SesionActiva=true; path=/";
                    window.location.href = "Clientes.aspx";
                } else {
                    alert("Usuario o contraseña incorrectos");
                }
            },
            error: function () {
                alert("Ocurrió un error en el login");
            }
        });
    });
});

// Validación front-end
function validarLogin() {
    let valido = true;

    const usuario = $("#txtUsuario").val().trim();
    if (!usuario) {
        $("#errUsuario").text("El usuario es obligatorio");
        valido = false;
    } else {
        $("#errUsuario").text("");
    }

    const password = $("#txtPassword").val().trim();
    if (!password) {
        $("#errPassword").text("La contraseña es obligatoria");
        valido = false;
    } else {
        $("#errPassword").text("");
    }

    return valido;
}
