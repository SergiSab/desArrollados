// HotelSOL1.FormsAPP/StockForm.cs
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;

namespace HotelSOL1.FormsAPP
{
    public partial class StockForm : Form
    {
        private readonly StockService _stockService;

        public StockForm(StockService stockService)
        {
            InitializeComponent();

            _stockService = stockService;
        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            try
            {

                List<Stock> stock = _stockService.ObtenerStock();
                dgvStock.DataSource = stock;

                if (dgvStock.Columns["Id"] != null)
                {
                    dgvStock.Columns["Id"].HeaderText = "ID Stock";
                }
                if (dgvStock.Columns["NombreProducto"] != null)
                {
                    dgvStock.Columns["NombreProducto"].HeaderText = "Nombre Producto";
                }
                if (dgvStock.Columns["Familia"] != null)
                {
                    dgvStock.Columns["Familia"].HeaderText = "Tipo de producto";
                }
                if (dgvStock.Columns["CantidadRestante"] != null)
                {
                    dgvStock.Columns["CantidadRestante"].HeaderText = "Cantidad restante";
                }
                if (dgvStock.Columns["Pvp"] != null)
                {
                    dgvStock.Columns["Pvp"].HeaderText = "PVP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnAñadir_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
