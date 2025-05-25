namespace HotelSOL1.FormsAPP
{
    partial class StockForm
    {
        
        private System.ComponentModel.IContainer components = null;

   
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            dgvStock = new DataGridView();
            nombreProductoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            familiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadRestanteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pvpDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockBindingSource = new BindingSource(components);
            btnModificar = new Button();
            btnAnadir = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stockBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvStock
            // 
            dgvStock.AutoGenerateColumns = false;
            dgvStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStock.Columns.AddRange(new DataGridViewColumn[] { nombreProductoDataGridViewTextBoxColumn, familiaDataGridViewTextBoxColumn, cantidadRestanteDataGridViewTextBoxColumn, pvpDataGridViewTextBoxColumn });
            dgvStock.DataSource = stockBindingSource;
            dgvStock.Location = new Point(21, 100);
            dgvStock.Name = "dgvStock";
            dgvStock.RowHeadersWidth = 51;
            dgvStock.Size = new Size(679, 385);
            dgvStock.TabIndex = 0;
            // 
            // nombreProductoDataGridViewTextBoxColumn
            // 
            nombreProductoDataGridViewTextBoxColumn.DataPropertyName = "NombreProducto";
            nombreProductoDataGridViewTextBoxColumn.HeaderText = "NombreProducto";
            nombreProductoDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreProductoDataGridViewTextBoxColumn.Name = "nombreProductoDataGridViewTextBoxColumn";
            nombreProductoDataGridViewTextBoxColumn.Width = 125;
            // 
            // familiaDataGridViewTextBoxColumn
            // 
            familiaDataGridViewTextBoxColumn.DataPropertyName = "Familia";
            familiaDataGridViewTextBoxColumn.HeaderText = "Familia";
            familiaDataGridViewTextBoxColumn.MinimumWidth = 6;
            familiaDataGridViewTextBoxColumn.Name = "familiaDataGridViewTextBoxColumn";
            familiaDataGridViewTextBoxColumn.Width = 125;
            // 
            // cantidadRestanteDataGridViewTextBoxColumn
            // 
            cantidadRestanteDataGridViewTextBoxColumn.DataPropertyName = "CantidadRestante";
            cantidadRestanteDataGridViewTextBoxColumn.HeaderText = "CantidadRestante";
            cantidadRestanteDataGridViewTextBoxColumn.MinimumWidth = 6;
            cantidadRestanteDataGridViewTextBoxColumn.Name = "cantidadRestanteDataGridViewTextBoxColumn";
            cantidadRestanteDataGridViewTextBoxColumn.Width = 125;
            // 
            // pvpDataGridViewTextBoxColumn
            // 
            pvpDataGridViewTextBoxColumn.DataPropertyName = "Pvp";
            pvpDataGridViewTextBoxColumn.HeaderText = "Pvp";
            pvpDataGridViewTextBoxColumn.MinimumWidth = 6;
            pvpDataGridViewTextBoxColumn.Name = "pvpDataGridViewTextBoxColumn";
            pvpDataGridViewTextBoxColumn.Width = 125;
            // 
            // stockBindingSource
            // 
            stockBindingSource.DataSource = typeof(HotelSOL.DataAccess.Models.Stock);
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(744, 110);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(157, 44);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar entrada";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAnadir
            // 
            btnAnadir.Location = new Point(744, 180);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(157, 44);
            btnAnadir.TabIndex = 2;
            btnAnadir.Text = "Añadir elemento";
            btnAnadir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(744, 251);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(157, 44);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar elemento";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(744, 320);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(157, 44);
            btnVolver.TabIndex = 4;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1186, 610);
            Controls.Add(btnVolver);
            Controls.Add(btnEliminar);
            Controls.Add(btnAnadir);
            Controls.Add(btnModificar);
            Controls.Add(dgvStock);
            Name = "StockForm";
            Text = "StockForm";
            Load += StockForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)stockBindingSource).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvStock;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreProductoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn familiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadRestanteDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pvpDataGridViewTextBoxColumn;
        private BindingSource stockBindingSource;
        private Button btnModificar;
        private Button btnAnadir;
        private Button btnEliminar;
        private Button btnVolver;
    }
}