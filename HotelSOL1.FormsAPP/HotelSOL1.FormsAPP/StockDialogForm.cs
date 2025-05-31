// HotelSOL1.FormsAPP/StockDialogForm.cs
using HotelSOL.DataAccess.Models;

namespace HotelSOL1.FormsAPP
{
    public partial class StockDialogForm : Form
    {
        public Stock StockItem { get; private set; }

        // Constructor para alta
        public StockDialogForm()
        {
            InitializeComponent();
            StockItem = new Stock();
        }

        // Constructor para edición
        public StockDialogForm(Stock existing) : this()
        {
            StockItem = new Stock
            {
                id = existing.id,
                NombreProducto = existing.NombreProducto,
                Familia = existing.Familia,
                CantidadRestante = existing.CantidadRestante,
                Pvp = existing.Pvp
            };

            // Rellenar campos
            txtProducto.Text = StockItem.NombreProducto;
            txtFamilia.Text = StockItem.Familia;
            numCantidad.Value = StockItem.CantidadRestante;
            numPvp.Value = StockItem.Pvp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validaciones mínimas
            if (string.IsNullOrWhiteSpace(txtProducto.Text))
            {
                MessageBox.Show("El nombre del producto es obligatorio.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Copiar de vuelta a StockItem
            StockItem.NombreProducto = txtProducto.Text.Trim();
            StockItem.Familia = txtFamilia.Text.Trim();
            StockItem.CantidadRestante = (int)numCantidad.Value;
            StockItem.Pvp = numPvp.Value;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
