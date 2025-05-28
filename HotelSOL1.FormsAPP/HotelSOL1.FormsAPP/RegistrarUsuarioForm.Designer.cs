using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class RegistrarUsuarioForm
    {
        private PictureBox pbLogo;
        private Panel pnlUsuario;
        private Label lblNombre, lblEmail, lblContraseña, lblRol;
        private TextBox txtNombre, txtEmail, txtContraseña;
        private ComboBox cmbRol;
        private Button btnGuardar, btnCancelar;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registrar Usuario";
            this.BackColor = Color.White;

            // 🎨 Fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Logo centrado arriba
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 20);
            this.Controls.Add(pbLogo); // ✅ Agregar logo al formulario

            // 🔹 Panel transparente para organizar los campos
            pnlUsuario = new Panel();
            pnlUsuario.Size = new Size(450, 300);  // ✅ Ajustado para acomodar los elementos
            pnlUsuario.Location = new Point((this.ClientSize.Width - pnlUsuario.Width) / 2, 170);
            pnlUsuario.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlUsuario.Padding = new Padding(20);

            // 📌 Organización en dos columnas
            int col1 = 20;
            int col2 = 230;
            int fila = 20;

            lblNombre = new Label() { Text = "Nombre:", Location = new Point(col1, fila), AutoSize = true };
            txtNombre = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(180, 30) };

            lblEmail = new Label() { Text = "Email:", Location = new Point(col2, fila), AutoSize = true };
            txtEmail = new TextBox() { Location = new Point(col2, fila + 30), Size = new Size(180, 30) };

            fila += 70; // 🔹 Mover a la siguiente fila

            lblContraseña = new Label() { Text = "Contraseña:", Location = new Point(col1, fila), AutoSize = true };
            txtContraseña = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(180, 30), UseSystemPasswordChar = true };

            lblRol = new Label() { Text = "Rol:", Location = new Point(col2, fila), AutoSize = true };
            cmbRol = new ComboBox() { Location = new Point(col2, fila + 30), Size = new Size(180, 30) };
            cmbRol.Items.AddRange(new string[] { "Administrador", "Encargado", "Recepcionista", "Cliente", "Contable", "Personal Limpieza", "Personal Restauración", "Marketing y Publicidad" });

            // 📌 Botones alineados abajo y centrados
            btnGuardar = new Button() { Text = "Guardar", Location = new Point(80, 210), Size = new Size(120, 40), BackColor = Color.LightGreen };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(250, 210), Size = new Size(120, 40), BackColor = Color.LightCoral };

            // 🔗 Agregar controles al panel
            pnlUsuario.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblEmail, txtEmail,
                lblContraseña, txtContraseña,
                lblRol, cmbRol,
                btnGuardar, btnCancelar
            });

            // 🔗 Agregar controles al formulario
            this.Controls.Add(pnlUsuario);
            pnlUsuario.BringToFront(); // ✅ Asegurar que el panel sea visible

            // 🔗 Agregar funcionalidad a los botones
            btnGuardar.Click += new EventHandler(this.btnGuardar_Click);
            btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            this.ResumeLayout(false);
        }
    }
}
