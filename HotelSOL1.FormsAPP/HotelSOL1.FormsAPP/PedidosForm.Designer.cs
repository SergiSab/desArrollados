namespace HotelSOL1.FormsAPP
{
    partial class PedidosForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosForm));
            dataGridView1 = new DataGridView();
            btnVerPedido = new Button();
            btnCrearPedido = new Button();
            btnEliminarPedido = new Button();
            btnVolver = new Button();
            labelPedidos = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(68, 127);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(505, 242);
            dataGridView1.TabIndex = 0;
            // 
            // btnVerPedido
            // 
            btnVerPedido.Location = new Point(599, 127);
            btnVerPedido.Name = "btnVerPedido";
            btnVerPedido.Size = new Size(158, 43);
            btnVerPedido.TabIndex = 1;
            btnVerPedido.Text = "Ver Pedido";
            btnVerPedido.UseVisualStyleBackColor = true;
            // 
            // btnCrearPedido
            // 
            btnCrearPedido.Location = new Point(599, 191);
            btnCrearPedido.Name = "btnCrearPedido";
            btnCrearPedido.Size = new Size(158, 43);
            btnCrearPedido.TabIndex = 2;
            btnCrearPedido.Text = "Crear Pedido";
            btnCrearPedido.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPedido
            // 
            btnEliminarPedido.Location = new Point(599, 254);
            btnEliminarPedido.Name = "btnEliminarPedido";
            btnEliminarPedido.Size = new Size(158, 43);
            btnEliminarPedido.TabIndex = 3;
            btnEliminarPedido.Text = "Eliminar Pedido";
            btnEliminarPedido.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(599, 314);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(158, 43);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // labelPedidos
            // 
            labelPedidos.AutoSize = true;
            labelPedidos.BackColor = Color.Transparent;
            labelPedidos.Font = new Font("Segoe UI", 14F);
            labelPedidos.ForeColor = Color.Black;
            labelPedidos.Location = new Point(68, 70);
            labelPedidos.Name = "labelPedidos";
            labelPedidos.Size = new Size(97, 32);
            labelPedidos.TabIndex = 5;
            labelPedidos.Text = "Pedidos";
            // 
            // PedidosForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(labelPedidos);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminarPedido);
            Controls.Add(btnCrearPedido);
            Controls.Add(btnVerPedido);
            Controls.Add(dataGridView1);
            Name = "PedidosForm";
            Text = "PedidosForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnVerPedido;
        private Button btnCrearPedido;
        private Button btnEliminarPedido;
        private Button btnVolver;
        private Label labelPedidos;
    }
}