namespace HotelSOL1.FormsAPP
{
    partial class AsientoContableDialogForm
    {
        private System.ComponentModel.IContainer components;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Button btnOK;
        private Button btnCancel;

        /// <summary> 
        /// Limpia los recursos en uso.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Inicializa el diseñador de WinForms.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // Fecha
            lblFecha = new Label
            {
                Text = "Fecha:",
                Location = new Point(12, 15),
                AutoSize = true
            };
            dtpFecha = new DateTimePicker
            {
                Location = new Point(100, 12),
                Width = 200
            };

            // Descripción
            lblDescripcion = new Label
            {
                Text = "Descripción:",
                Location = new Point(12, 50),
                AutoSize = true
            };
            txtDescripcion = new TextBox
            {
                Location = new Point(100, 47),
                Width = 300
            };

            // Nº Documento
            lblDocumento = new Label
            {
                Text = "NumDocumento:",
                Location = new Point(12, 85),
                AutoSize = true
            };
            txtDocumento = new TextBox
            {
                Location = new Point(100, 82),
                Width = 200
            };

            // Botones
            btnOK = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(100, 130),
                Size = new Size(100, 30)
            };
            btnCancel = new Button
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new Point(220, 130),
                Size = new Size(100, 30)
            };

            // Propiedades del Form
            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
            this.ClientSize = new Size(420, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Nuevo Asiento Contable";

            // Añade controles
            this.Controls.AddRange(new Control[]
            {
                lblFecha, dtpFecha,
                lblDescripcion, txtDescripcion,
                lblDocumento, txtDocumento,
                btnOK, btnCancel
            });
        }
    }
}
