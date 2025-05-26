using HotelSOL.DataAccess;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class CrearReservaForm : Form
    {
        private readonly ClienteService clienteService;
        private readonly HabitacionService habitacionService;
        private readonly ReservaService reservaService;
        private readonly Usuario usuarioAutenticado;
        private readonly FacturaService facturaService;
        private readonly HotelSolContext _context; // 🔹 Definir la variable para almacenar la reserva creada
        private ServicioService servicioService; // 🔹 Declarar la variable


        public CrearReservaForm(HotelSolContext context, Usuario usuarioAutenticado, ClienteService clienteService,
                         HabitacionService habitacionService, ReservaService reservaService,
                         FacturaService facturaService, ServicioService servicioService) // ✅ Añadir `servicioService`
        {
            InitializeComponent();
            _context = context;
            this.usuarioAutenticado = usuarioAutenticado;
            this.clienteService = clienteService;
            this.habitacionService = habitacionService;
            this.reservaService = reservaService;
            this.facturaService = facturaService;
            this.servicioService = servicioService; // ✅ Asignar `servicioService`




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

        private Reserva reserva; // ✅ Declarar la variable

        private void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteId;

                if (usuarioAutenticado.Rol == "Cliente")
                {
                    clienteId = usuarioAutenticado.ClienteId.GetValueOrDefault();
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
                    .Where(h => h.TipoId == tipoHabitacion.Id)
                    .Where(h => !_context.ReservaHabitaciones.Any(rh => rh.HabitacionId == h.Id &&
                        _context.Reservas.Any(r => rh.ReservaId == r.Id &&
                            ((dtpEntrada.Value >= r.FechaInicio && dtpEntrada.Value < r.FechaFin) ||
                            (dtpSalida.Value > r.FechaInicio && dtpSalida.Value <= r.FechaFin)))))
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

                // ✅ CREAR LA RESERVA SIN GENERAR FACTURA AUTOMÁTICAMENTE
                reserva = new Reserva
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

                if (reserva.Id == 0)
                {
                    MessageBox.Show("Error: La reserva no se guardó correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Reserva creada correctamente. La factura se podrá generar más adelante.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reserva:\n{ex.Message}\nDetalles internos: {ex.InnerException?.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnServiciosExtra_Click(object sender, EventArgs e)
        {
            if (reserva == null || reserva.Id == 0)
            {
                MessageBox.Show("❌ Primero debes guardar la reserva antes de agregar servicios extra.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var servicioForm = new ServicioForm(reserva.Id, servicioService, reservaService, facturaService);
            servicioForm.ShowDialog();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}