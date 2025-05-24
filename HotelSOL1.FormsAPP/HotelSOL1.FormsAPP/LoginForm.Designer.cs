using System;
using System.Windows.Forms;
using System.Drawing;

namespace HotelSOL1.FormsAPP
{
    partial class LoginForm
    {
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblEmail, lblContraseña;
        private System.Windows.Forms.TextBox txtEmail, txtContraseña;
        private System.Windows.Forms.Button btnLogin, btnCancelar, btnRegistrarse;

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // 📌 Configuración del formulario
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
            this.BackColor = Color.White;

            // 🎨 Agregar fondo de imagen
            this.BackgroundImage = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Fondo.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            // 🎨 Agregar logo arriba, centrado dinámicamente
            pbLogo = new PictureBox();
            pbLogo.Image = Image.FromFile(@"C:\Users\Administrator\OneDrive\Escritorio\desArrollados\Imagenes\Logo.png");
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.Size = new Size(130, 130);
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Location = new Point((this.ClientSize.Width - pbLogo.Width) / 2, 30);

            // 🔹 Crear un Panel transparente para el formulario de Login
            pnlLogin = new Panel();
            pnlLogin.Size = new Size(400, 250);
            pnlLogin.Location = new Point(
                (this.ClientSize.Width - pnlLogin.Width) / 2,
                (this.ClientSize.Height - pnlLogin.Height) / 2 + 40
            );
            pnlLogin.BackColor = Color.FromArgb(220, 240, 240, 240);
            pnlLogin.Padding = new Padding(20, 40, 20, 20);

            this.Controls.Add(pnlLogin);
            this.Controls.Add(pbLogo);
            pnlLogin.BringToFront();

            // 💡 Configuración de campos dentro del panel
            lblEmail = new Label() { Text = "Email:", Location = new Point(20, 20), ForeColor = Color.Black, AutoSize = true };
            txtEmail = new TextBox() { Location = new Point(20, 50), Size = new Size(350, 30), BackColor = Color.White, ForeColor = Color.Black };

            lblContraseña = new Label() { Text = "Contraseña:", Location = new Point(20, 90), ForeColor = Color.Black, AutoSize = true };
            txtContraseña = new TextBox() { Location = new Point(20, 120), Size = new Size(350, 30), UseSystemPasswordChar = true, BackColor = Color.White, ForeColor = Color.Black };

            btnLogin = new Button() { Text = "Iniciar sesión", Location = new Point(20, 170), Size = new Size(150, 30) };
            btnCancelar = new Button() { Text = "Cancelar", Location = new Point(220, 170), Size = new Size(150, 30) };
            btnRegistrarse = new Button() { Text = "Registrarse", Location = new Point(20, 210), Size = new Size(350, 30) };

            // 🔗 Agregar controles al panel
            pnlLogin.Controls.Add(lblEmail);
            pnlLogin.Controls.Add(txtEmail);
            pnlLogin.Controls.Add(lblContraseña);
            pnlLogin.Controls.Add(txtContraseña);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(btnCancelar);
            pnlLogin.Controls.Add(btnRegistrarse);

            // 🔗 Agregar funcionalidad a los botones
            btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            btnRegistrarse.Click += new System.EventHandler(this.btnRegistrarse_Click);

            this.ResumeLayout(false);
        }
    }

}

