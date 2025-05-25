namespace HotelSOL1.FormsAPP
{
    partial class PedidoDialogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label labelPrecio;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label labelAlbaran;
        private System.Windows.Forms.TextBox txtAlbaran;
        private System.Windows.Forms.Label labelFactura;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidoDialogForm));
            labelProveedor = new Label();
            cmbProveedor = new ComboBox();
            labelPrecio = new Label();
            numPrecio = new NumericUpDown();
            labelAlbaran = new Label();
            txtAlbaran = new TextBox();
            labelFactura = new Label();
            txtFactura = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            SuspendLayout();
            // 
            // labelProveedor
            // 
            labelProveedor.AutoSize = true;
            labelProveedor.Location = new Point(12, 20);
            labelProveedor.Name = "labelProveedor";
            labelProveedor.Size = new Size(80, 20);
            labelProveedor.TabIndex = 0;
            labelProveedor.Text = "Proveedor:";
            // 
            // cmbProveedor
            // 
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(110, 17);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(393, 28);
            cmbProveedor.TabIndex = 1;
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(12, 60);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(90, 20);
            labelPrecio.TabIndex = 2;
            labelPrecio.Text = "Precio Total:";
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numPrecio.Location = new Point(110, 58);
            numPrecio.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(393, 27);
            numPrecio.TabIndex = 3;
            // 
            // labelAlbaran
            // 
            labelAlbaran.AutoSize = true;
            labelAlbaran.Location = new Point(12, 100);
            labelAlbaran.Name = "labelAlbaran";
            labelAlbaran.Size = new Size(64, 20);
            labelAlbaran.TabIndex = 4;
            labelAlbaran.Text = "Albarán:";
            // 
            // txtAlbaran
            // 
            txtAlbaran.Location = new Point(110, 97);
            txtAlbaran.Name = "txtAlbaran";
            txtAlbaran.Size = new Size(393, 27);
            txtAlbaran.TabIndex = 5;
            // 
            // labelFactura
            // 
            labelFactura.AutoSize = true;
            labelFactura.Location = new Point(12, 140);
            labelFactura.Name = "labelFactura";
            labelFactura.Size = new Size(59, 20);
            labelFactura.TabIndex = 6;
            labelFactura.Text = "Factura:";
            // 
            // txtFactura
            // 
            txtFactura.Location = new Point(110, 137);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(393, 27);
            txtFactura.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(238, 180);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(125, 30);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(378, 180);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(125, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // PedidoDialogForm
            // 
            AcceptButton = btnOK;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnCancel;
            ClientSize = new Size(540, 254);
            Controls.Add(labelProveedor);
            Controls.Add(cmbProveedor);
            Controls.Add(labelPrecio);
            Controls.Add(numPrecio);
            Controls.Add(labelAlbaran);
            Controls.Add(txtAlbaran);
            Controls.Add(labelFactura);
            Controls.Add(txtFactura);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PedidoDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datos de Pedido";
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}