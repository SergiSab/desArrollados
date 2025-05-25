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
            btnFacturasProveedores = new Button();
            btnVolverProv = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = (Image)resources.GetObject("pbLogo.Image");
            pbLogo.Location = new Point(326, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(130, 130);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 2;
            pbLogo.TabStop = false;
            // 
            // btnVerStock
            // 
            btnVerStock.Location = new Point(119, 149);
            btnVerStock.Name = "btnVerStock";
            btnVerStock.Size = new Size(220, 50);
            btnVerStock.TabIndex = 3;
            btnVerStock.Text = "Ver Stock";
            btnVerStock.Click += btnVerStock_Click;
            // 
            // btnVerProveedores
            // 
            btnVerProveedores.Location = new Point(446, 149);
            btnVerProveedores.Name = "btnVerProveedores";
            btnVerProveedores.Size = new Size(220, 50);
            btnVerProveedores.TabIndex = 4;
            btnVerProveedores.Text = "Ver proveedores";
            btnVerProveedores.Click += btnVerProveedores_Click;
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(119, 239);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(220, 50);
            btnPedidos.TabIndex = 5;
            btnPedidos.Text = "Pedidos";
            btnPedidos.Click += btnPedidos_Click;
            // 
            // btnFacturasProveedores
            // 
            btnFacturasProveedores.Location = new Point(446, 239);
            btnFacturasProveedores.Name = "btnFacturasProveedores";
            btnFacturasProveedores.Size = new Size(220, 50);
            btnFacturasProveedores.TabIndex = 7;
            btnFacturasProveedores.Text = "Facturas Proveedores";
            btnFacturasProveedores.Click += btnFacturasProveedores_Click;
            // 
            // btnVolverProv
            // 
            btnVolverProv.BackColor = Color.FromArgb(255, 128, 128);
            btnVolverProv.ForeColor = Color.FromArgb(255, 255, 128);
            btnVolverProv.Location = new Point(280, 331);
            btnVolverProv.Name = "btnVolverProv";
            btnVolverProv.Size = new Size(220, 50);
            btnVolverProv.TabIndex = 8;
            btnVolverProv.Text = "Volver";
            btnVolverProv.UseVisualStyleBackColor = false;
            btnVolverProv.Click += btnVolverProv_Click;
            // 
            // StockProveedoresForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(763, 419);
            Controls.Add(btnVolverProv);
            Controls.Add(btnFacturasProveedores);
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
        private Button btnFacturasProveedores;
        private Button btnVolverProv;
    }
}