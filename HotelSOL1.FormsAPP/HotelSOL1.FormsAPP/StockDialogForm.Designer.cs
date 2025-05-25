// HotelSOL1.FormsAPP/StockDialogForm.Designer.cs
namespace HotelSOL1.FormsAPP
{
    partial class StockDialogForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtProducto;
        private TextBox txtFamilia;
        private NumericUpDown numCantidad;
        private NumericUpDown numPvp;
        private Button btnOK;
        private Button btnCancel;
        private Label lblProd, lblFam, lblCant, lblPvp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockDialogForm));
            txtProducto = new TextBox();
            txtFamilia = new TextBox();
            numCantidad = new NumericUpDown();
            numPvp = new NumericUpDown();
            btnOK = new Button();
            btnCancel = new Button();
            lblProd = new Label();
            lblFam = new Label();
            lblCant = new Label();
            lblPvp = new Label();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPvp).BeginInit();
            SuspendLayout();
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(100, 12);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(347, 27);
            txtProducto.TabIndex = 1;
            // 
            // txtFamilia
            // 
            txtFamilia.Location = new Point(100, 47);
            txtFamilia.Name = "txtFamilia";
            txtFamilia.Size = new Size(347, 27);
            txtFamilia.TabIndex = 3;
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(100, 83);
            numCantidad.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(267, 27);
            numCantidad.TabIndex = 5;
            // 
            // numPvp
            // 
            numPvp.DecimalPlaces = 2;
            numPvp.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numPvp.Location = new Point(100, 118);
            numPvp.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPvp.Name = "numPvp";
            numPvp.Size = new Size(267, 27);
            numPvp.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(100, 160);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 38);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(200, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(118, 38);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblProd
            // 
            lblProd.AutoSize = true;
            lblProd.Location = new Point(12, 15);
            lblProd.Name = "lblProd";
            lblProd.Size = new Size(72, 20);
            lblProd.TabIndex = 0;
            lblProd.Text = "Producto:";
            // 
            // lblFam
            // 
            lblFam.AutoSize = true;
            lblFam.Location = new Point(12, 50);
            lblFam.Name = "lblFam";
            lblFam.Size = new Size(59, 20);
            lblFam.TabIndex = 2;
            lblFam.Text = "Familia:";
            // 
            // lblCant
            // 
            lblCant.AutoSize = true;
            lblCant.Location = new Point(12, 85);
            lblCant.Name = "lblCant";
            lblCant.Size = new Size(72, 20);
            lblCant.TabIndex = 4;
            lblCant.Text = "Cantidad:";
            // 
            // lblPvp
            // 
            lblPvp.AutoSize = true;
            lblPvp.Location = new Point(12, 120);
            lblPvp.Name = "lblPvp";
            lblPvp.Size = new Size(37, 20);
            lblPvp.TabIndex = 6;
            lblPvp.Text = "PVP:";
            // 
            // StockDialogForm
            // 
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(488, 270);
            Controls.Add(lblProd);
            Controls.Add(txtProducto);
            Controls.Add(lblFam);
            Controls.Add(txtFamilia);
            Controls.Add(lblCant);
            Controls.Add(numCantidad);
            Controls.Add(lblPvp);
            Controls.Add(numPvp);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datos de Stock";
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPvp).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
