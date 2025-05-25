using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class GenerarFacturaForm : Form
    {
        private readonly FacturaService facturaService;
        private readonly Reserva reserva;
        private readonly Usuario usuarioAutenticado;

        public GenerarFacturaForm(Reserva reserva, FacturaService facturaService, Usuario usuarioAutenticado)
        {
            InitializeComponent();
            this.reserva = reserva;
            this.facturaService = facturaService;
            this.usuarioAutenticado = usuarioAutenticado;

            CargarFacturas();
            AgregarBotonPago();// ✅ Cargar facturas al abrir el formulario
        }
        private void AgregarBotonPago()
        {
            if (usuarioAutenticado.Rol != "Cliente") // 📌 Si es empleado, mostrar botón
            {
                Button btnRegistrarPago = new Button();
                btnRegistrarPago.Text = "Registrar Pago";
                btnRegistrarPago.Size = new System.Drawing.Size(180, 50);
                btnRegistrarPago.Location = new System.Drawing.Point((pnlFactura.Width - 180) / 2, 420);
                btnRegistrarPago.BackColor = System.Drawing.Color.LightBlue;
                btnRegistrarPago.Click += BtnRegistrarPago_Click;

                pnlFactura.Controls.Add(btnRegistrarPago);
            }
        }

        private void CargarFacturas()
        {
            List<Factura> facturas = usuarioAutenticado.Rol == "Cliente"
                ? facturaService.ObtenerFacturasPorCliente(usuarioAutenticado.Id)
                : facturaService.ObtenerFacturasPorCliente(0); // 🔹 Todas las facturas si es administrador

            if (facturas.Any()) // ✅ Si hay facturas, mostrarlas
            {
                dgvFacturas.Visible = true;
                dgvFacturas.DataSource = facturas.Select(f => new
                {
                    f.Id,
                    Cliente = f.ClienteId,
                    Total = f.MontoTotal.ToString("C"),
                    Estado = f.Pagada ? "✅ Pagada" : "⚠ Pendiente",
                    Fecha = f.FechaEmision.ToString("dd/MM/yyyy")
                }).ToList();
            }
            else
            {
                dgvFacturas.Visible = false; // ❌ Si no hay datos, ocultar la tabla
            }
        }


        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                var factura = facturaService.GenerarFactura(reserva.Id, 10); // ✅ Generar factura usando `FacturaService`

                if (factura == null || factura.Id == 0)
                {
                    throw new Exception("❌ La factura no se generó correctamente.");
                }

                // 📌 Mostrar datos en etiquetas
                lblFacturaId.Text = $"Factura ID: {factura.Id}";
                lblClienteId.Text = $"Cliente ID: {factura.ClienteId}";
                lblMontoTotal.Text = $"Total: {factura.MontoTotal:C}";
                lblEstado.Text = factura.Pagada ? "✅ Pagada" : "⚠ Pendiente";
                lblFecha.Text = $"Fecha: {factura.FechaEmision:dd/MM/yyyy}";

                MessageBox.Show("Factura generada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarFacturas(); // ✅ Actualizar la vista después de generar la factura
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generando la factura:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnRegistrarPago_Click(object sender, EventArgs e)
        {
            if (lblFacturaId.Text == "Factura ID: --")
            {
                MessageBox.Show("❌ No se ha generado ninguna factura aún.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int facturaId = int.Parse(lblFacturaId.Text.Replace("Factura ID: ", "").Trim()); // ✅ Extrae el ID de la etiqueta

            var pagoService = new PagoService(Program.DbContext);
            var pagoForm = new PagoForm(facturaId, pagoService);
            pagoForm.ShowDialog();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}
