using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class ReservasForm : Form
    {
        private readonly ReservaService _reservaService;

        public Reserva ReservaSeleccionada { get; private set; }

        public ReservasForm(ReservaService reservaService)
        {
            InitializeComponent();
            _reservaService = reservaService;
            this.Load += new EventHandler(this.ReservasForm_Load);
        }

        private void ReservasForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 📌 Verificar autenticación
                if (!UsuarioAutenticadoValido()) return;

                // 📌 Filtrar reservas según el rol del usuario
                List<Reserva> reservas = FiltrarReservasPorRol();
                CargarReservasEnTabla(reservas);

                // 📌 Ocultar botones de Check-In y Check-Out si el usuario es Cliente
                ConfigurarInterfazSegunRol();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al cargar las reservas:\n{ex.Message}");
            }
        }

        private bool UsuarioAutenticadoValido()
        {
            if (Program.UsuarioAutenticado == null)
            {
                MostrarMensajeError("❌ No hay usuario autenticado.");
                this.Close();
                return false;
            }
            return true;
        }

        private List<Reserva> FiltrarReservasPorRol()
        {
            return Program.UsuarioAutenticado.Rol == "Cliente"
                ? _reservaService.ObtenerReservas().Where(r => r.ClienteId == Program.UsuarioAutenticado.Id).ToList()
                : _reservaService.ObtenerReservas();
        }

        private void CargarReservasEnTabla(List<Reserva> reservas)
        {
            dgvReservas.DataSource = reservas.Select(r => new
            {
                r.Id,
                Cliente = r.Cliente != null ? r.Cliente.Nombre : "Desconocido",
                FechaInicio = r.FechaInicio.ToString("dd/MM/yyyy"),
                FechaFin = r.FechaFin.ToString("dd/MM/yyyy"),
                Estado = r.Estado.ToString()
            }).ToList();
        }

        private void ConfigurarInterfazSegunRol()
        {
            if (Program.UsuarioAutenticado.Rol == "Cliente")
            {
                btnCheckIn.Visible = false;
                btnCheckOut.Visible = false;
            }
        }

        private Reserva ObtenerReservaSeleccionada()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MostrarMensajeError("❌ Seleccione una reserva antes de continuar.");
                return null;
            }

            int reservaId = Convert.ToInt32(dgvReservas.SelectedRows[0].Cells["Id"].Value);
            return _reservaService.ObtenerReservaPorId(reservaId);
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            if (ConfirmarAccion("¿Desea registrar el Check-In?"))
            {
                if (_reservaService.RegistrarCheckIn(reservaSeleccionada.Id))
                {
                    MostrarMensajeExito("✅ Check-In registrado con éxito.");
                    ActualizarReservas();
                }
                else
                {
                    MostrarMensajeError("❌ No se pudo registrar el Check-In.");
                }
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            if (ConfirmarAccion("¿Desea registrar el Check-Out?"))
            {
                if (_reservaService.RegistrarCheckOut(reservaSeleccionada.Id))
                {
                    MostrarMensajeExito("✅ Check-Out registrado con éxito.");
                    ActualizarReservas();
                }
                else
                {
                    MostrarMensajeError("❌ No se pudo registrar el Check-Out.");
                }
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (!UsuarioAutenticadoValido()) return;

            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            var facturaService = new FacturaService(Program.DbContext);
            var clienteService = new ClienteService(Program.DbContext);
            var usuarioAutenticado = Program.UsuarioAutenticado;

            var formFactura = new GenerarFacturaForm(
                reservaSeleccionada,
                facturaService,
                clienteService,
                usuarioAutenticado,
                Program.DbContext
            );
            formFactura.ShowDialog();
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            if (!UsuarioAutenticadoValido()) return;

            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            var servicioForm = new ServicioForm(reservaSeleccionada.Id, new ServicioService(Program.DbContext), _reservaService, new FacturaService(Program.DbContext));
            servicioForm.ShowDialog();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            var servicioForm = new ServicioForm(
                reservaSeleccionada.Id,
                new ServicioService(Program.DbContext),
                _reservaService,
                new FacturaService(Program.DbContext)
            );

            servicioForm.ShowDialog();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            if (Program.UsuarioAutenticado.Rol != "Administrador") return; // Solo administradores pueden buscar

            string filtro = txtBuscarCliente.Text.Trim().ToLower();
            var reservasFiltradas = _reservaService.ObtenerReservas()
                .Where(r => r.Cliente != null && r.Cliente.Nombre.ToLower().Contains(filtro))
                .Select(r => new
                {
                    r.Id,
                    Cliente = r.Cliente.Nombre,
                    FechaInicio = r.FechaInicio.ToString("dd/MM/yyyy"),
                    FechaFin = r.FechaFin.ToString("dd/MM/yyyy"),
                    Estado = r.Estado.ToString()
                }).ToList();

            dgvReservas.DataSource = reservasFiltradas;
        }


        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            var reservaSeleccionada = ObtenerReservaSeleccionada();
            if (reservaSeleccionada == null) return;

            MessageBox.Show($"Detalles de la reserva:\nCliente: {reservaSeleccionada.Cliente.Nombre}\nEstado: {reservaSeleccionada.Estado}",
                            "Detalles de Reserva", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (ConfirmarAccion("¿Desea salir de la gestión de reservas?"))
            {
                this.Close();
            }
        }

        private void ActualizarReservas()
        {
            ReservasForm_Load(null, null);
        }

        private bool ConfirmarAccion(string mensaje)
        {
            return MessageBox.Show(mensaje, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
