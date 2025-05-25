namespace HotelSOL1.FormsAPP
{
    partial class FacturaProveedorDialogForm
    {
        private System.ComponentModel.IContainer components;
        private Label lblPedido;
        private ComboBox cmbPedido;
        private Label lblAlbaran;
        private ComboBox cmbAlbaran;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblPedido = new Label { Text = "Pedido:", Location = new Point(12, 15), AutoSize = true };
            cmbPedido = new ComboBox { Location = new Point(100, 12), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            lblAlbaran = new Label { Text = "Albarán:", Location = new Point(12, 50), AutoSize = true };
            cmbAlbaran = new ComboBox { Location = new Point(100, 47), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            btnOK = new Button { Text = "Generar", Location = new Point(60, 90), DialogResult = DialogResult.OK, Width = 100 };
            btnCancel = new Button { Text = "Cancelar", Location = new Point(180, 90), DialogResult = DialogResult.Cancel, Width = 100 };

            AcceptButton = btnOK;
            CancelButton = btnCancel;
            ClientSize = new Size(320, 140);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva Factura Proveedor";

            Controls.AddRange(new Control[]
            {
                lblPedido, cmbPedido,
                lblAlbaran, cmbAlbaran,
                btnOK, btnCancel
            });
        }
    }
}
