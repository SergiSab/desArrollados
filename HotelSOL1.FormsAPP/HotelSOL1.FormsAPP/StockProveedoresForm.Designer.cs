namespace HotelSOL1.FormsAPP
{
    partial class StockProveedoresForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockProveedoresForm));
            pbLogo = new PictureBox();
            btnVerStock = new Button();
            btnVerProveedores = new Button();
            btnPedidos = new Button();
            btnAlbaranes = new Button();
            btnFacturasProveedores = new Button();
            btnVolverProv = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(404, 25);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(130, 130);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            // 
            // btnVerStock
            // 
            btnVerStock.Location = new Point(96, 217);
            btnVerStock.Name = "btnVerStock";
            btnVerStock.Size = new Size(220, 50);
            btnVerStock.TabIndex = 3;
            btnVerStock.Text = "Ver Stock";
            btnVerStock.Click += btnVerStock_Click;
            // 
            // btnVerProveedores
            // 
            btnVerProveedores.Location = new Point(612, 217);
            btnVerProveedores.Name = "btnVerProveedores";
            btnVerProveedores.Size = new Size(220, 50);
            btnVerProveedores.TabIndex = 4;
            btnVerProveedores.Text = "Ver proveedores";
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(96, 295);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(220, 50);
            btnPedidos.TabIndex = 5;
            btnPedidos.Text = "Pedidos";
            // 
            // btnAlbaranes
            // 
            btnAlbaranes.Location = new Point(612, 295);
            btnAlbaranes.Name = "btnAlbaranes";
            btnAlbaranes.Size = new Size(220, 50);
            btnAlbaranes.TabIndex = 6;
            btnAlbaranes.Text = "Albaranes";
            // 
            // btnFacturasProveedores
            // 
            btnFacturasProveedores.Location = new Point(96, 375);
            btnFacturasProveedores.Name = "btnFacturasProveedores";
            btnFacturasProveedores.Size = new Size(220, 50);
            btnFacturasProveedores.TabIndex = 7;
            btnFacturasProveedores.Text = "Facturas Proveedores";
            // 
            // btnVolverProv
            // 
            btnVolverProv.Location = new Point(612, 375);
            btnVolverProv.Name = "btnVolverProv";
            btnVolverProv.Size = new Size(220, 50);
            btnVolverProv.TabIndex = 8;
            btnVolverProv.Text = "Volver";
            // 
            // StockProveedoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(911, 531);
            Controls.Add(btnVolverProv);
            Controls.Add(btnFacturasProveedores);
            Controls.Add(btnAlbaranes);
            Controls.Add(btnPedidos);
            Controls.Add(btnVerProveedores);
            Controls.Add(btnVerStock);
            Controls.Add(pbLogo);
            Name = "StockProveedoresForm";
            Text = "StockProveedoresForm";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Button btnVerStock;
        private Button btnVerProveedores;
        private Button btnPedidos;
        private Button btnAlbaranes;
        private Button btnFacturasProveedores;
        private Button btnVolverProv;
    }
}