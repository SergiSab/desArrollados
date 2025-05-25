using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class CrearReservaForm : Form
    {
        private readonly ClienteService clienteService;
        private readonly HabitacionService habitacionService;
        private readonly ReservaService reservaService;
        private readonly Usuario usuarioAutenticado;
        private readonly FacturaService facturaService;

        public CrearReservaForm(Usuario usuarioAutenticado, ClienteService clienteService, HabitacionService habitacionService, ReservaService reservaService, FacturaService facturaService)
        {
            InitializeComponent();
            this.usuarioAutenticado = usuarioAutenticado;
            this.clienteService = clienteService;
            this.habitacionService = habitacionService;
            this.reservaService = reservaService;
            this.facturaService = facturaService;

            // 🔹 Si el usuario autenticado es un cliente, solo puede reservar a su nombre
            if (usuarioAutenticado.Rol == "Cliente")
            {
                cmbClientes.Items.Add(usuarioAutenticado.Nombre);
                cmbClientes.SelectedIndex = 0;
                cmbClientes.Enabled = false;
            }
            else
            {
                var clientes = clienteService.ListarClientes();
                cmbClientes.DataSource = clientes;
                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "ClienteId";
            }
        }

        private void btnBuscarHabitaciones_Click(object sender, EventArgs e)
        {
            if (dtpEntrada.Value.Date >= dtpSalida.Value.Date)
            {
                MessageBox.Show("La fecha de entrada debe ser antes de la fecha de salida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidadPersonas = (int)numPersonas.Value;

            // 🔹 Buscar habitaciones con capacidad suficiente Y disponibles en el rango de fechas seleccionado
            var habitacionesDisponibles = habitacionService.ObtenerHabitacionesDisponiblesEnFechas(cantidadPersonas, dtpEntrada.Value, dtpSalida.Value);

            var tiposDisponibles = habitacionesDisponibles
                .Select(h => h.TipoHabitacion)
                .Distinct()
                .ToList();

            cmbTipo.Items.Clear();

            if (!tiposDisponibles.Any())
            {
                MessageBox.Show("No hay tipos de habitaciones disponibles para estas fechas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 🔹 Mostrar nombre, capacidad (desde habitaciones) y precio en `cmbTipo`
            foreach (var tipo in tiposDisponibles)
            {
                int capacidad = habitacionesDisponibles.FirstOrDefault(h => h.TipoHabitacion.Id == tipo.Id)?.Capacidad ?? 0;
                cmbTipo.Items.Add($"{tipo.Nombre} - Capacidad: {capacidad} - Precio: {tipo.PrecioBase:C}");
            }
        }




        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem != null)
            {
                var tipoNombre = cmbTipo.SelectedItem.ToString().Split('-')[0].Trim();
                var tipoSeleccionado = habitacionService.ObtenerTipoHabitacionPorNombre(tipoNombre);

                if (tipoSeleccionado != null)
                {
                    if (!string.IsNullOrEmpty(tipoSeleccionado.RutaImagen) && File.Exists(tipoSeleccionado.RutaImagen))
                    {
                        picHabitacion.Image = Image.FromFile(tipoSeleccionado.RutaImagen);
                    }
                    else
                    {
                        picHabitacion.Image = null; // 🔹 Vacía el campo en lugar de usar una imagen por defecto
                    }

                    txtPrecio.Text = tipoSeleccionado.PrecioBase.ToString("C");
                    txtPrecio.ReadOnly = true;
                }
                else
                {
                    picHabitacion.Image = null;
                    txtPrecio.Text = "";
                }
            }
        }


        private void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId;

                if (usuarioAutenticado.Rol == "Cliente")
                {
                    clienteId = usuarioAutenticado.Id;
                }
                else
                {
                    if (cmbClientes.SelectedValue == null)
                    {
                        MessageBox.Show("Por favor, seleccione un cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    clienteId = (int)cmbClientes.SelectedValue;
                }

                if (cmbTipo.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un tipo de habitación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tipoSeleccionado = cmbTipo.SelectedItem.ToString().Split('-')[0].Trim();
                var tipoHabitacion = habitacionService.ObtenerTipoHabitacionPorNombre(tipoSeleccionado);
                if (tipoHabitacion == null)
                {
                    MessageBox.Show("Error: No se encontró el tipo de habitación seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int cantidadPersonas = (int)numPersonas.Value;
                List<int> habitacionesSeleccionadas = new List<int>();

                var habitacionesDisponibles = habitacionService.ObtenerHabitacionesDisponibles()
                    .Where(h => h.TipoHabitacion.Id == tipoHabitacion.Id)
                    .OrderBy(h => h.Capacidad)
                    .ToList();

                if (!habitacionesDisponibles.Any())
                {
                    MessageBox.Show("No hay habitaciones disponibles de este tipo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (var habitacion in habitacionesDisponibles)
                {
                    habitacionesSeleccionadas.Add(habitacion.Id);
                    cantidadPersonas -= habitacion.Capacidad;

                    if (cantidadPersonas <= 0) break;
                }

                if (cantidadPersonas > 0)
                {
                    MessageBox.Show("No hay suficientes habitaciones disponibles para cubrir la cantidad de personas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 🔹 1. Guardar la reserva en la base de datos primero
                var reserva = new Reserva
                {
                    ClienteId = clienteId,
                    FechaInicio = dtpEntrada.Value,
                    FechaFin = dtpSalida.Value,
                    Estado = EstadoReserva.Pendiente,
                    ReservaHabitaciones = new List<ReservaHabitaciones>()
                };

                foreach (var habitacionId in habitacionesSeleccionadas)
                {
                    reserva.ReservaHabitaciones.Add(new ReservaHabitaciones
                    {
                        HabitacionId = habitacionId,
                        Reserva = reserva
                    });
                }


                reservaService.RegistrarReserva(reserva, habitacionesSeleccionadas);

                // 🔹 2. Verificar que la reserva se guardó correctamente
                if (reserva.Id == 0)
                {
                    MessageBox.Show("Error: La reserva no se guardó correctamente en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 3. Ahora la reserva tiene un `Id`, podemos generar la factura correctamente
                var factura = facturaService.GenerarFactura(reserva.Id, 10);

                // 🔹 4. Asociar la factura a la reserva y actualizarla en la base de datos
                reserva.Factura = factura;
                reservaService.ActualizarReserva(reserva);

                MessageBox.Show("Reserva creada correctamente con factura asignada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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