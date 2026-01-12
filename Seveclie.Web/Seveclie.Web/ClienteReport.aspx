<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClienteReport.aspx.cs" Inherits="Seveclie.Web.ClienteReport" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Reporte de Clientes</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <div class="container mt-4">
            <h3 class="mb-4">Reporte de Clientes</h3>

            <!-- Filtro -->
            <div class="row mb-3">
                <div class="col-md-4">
                    <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" placeholder="Filtrar por nombre o cédula"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
                </div>
            </div>

            <!-- ReportViewer -->
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="500px" ProcessingMode="Local">
            </rsweb:ReportViewer>

        </div>
    </form>
</body>
</html>
