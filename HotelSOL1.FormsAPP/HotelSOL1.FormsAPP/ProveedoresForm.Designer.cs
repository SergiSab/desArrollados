namespace HotelSOL1.FormsAPP
{
    partial class ProveedoresForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvProveedores;
        private DataGridViewTextBoxColumn idProveedorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cifDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private BindingSource proveedorBindingSource;
        private Button btnModificar;
        private Button btnAnadir;
        private Button btnEliminar;
        private Button btnVolver;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedoresForm));
            dgvProveedores = new DataGridView();
            idProveedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cifDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            direccionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            proveedorBindingSource = new BindingSource(components);
            btnModificar = new Button();
            btnAnadir = new Button();
            btnEliminar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.AutoGenerateColumns = false;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Columns.AddRange(new DataGridViewColumn[] {
                idProveedorDataGridViewTextBoxColumn,
                nombreDataGridViewTextBoxColumn,
                cifDataGridViewTextBoxColumn,
                direccionDataGridViewTextBoxColumn,
                telefonoDataGridViewTextBoxColumn
            });
            dgvProveedores.DataSource = proveedorBindingSource;
            dgvProveedores.Location = new Point(21, 100);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.Size = new Size(679, 385);
            dgvProveedores.TabIndex = 0;
            // 
            // idProveedorDataGridViewTextBoxColumn
            // 
            idProveedorDataGridViewTextBoxColumn.DataPropertyName = "IdProveedor";
            idProveedorDataGridViewTextBoxColumn.HeaderText = "ID";
            idProveedorDataGridViewTextBoxColumn.MinimumWidth = 6;
            idProveedorDataGridViewTextBoxColumn.Name = "idProveedorDataGridViewTextBoxColumn";
            idProveedorDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // cifDataGridViewTextBoxColumn
            // 
            cifDataGridViewTextBoxColumn.DataPropertyName = "CIF";
            cifDataGridViewTextBoxColumn.HeaderText = "CIF";
            cifDataGridViewTextBoxColumn.MinimumWidth = 6;
            cifDataGridViewTextBoxColumn.Name = "cifDataGridViewTextBoxColumn";
            cifDataGridViewTextBoxColumn.Width = 125;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            direccionDataGridViewTextBoxColumn.HeaderText = "Dirección";
            direccionDataGridViewTextBoxColumn.MinimumWidth = 6;
            direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            direccionDataGridViewTextBoxColumn.Width = 200;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "Teléfono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 6;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.Width = 125;
            // 
            // proveedorBindingSource
            // 
            proveedorBindingSource.DataSource = typeof(HotelSOL.DataAccess.Models.Proveedor);
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(744, 110);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(157, 44);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar registro";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAnadir
            // 
            btnAnadir.Location = new Point(744, 180);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(157, 44);
            btnAnadir.TabIndex = 2;
            btnAnadir.Text = "Añadir proveedor";
            btnAnadir.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(744, 251);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(157, 44);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar proveedor";
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
            // ProveedoresForm
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
            Controls.Add(dgvProveedores);
            Name = "ProveedoresForm";
            Text = "Proveedores";
            Load += ProveedoresForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ((System.ComponentModel.ISupportInitialize)proveedorBindingSource).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
