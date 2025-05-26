// HotelSOL1.FormsAPP/PedidoDialogForm.cs
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class PedidoDialogForm : Form
    {
        private readonly PedidoService _pedidoService;

        /// <summary>
        /// El objeto que devolvemos con los datos introducidos.
        /// </summary>
        public Pedido PedidoItem { get; private set; }

        /// <summary>
        /// Ctor para alta de nuevo pedido.
        /// </summary>
        public PedidoDialogForm(PedidoService service)
            : this(service, new Pedido()) { }

        /// <summary>
        /// Ctor para edición de un pedido existente.
        /// </summary>
        public PedidoDialogForm(PedidoService service, Pedido existente)
        {
            InitializeComponent();

            _pedidoService = service
                ?? throw new ArgumentNullException(nameof(service));

            // Copiamos los datos si venimos a editar
            PedidoItem = new Pedido
            {
                Id = existente.Id,
                IdProveedor = existente.IdProveedor,
                PrecioTotal = existente.PrecioTotal,
                Albaran = existente.Albaran,
                Factura = existente.Factura
            };

            // Cargamos proveedores desde Program.DbContext
            var proveedores = Program.DbContext.Proveedores
                                   .OrderBy(p => p.Nombre)
                                   .ToList();
            cmbProveedor.DisplayMember = "Nombre";
            cmbProveedor.ValueMember = "IdProveedor";
            cmbProveedor.DataSource = proveedores;

            // Rellenamos controles si editamos
            cmbProveedor.SelectedValue = PedidoItem.IdProveedor;
            numPrecio.Value = PedidoItem.PrecioTotal;
            txtAlbaran.Text = PedidoItem.Albaran;
            txtFactura.Text = PedidoItem.Factura;

            // Enganchamos OK/Cancel
            btnOK.Click += BtnOK_Click;
            btnCancel.Click += (_, __) => DialogResult = DialogResult.Cancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validación mínima
            if (cmbProveedor.SelectedItem == null)
            {
                MessageBox.Show("Debes seleccionar un proveedor.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Volcamos valores de vuelta a PedidoItem
            PedidoItem.IdProveedor = (int)cmbProveedor.SelectedValue!;
            PedidoItem.PrecioTotal = numPrecio.Value;
            PedidoItem.Albaran = txtAlbaran.Text.Trim();
            PedidoItem.Factura = txtFactura.Text.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
