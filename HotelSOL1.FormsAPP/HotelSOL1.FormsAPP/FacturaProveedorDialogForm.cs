using System;
using System.Windows.Forms;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class FacturaProveedorDialogForm : Form
    {
        private readonly PedidoService _pedidoService;
        private readonly AlbaranService _albaranService;

        public FacturaProveedor FacturaItem { get; private set; }

        public FacturaProveedorDialogForm(
            PedidoService pedidoService,
            AlbaranService albaranService)
        {
            InitializeComponent();
            _pedidoService = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
            _albaranService = albaranService ?? throw new ArgumentNullException(nameof(albaranService));

            // Carga pedidos
            cmbPedido.DataSource = _pedidoService.GetAll();
            cmbPedido.DisplayMember = "Id";
            cmbPedido.ValueMember = "Id";

            // Al cambiar pedido, recarga albaranes correspondientes
            cmbPedido.SelectedIndexChanged += (_, __) =>
            {
                if (cmbPedido.SelectedItem is Pedido p)
                {
                    cmbAlbaran.DataSource = _albaranService.GetByPedidoId(p.Id);
                    cmbAlbaran.DisplayMember = "Id";
                    cmbAlbaran.ValueMember = "Id";
                }
            };

            // Botón OK
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!(cmbPedido.SelectedItem is Pedido p))
            {
                MessageBox.Show("Debes elegir un pedido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            if (!(cmbAlbaran.SelectedItem is Albaran a))
            {
                MessageBox.Show("Debes elegir un albarán.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            FacturaItem = new FacturaProveedor
            {
                IdProveedor = p.IdProveedor,
                IdPedido = p.Id,
                IdAlbaran = a.Id
            };

            DialogResult = DialogResult.OK;
        }
    }
}
