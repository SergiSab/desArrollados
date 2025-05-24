using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class CrearReservaForm : Form
    {
        private readonly ClienteService clienteService;
        private readonly HabitacionService habitacionService;
        private readonly ReservaService reservaService;

        public CrearReservaForm(ClienteService clienteService, HabitacionService habitacionService, ReservaService reservaService)
        {
            InitializeComponent();
            this.clienteService = clienteService;
            this.habitacionService = habitacionService;
   
            try
            {
                var clientes = clienteService.ListarClientes();
                MessageBox.Show($"Clientes cargados: {clientes.Count}"); // Depuración
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "ClienteId";
                cmbClientes.Visible = true;

                var tiposHabitacion = habitacionService.ObtenerTiposHabitacion();
                MessageBox.Show($"Tipos de habitación cargados: {tiposHabitacion.Count}"); // Depuración
                cmbTipo.Items.AddRange(tiposHabitacion.Select(t => t.Nombre).ToArray());
                cmbTipo.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarHabitaciones_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidadPersonas = (int)numPersonas.Value;
                var habitacionesDisponibles = habitacionService.ObtenerHabitacionesDisponibles()
                    .Where(h => h.Capacidad >= cantidadPersonas)
                    .ToList();
                clbHabitaciones.Items.Clear();

                if (!habitacionesDisponibles.Any())
                {
                    MessageBox.Show("No hay habitaciones disponibles.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var habitacion in habitacionesDisponibles)
                {
                    clbHabitaciones.Items.Add(habitacion, false);
                }
                MessageBox.Show("Habitaciones disponibles filtradas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSugerirCombinaciones_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcionalidad aún no implementada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClientes.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int clienteId = (int)cmbClientes.SelectedValue;

                if (dtpEntrada.Value.Date > dtpSalida.Value.Date)
                {
                    MessageBox.Show("La fecha de entrada debe ser anterior a la fecha de salida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<int> habitacionesSeleccionadas = new List<int>();
                foreach (var item in clbHabitaciones.CheckedItems)
                {
                    habitacionesSeleccionadas.Add(((Habitacion)item).Id);
                }
                if (!habitacionesSeleccionadas.Any())
                {
                    MessageBox.Show("Debe seleccionar al menos una habitación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Se utiliza el enum 'EstadoReserva' en vez de una cadena literal.
                var reserva = new Reserva
                {
                    ClienteId = clienteId,
                    FechaInicio = dtpEntrada.Value,
                    FechaFin = dtpSalida.Value,
                    Estado = EstadoReserva.Pendiente
                    // Si existen propiedades adicionales, agrégalas aquí (ej. TipoAlojamiento o Temporada) 
                };

                reservaService.RegistrarReserva(reserva, habitacionesSeleccionadas);
                MessageBox.Show("Reserva creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reserva:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
