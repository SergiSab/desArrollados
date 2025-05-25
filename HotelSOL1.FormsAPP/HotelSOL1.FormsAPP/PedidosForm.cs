using System;
using System.Linq;
using System.Windows.Forms;
using HotelSOL.DataAccess;
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class PedidosForm : Form

    {
        public PedidosForm()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
