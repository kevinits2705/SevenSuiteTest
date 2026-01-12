using Microsoft.Reporting.WebForms;
using Seveclie.Application.Services;
using Seveclie.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Seveclie.Web
{
    public partial class ClienteReport : Page
    {
        private static ClienteService _clienteService = new ClienteService(new ClienteRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReporte("");
            }
        }

        private void CargarReporte(string filtro)
        {
            var clientes = _clienteService.Consultar(filtro);
            var lista = new List<ClienteDto>();

            foreach (var c in clientes)
            {
                lista.Add(new ClienteDto
                {
                    IdCliente = c.IdCliente,
                    Cedula = c.Cedula,
                    Nombre = c.Nombre,
                    Genero = c.Genero,
                    FechaNacimiento = c.FechaNacimiento.ToString("yyyy-MM-dd"),
                    EstadoCivil = c.EstadoCivil
                });
            }

            ReportViewer1.Reset();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reportes/Clientes.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource rds = new ReportDataSource("ClientesDS", lista);
            ReportViewer1.LocalReport.DataSources.Add(rds);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            //string filtro = txtFiltro.Text.Trim();
            //CargarReporte(filtro);
        }
    }
}
