using HotelSOL.DataAccess.Models;

namespace HotelSOL1.FormsAPP
{
    public partial class ProveedorDialogForm : Form
    {
        public Proveedor ProveedorItem { get; private set; }

        // Alta
        public ProveedorDialogForm() : this(new Proveedor()) { }

        // Edición
        public ProveedorDialogForm(Proveedor existente)
        {
            InitializeComponent();

            // Copia los valores
            ProveedorItem = new Proveedor
            {
                IdProveedor = existente.IdProveedor,
                Nombre = existente.Nombre,
                CIF = existente.CIF,
                Direccion = existente.Direccion,
                Telefono = existente.Telefono
            };

            // Rellena los TextBox
            txtNombre.Text = ProveedorItem.Nombre;
            txtCIF.Text = ProveedorItem.CIF;
            txtDireccion.Text = ProveedorItem.Direccion;
            txtTelefono.Text = ProveedorItem.Telefono;

            // Asocia el OK
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCIF.Text))
            {
                MessageBox.Show("El CIF es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Volcar de vuelta a ProveedorItem
            ProveedorItem.Nombre = txtNombre.Text.Trim();
            ProveedorItem.CIF = txtCIF.Text.Trim();
            ProveedorItem.Direccion = txtDireccion.Text.Trim();
            ProveedorItem.Telefono = txtTelefono.Text.Trim();

            DialogResult = DialogResult.OK;
        }
        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
