// HotelSOL1.FormsAPP/PedidosForm.cs
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using System.ComponentModel;

namespace HotelSOL1.FormsAPP
{
    public partial class PedidosForm : Form
    {
        private readonly PedidoService _service;
        private readonly BindingSource _bs = new BindingSource();
        private BindingList<Pedido> _lista = null!;

        public PedidosForm(PedidoService service)
        {
            InitializeComponent();
            _service = service;

            this.Load += PedidosForm_Load;
            btnCrearPedido.Click += BtnCrearPedido_Click;
            btnEliminarPedido.Click += BtnEliminarPedido_Click;
            btnVolver.Click += (_, __) => Close();
        }

        private void PedidosForm_Load(object sender, EventArgs e)
        {
            var datos = _service.GetAll();
            _lista = new BindingList<Pedido>(datos);
            _bs.DataSource = _lista;
            dgvPedidos.DataSource = _bs;

            // Ajusta un par de columnas
            if (dgvPedidos.Columns["Id"] != null)
                dgvPedidos.Columns["Id"].HeaderText = "ID";

            if (dgvPedidos.Columns["Proveedor"] != null)
                dgvPedidos.Columns["Proveedor"].HeaderText = "Proveedor";
        }

        private void BtnCrearPedido_Click(object sender, EventArgs e)
        {
            using var dlg = new PedidoDialogForm(_service);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _service.Add(dlg.PedidoItem);
                _lista.Add(dlg.PedidoItem);
            }
        }

        private void BtnEliminarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow == null) return;
            var sel = (Pedido)dgvPedidos.CurrentRow.DataBoundItem!;
            if (MessageBox.Show(
                    $"¿Eliminar pedido #{sel.Id}?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                _service.Delete(sel.Id);
                _lista.Remove(sel);
            }
        }
        private void btnVolver_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
