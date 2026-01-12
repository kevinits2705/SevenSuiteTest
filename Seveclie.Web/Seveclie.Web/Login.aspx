<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Seveclie.Web.Login" %>

<!DOCTYPE html>
<html>
<head>
    <title>Login - Seven Suite</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa;
        }
        .login-container {
            max-width: 400px;
            margin-top: 100px;
        }
    </style>
</head>
<body>

<div class="container login-container">
    <h3 class="text-center mb-4">Iniciar Sesión</h3>

    <div class="card">
        <div class="card-body">

            <div class="mb-3">
                <label for="txtUsuario" class="form-label">Usuario</label>
                <input type="text" id="txtUsuario" class="form-control" title="Ingrese su usuario" />
                <span id="errUsuario" class="text-danger"></span>
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">Contraseña</label>
                <input type="password" id="txtPassword" class="form-control" title="Ingrese su contraseña" />
                <span id="errPassword" class="text-danger"></span>
            </div>

            <div class="d-grid">
                <button id="btnLogin" class="btn btn-primary">Ingresar</button>
            </div>

        </div>
    </div>
</div>

<script src="js/jquery.min.js"></script>
<script src="js/bootstrap.bundle.min.js"></script>
<script src="js/login.js"></script>

</body>
</html>
