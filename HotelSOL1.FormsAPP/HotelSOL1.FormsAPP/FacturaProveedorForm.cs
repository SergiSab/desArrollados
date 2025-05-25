using System;
using System.ComponentModel;
using System.Windows.Forms;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class FacturaProveedorForm : Form
    {
        private readonly FacturaProveedorService _service;
        private readonly PedidoService _pedidoSvc;
        private readonly AlbaranService _albaranSvc;
        private readonly BindingSource _bs = new();
        private BindingList<FacturaProveedor> _list = null!;

        public FacturaProveedorForm(
            FacturaProveedorService service,
            PedidoService pedidoService,
            AlbaranService albaranService)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _pedidoSvc = pedidoService ?? throw new ArgumentNullException(nameof(pedidoService));
            _albaranSvc = albaranService ?? throw new ArgumentNullException(nameof(albaranService));

            Load += FacturaProveedorForm_Load;
            btnGenerarFact.Click += BtnGenerarFact_Click;
            btnVerFactura.Click += BtnVerFactura_Click;
            btnVolver.Click += (_, __) => Close();
        }

        private void FacturaProveedorForm_Load(object sender, EventArgs e)
        {
            var datos = _service.GetAll();
            _list = new BindingList<FacturaProveedor>(datos);
            _bs.DataSource = _list;
            dgvFacturasProv.DataSource = _bs;

            // Aunque ya pusimos los HeaderText en el diseñador, podrías reajustarlos aquí si quieres:
            // dgvFacturasProv.Columns["Id"].HeaderText          = "ID";
            // dgvFacturasProv.Columns["IdProveedor"].HeaderText = "Proveedor";
            // dgvFacturasProv.Columns["IdPedido"].HeaderText    = "Pedido";
            // dgvFacturasProv.Columns["IdAlbaran"].HeaderText   = "Albarán";
        }

        private void BtnGenerarFact_Click(object sender, EventArgs e)
        {
            using var dlg = new FacturaProveedorDialogForm(_pedidoSvc, _albaranSvc);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _service.Add(dlg.FacturaItem);
                _list.Add(dlg.FacturaItem);
            }
        }

        private void BtnVerFactura_Click(object sender, EventArgs e)
        {
            if (dgvFacturasProv.CurrentRow == null) return;
            var sel = (FacturaProveedor)dgvFacturasProv.CurrentRow.DataBoundItem!;
            MessageBox.Show(
                $"Factura #{sel.Id}\nProveedor: {sel.IdProveedor}\nPedido: {sel.IdPedido}\nAlbarán: {sel.IdAlbaran}",
                "Detalle de Factura",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
