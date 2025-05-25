using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class StockProveedoresForm : Form
    {
        public StockProveedoresForm()
        {
            InitializeComponent();
        }

        private void btnVerStock_Click(object sender, EventArgs e)
        {
            var stockService = new StockService(Program.DbContext);
            var form = new StockForm(stockService);
            form.ShowDialog();
        }
        private void btnPedidos_Click(object sender, EventArgs e)
        {
            var pedidoService = new PedidoService(Program.DbContext);
            var form = new PedidosForm(pedidoService);
            form.ShowDialog();
        }
        private void btnVolverProv_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVerProveedores_Click(object sender, EventArgs e)
        {
            var proveedorService = new ProveedorService(Program.DbContext);
            var form = new ProveedoresForm(proveedorService);
            form.ShowDialog();
        }

        private void btnFacturasProveedores_Click(object sender, EventArgs e)
        {
            var ctx = Program.DbContext;

            // Inicializamos cada servicio con ese contexto
            var pedidoSvc = new PedidoService(ctx);
            var albaranSvc = new AlbaranService(ctx);
            var facturaProvSvc = new FacturaProveedorService(ctx);

            // Instanciamos el formulario de facturas de proveedores
            using var form = new FacturaProveedorForm(facturaProvSvc, pedidoSvc, albaranSvc);
            form.ShowDialog(this);
        }
    }
}
