using System;
using System.Windows.Forms;
using System.Drawing;
using HotelSOL.DataAccess.Services;
using HotelSOL.DataAccess.Models;

namespace HotelSOL1.FormsAPP
{
    partial class HabitacionForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblNumero, lblTipo, lblCapacidad, lblPrecio, lblDisponible;
        private TextBox txtNumero, txtPrecio;
        private ComboBox cmbTipo;
        private NumericUpDown numCapacidad;
        private CheckBox chkDisponible;
        private Button btnGuardar, btnModificar, btnEliminar;
        private PictureBox picHabitacion;
        private Panel pnlHabitacion;
        private PictureBox pbLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new Size(700, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Gestión de Habitaciones";

            this.BackColor = Color.White;
            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado dinámicamente
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(120, 120);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2);

            // 🔹 Panel principal
            pnlHabitacion = new Panel();
            pnlHabitacion.Size = new Size(600, 300);
            pnlHabitacion.Location = new Point((this.ClientSize.Width - pnlHabitacion.Width) / 2, 80);
            pnlHabitacion.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlHabitacion.Padding = new Padding(20, 40, 20, 20);
            this.Controls.Add(pnlHabitacion);
            pnlHabitacion.BringToFront();

            // 💡 Configuración de campos dentro del panel
            lblNumero = new Label() { Text = "Número:", Location = new Point(20, 20), ForeColor = Color.Black, AutoSize = true };
            txtNumero = new TextBox() { Location = new Point(120, 20), Size = new Size(200, 30) };

            lblTipo = new Label() { Text = "Tipo:", Location = new Point(20, 60), ForeColor = Color.Black, AutoSize = true };
            cmbTipo = new ComboBox() { Location = new Point(120, 60), Size = new Size(200, 30), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += new EventHandler(CmbTipo_SelectedIndexChanged); // 🔹 Evento para actualizar la imagen

            lblCapacidad = new Label() { Text = "Capacidad:", Location = new Point(20, 100), ForeColor = Color.Black, AutoSize = true };
            numCapacidad = new NumericUpDown() { Location = new Point(120, 100), Size = new Size(80, 30), Minimum = 1, Maximum = 6 };

            lblPrecio = new Label() { Text = "Precio Base:", Location = new Point(20, 140), ForeColor = Color.Black, AutoSize = true };
            txtPrecio = new TextBox() { Location = new Point(120, 140), Size = new Size(200, 30) };

            lblDisponible = new Label() { Text = "Disponible:", Location = new Point(20, 180), ForeColor = Color.Black, AutoSize = true };
            chkDisponible = new CheckBox() { Location = new Point(120, 180), Size = new Size(20, 20) };

            // 🎨 Imagen de la habitación
            picHabitacion = new PictureBox();
            picHabitacion.Location = new Point(350, 20);
            picHabitacion.Size = new Size(200, 150);
            picHabitacion.SizeMode = PictureBoxSizeMode.StretchImage;
            picHabitacion.BackColor = Color.LightGray; // 🔹 Fondo por defecto
            pnlHabitacion.Controls.Add(picHabitacion);

            // 🔹 Botones
            btnGuardar = new Button() { Text = "Guardar", Location = new Point(20, 230), Size = new Size(120, 30) };
            btnModificar = new Button() { Text = "Modificar", Location = new Point(160, 230), Size = new Size(120, 30) };
            btnEliminar = new Button() { Text = "Eliminar", Location = new Point(300, 230), Size = new Size(120, 30) };

            pnlHabitacion.Controls.AddRange(new Control[] { lblNumero, txtNumero, lblTipo, cmbTipo, lblCapacidad, numCapacidad, lblPrecio, txtPrecio, lblDisponible, chkDisponible, btnGuardar, btnModificar, btnEliminar });
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnModificar.Click += new EventHandler(btnModificar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);

            this.ResumeLayout(false);
        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem != null)
            {
                var tipoSeleccionado = habitacionService.ObtenerTipoHabitacionPorNombre(cmbTipo.SelectedItem.ToString());

                if (tipoSeleccionado != null && !string.IsNullOrEmpty(tipoSeleccionado.RutaImagen))
                {
                    if (File.Exists(tipoSeleccionado.RutaImagen)) // 🔹 Verifica si el archivo realmente existe
                    {
                        try
                        {
                            using (var stream = new FileStream(tipoSeleccionado.RutaImagen, FileMode.Open, FileAccess.Read))
                            {
                                picHabitacion.Image = Image.FromStream(stream);
                                txtPrecio.Text = tipoSeleccionado.PrecioBase.ToString("C");
                                txtPrecio.ReadOnly = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            picHabitacion.Image = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("La imagen no existe en la ruta indicada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        picHabitacion.Image = null;
                        txtPrecio.Text = "";
                    }
                }
                else
                {
                    picHabitacion.Image = null;
                    txtPrecio.Text = ""; // 🔹 Si no hay imagen asociada, vaciar PictureBox
                }
            }
        }

    }

}
