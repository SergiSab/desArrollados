using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class RegistrarClienteForm
    {
        private PictureBox pbLogo;
        private Panel pnlCliente;
        private Label lblNombre, lblApellido, lblDNI, lblDireccion, lblEmail, lblTelefono, lblContraseña;
        private TextBox txtNombre, txtApellido, txtDNI, txtDireccion, txtEmail, txtTelefono, txtContraseña;
        private CheckBox chkVIP;
        private Button btnGuardar, btnCancelar;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Registrar Cliente";
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

            // 🔹 Panel transparente para organizar los campos
            pnlCliente = new Panel();
            pnlCliente.Size = new Size(650, 400);  // ✅ Ampliamos el tamaño para acomodar dos columnas
            pnlCliente.Location = new Point(
                (this.ClientSize.Width - pnlCliente.Width) / 2,
                160 // ✅ Ajustar la posición del panel
            );
            pnlCliente.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlCliente.Padding = new Padding(20);

            // 📌 Organización en dos columnas
            int col1 = 20;  // Primera columna
            int col2 = 330; // Segunda columna
            int fila = 20; // Espaciado vertical entre filas

            lblNombre = new Label() { Text = "Nombre:", Location = new Point(col1, fila), AutoSize = true };
            txtNombre = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(280, 30) };

            lblApellido = new Label() { Text = "Apellido:", Location = new Point(col2, fila), AutoSize = true };
            txtApellido = new TextBox() { Location = new Point(col2, fila + 30), Size = new Size(280, 30) };

            fila += 70; // 🔹 Mover a la siguiente fila

            lblDNI = new Label() { Text = "DNI:", Location = new Point(col1, fila), AutoSize = true };
            txtDNI = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(280, 30) };

            lblDireccion = new Label() { Text = "Dirección:", Location = new Point(col2, fila), AutoSize = true };
            txtDireccion = new TextBox() { Location = new Point(col2, fila + 30), Size = new Size(280, 30) };

            fila += 70;

            lblEmail = new Label() { Text = "Email:", Location = new Point(col1, fila), AutoSize = true };
            txtEmail = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(280, 30) };

            lblTelefono = new Label() { Text = "Teléfono:", Location = new Point(col2, fila), AutoSize = true };
            txtTelefono = new TextBox() { Location = new Point(col2, fila + 30), Size = new Size(280, 30) };

            fila += 70;

            lblContraseña = new Label() { Text = "Contraseña:", Location = new Point(col1, fila), AutoSize = true };
            txtContraseña = new TextBox() { Location = new Point(col1, fila + 30), Size = new Size(280, 30), UseSystemPasswordChar = true };

            chkVIP = new CheckBox() { Text = "¿Cliente VIP?", Location = new Point(col2, fila + 30), AutoSize = true };

            // 📌 Botones alineados abajo y centrados
            btnGuardar = new Button() { Text = "Guardar", Location = new Point(150, 310), Size = new Size(180, 40), BackColor = Color.LightGreen };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(350, 310), Size = new Size(180, 40), BackColor = Color.LightCoral };

            // 🔗 Agregar controles al panel
            pnlCliente.Controls.AddRange(new Control[] {
                lblNombre, txtNombre,
                lblApellido, txtApellido,
                lblDNI, txtDNI,
                lblDireccion, txtDireccion,
                lblEmail, txtEmail,
                lblTelefono, txtTelefono,
                lblContraseña, txtContraseña,
                chkVIP,
                btnGuardar, btnCancelar
            });

            // 🔗 Agregar controles al formulario
            this.Controls.Add(pbLogo);
            this.Controls.Add(pnlCliente);
            pnlCliente.BringToFront(); // ✅ Asegurar que el panel sea visible

            // 🔗 Agregar funcionalidad a los botones
            btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            this.ResumeLayout(false);
        }
    }
}


