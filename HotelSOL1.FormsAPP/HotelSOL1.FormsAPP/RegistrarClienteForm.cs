using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class RegistrarClienteForm : Form
    {
        private readonly ClienteService clienteService;

        public RegistrarClienteForm(ClienteService clienteService)
        {
            InitializeComponent();
            this.clienteService = clienteService;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 🔹 Verificar si el email ya está registrado
                if (clienteService.ExisteCliente(txtEmail.Text))
                {
                    MessageBox.Show("❌ Ya existe un cliente con este email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string dni = txtDNI.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string contraseña = txtContraseña.Text.Trim();
                bool vip = chkVIP.Checked;

                var usuarioService = new UsuarioService(Program.DbContext);

                // 🔹 Registrar usuario y obtener la instancia creada
                var usuario = usuarioService.RegistrarUsuarioConCliente(nombre, apellido, email, contraseña, dni, telefono, direccion, vip);

                if (usuario == null || usuario.Id == 0)
                {
                    MessageBox.Show("❌ Error: No se ha generado un ID de usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 🔹 Crear el cliente vinculado al usuario
                var cliente = new Cliente
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    DNI = dni,
                    Direccion = direccion,
                    Email = email,
                    Telefono = telefono,
                    VIP = vip,
                    UsuarioId = usuario.Id  // 🔹 Ahora obtenemos el ID correctamente
                };
                try
                {
                    clienteService.AgregarCliente(cliente);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error al registrar cliente:\n{ex.InnerException?.Message ?? ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("✅ Cliente y usuario registrados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error completo:\n{ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
