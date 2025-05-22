using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    public partial class HabitacionForm : Form
    {
        private readonly HabitacionService habitacionService;
        private Habitacion habitacionActual;

        public HabitacionForm(HabitacionService habitacionService)
        {
            InitializeComponent();
            this.habitacionService = habitacionService;

            // Cargar opciones de tipo de habitación desde la base de datos
            var tiposHabitacion = habitacionService.ObtenerHabitacionesDisponibles()
                .Select(h => h.TipoHabitacion.Nombre)
                .Distinct()
                .ToArray();
            cmbTipo.Items.AddRange(tiposHabitacion);
        }

        private void CargarHabitacion(int habitacionId)
        {
            try
            {
                habitacionActual = habitacionService.ObtenerHabitacionPorId(habitacionId);
                if (habitacionActual != null)
                {
                    cmbTipo.SelectedItem = habitacionActual.TipoHabitacion.Nombre;
                    numCapacidad.Value = habitacionActual.Capacidad;
                    chkDisponible.Checked = habitacionActual.Disponible;
                }
                else
                {
                    LimpiarFormulario();
                    MessageBox.Show("No se encontró la habitación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un tipo de habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var tipoHabitacion = habitacionService.ObtenerTipoHabitacionPorNombre(cmbTipo.SelectedItem.ToString());
                if (tipoHabitacion == null)
                {
                    MessageBox.Show("Tipo de habitación no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevaHabitacion = new Habitacion
                {
                    TipoId = tipoHabitacion.Id,
                    Capacidad = (int)numCapacidad.Value,
                    Disponible = chkDisponible.Checked
                };

                habitacionService.AgregarHabitacion(nuevaHabitacion);
                MessageBox.Show("Habitación registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (habitacionActual == null)
            {
                MessageBox.Show("Seleccione una habitación para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var tipoHabitacion = habitacionService.ObtenerTipoHabitacionPorNombre(cmbTipo.SelectedItem.ToString());
                if (tipoHabitacion == null)
                {
                    MessageBox.Show("Tipo de habitación no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool resultado = habitacionService.ModificarHabitacion(habitacionActual.Id, tipoHabitacion.Nombre, chkDisponible.Checked);
                MessageBox.Show(resultado ? "Habitación modificada correctamente." : "Error al modificar la habitación.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (habitacionActual == null)
            {
                MessageBox.Show("Seleccione una habitación para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool resultado = habitacionService.EliminarHabitacion(habitacionActual.Id);
                MessageBox.Show(resultado ? "Habitación eliminada correctamente." : "No se puede eliminar esta habitación.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la habitación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            cmbTipo.SelectedIndex = -1;
            numCapacidad.Value = 1;
            chkDisponible.Checked = false;
        }
    }
}
