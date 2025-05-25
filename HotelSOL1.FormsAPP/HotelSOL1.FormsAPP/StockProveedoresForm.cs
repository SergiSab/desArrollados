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
    }
}
