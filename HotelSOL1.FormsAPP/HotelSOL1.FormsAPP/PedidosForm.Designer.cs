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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PedidosForm));
            dgvPedidos = new DataGridView();
            btnCrearPedido = new Button();
            btnEliminarPedido = new Button();
            btnVolver = new Button();
            labelPedidos = new Label();
            pedidoBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idProveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            precioTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            albaranDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            facturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            proveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            albaranesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            facturasProveedoresDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvPedidos
            // 
            dgvPedidos.AutoGenerateColumns = false;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, idProveedorDataGridViewTextBoxColumn, precioTotalDataGridViewTextBoxColumn, albaranDataGridViewTextBoxColumn, facturaDataGridViewTextBoxColumn, proveedorDataGridViewTextBoxColumn, albaranesDataGridViewTextBoxColumn, facturasProveedoresDataGridViewTextBoxColumn });
            dgvPedidos.DataSource = pedidoBindingSource;
            dgvPedidos.Location = new Point(68, 127);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.Size = new Size(505, 242);
            dgvPedidos.TabIndex = 0;
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
            btnVolver.Click += btnVolver_Click;
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
            // pedidoBindingSource
            // 
            pedidoBindingSource.DataSource = typeof(HotelSOL.DataAccess.Models.Pedido);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 125;
            // 
            // idProveedorDataGridViewTextBoxColumn
            // 
            idProveedorDataGridViewTextBoxColumn.DataPropertyName = "IdProveedor";
            idProveedorDataGridViewTextBoxColumn.HeaderText = "IdProveedor";
            idProveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            idProveedorDataGridViewTextBoxColumn.Name = "idProveedorDataGridViewTextBoxColumn";
            idProveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // precioTotalDataGridViewTextBoxColumn
            // 
            precioTotalDataGridViewTextBoxColumn.DataPropertyName = "PrecioTotal";
            precioTotalDataGridViewTextBoxColumn.HeaderText = "PrecioTotal";
            precioTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            precioTotalDataGridViewTextBoxColumn.Name = "precioTotalDataGridViewTextBoxColumn";
            precioTotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // albaranDataGridViewTextBoxColumn
            // 
            albaranDataGridViewTextBoxColumn.DataPropertyName = "Albaran";
            albaranDataGridViewTextBoxColumn.HeaderText = "Albaran";
            albaranDataGridViewTextBoxColumn.MinimumWidth = 6;
            albaranDataGridViewTextBoxColumn.Name = "albaranDataGridViewTextBoxColumn";
            albaranDataGridViewTextBoxColumn.Width = 125;
            // 
            // facturaDataGridViewTextBoxColumn
            // 
            facturaDataGridViewTextBoxColumn.DataPropertyName = "Factura";
            facturaDataGridViewTextBoxColumn.HeaderText = "Factura";
            facturaDataGridViewTextBoxColumn.MinimumWidth = 6;
            facturaDataGridViewTextBoxColumn.Name = "facturaDataGridViewTextBoxColumn";
            facturaDataGridViewTextBoxColumn.Width = 125;
            // 
            // proveedorDataGridViewTextBoxColumn
            // 
            proveedorDataGridViewTextBoxColumn.DataPropertyName = "Proveedor";
            proveedorDataGridViewTextBoxColumn.HeaderText = "Proveedor";
            proveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            proveedorDataGridViewTextBoxColumn.Name = "proveedorDataGridViewTextBoxColumn";
            proveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // albaranesDataGridViewTextBoxColumn
            // 
            albaranesDataGridViewTextBoxColumn.DataPropertyName = "Albaranes";
            albaranesDataGridViewTextBoxColumn.HeaderText = "Albaranes";
            albaranesDataGridViewTextBoxColumn.MinimumWidth = 6;
            albaranesDataGridViewTextBoxColumn.Name = "albaranesDataGridViewTextBoxColumn";
            albaranesDataGridViewTextBoxColumn.Width = 125;
            // 
            // facturasProveedoresDataGridViewTextBoxColumn
            // 
            facturasProveedoresDataGridViewTextBoxColumn.DataPropertyName = "FacturasProveedores";
            facturasProveedoresDataGridViewTextBoxColumn.HeaderText = "FacturasProveedores";
            facturasProveedoresDataGridViewTextBoxColumn.MinimumWidth = 6;
            facturasProveedoresDataGridViewTextBoxColumn.Name = "facturasProveedoresDataGridViewTextBoxColumn";
            facturasProveedoresDataGridViewTextBoxColumn.Width = 125;
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
            Controls.Add(dgvPedidos);
            Name = "PedidosForm";
            Text = "PedidosForm";
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ((System.ComponentModel.ISupportInitialize)pedidoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPedidos;
        private Button btnCrearPedido;
        private Button btnEliminarPedido;
        private Button btnVolver;
        private Label labelPedidos;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn precioTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn albaranDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn facturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn proveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn albaranesDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn facturasProveedoresDataGridViewTextBoxColumn;
        private BindingSource pedidoBindingSource;
    }
}