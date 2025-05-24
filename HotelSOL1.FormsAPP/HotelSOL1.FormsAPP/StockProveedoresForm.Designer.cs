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
            btnRegistrarUsuario = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            // btnRegistrarUsuario
            // 
            btnRegistrarUsuario.Location = new Point(96, 217);
            btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            btnRegistrarUsuario.Size = new Size(220, 50);
            btnRegistrarUsuario.TabIndex = 3;
            btnRegistrarUsuario.Text = "Ver Stock";
            // 
            // button1
            // 
            button1.Location = new Point(612, 217);
            button1.Name = "button1";
            button1.Size = new Size(220, 50);
            button1.TabIndex = 4;
            button1.Text = "Ver proveedores";
            // 
            // button2
            // 
            button2.Location = new Point(96, 295);
            button2.Name = "button2";
            button2.Size = new Size(220, 50);
            button2.TabIndex = 5;
            button2.Text = "Pedidos";
            // 
            // button3
            // 
            button3.Location = new Point(612, 295);
            button3.Name = "button3";
            button3.Size = new Size(220, 50);
            button3.TabIndex = 6;
            button3.Text = "Albaranes";
            // 
            // button4
            // 
            button4.Location = new Point(96, 375);
            button4.Name = "button4";
            button4.Size = new Size(220, 50);
            button4.TabIndex = 7;
            button4.Text = "Facturas Proveedores";
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
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnRegistrarUsuario);
            Controls.Add(pbLogo);
            Name = "StockProveedoresForm";
            Text = "StockProveedoresForm";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Button btnRegistrarUsuario;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button btnVolverProv;
    }
}