using System.ComponentModel;

namespace HotelSOL1.FormsAPP
{
    partial class FacturaProveedorForm
    {
        private System.ComponentModel.IContainer components;
        private DataGridView dgvFacturasProv;
        private Button btnGenerarFact;
        private Button btnVerFactura;
        private Button btnVolver;
        private BindingSource facturaProveedorBindingSource;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.facturaProveedorBindingSource = new BindingSource(this.components);
            this.dgvFacturasProv = new DataGridView();
            this.btnGenerarFact = new Button();
            this.btnVerFactura = new Button();
            this.btnVolver = new Button();

            ((ISupportInitialize)(this.dgvFacturasProv)).BeginInit();
            ((ISupportInitialize)(this.facturaProveedorBindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvFacturasProv
            // 
            this.dgvFacturasProv.AutoGenerateColumns = false;
            this.dgvFacturasProv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasProv.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id",           Name = "Id",           HeaderText = "ID",        MinimumWidth = 6, Width = 125 },
                new DataGridViewTextBoxColumn { DataPropertyName = "IdProveedor", Name = "IdProveedor", HeaderText = "Proveedor", MinimumWidth = 6, Width = 125 },
                new DataGridViewTextBoxColumn { DataPropertyName = "IdPedido",    Name = "IdPedido",    HeaderText = "Pedido",    MinimumWidth = 6, Width = 125 },
                new DataGridViewTextBoxColumn { DataPropertyName = "IdAlbaran",   Name = "IdAlbaran",   HeaderText = "Albarán",   MinimumWidth = 6, Width = 125 },
            });
            this.dgvFacturasProv.DataSource = this.facturaProveedorBindingSource;
            this.dgvFacturasProv.Location = new Point(24, 56);
            this.dgvFacturasProv.Name = "dgvFacturasProv";
            this.dgvFacturasProv.RowHeadersWidth = 51;
            this.dgvFacturasProv.Size = new Size(600, 300);
            this.dgvFacturasProv.TabIndex = 0;

            // 
            // btnGenerarFact
            // 
            this.btnGenerarFact.Location = new Point(640, 80);
            this.btnGenerarFact.Name = "btnGenerarFact";
            this.btnGenerarFact.Size = new Size(140, 40);
            this.btnGenerarFact.TabIndex = 1;
            this.btnGenerarFact.Text = "Generar factura";
            this.btnGenerarFact.UseVisualStyleBackColor = true;

            // 
            // btnVerFactura
            // 
            this.btnVerFactura.Location = new Point(640, 140);
            this.btnVerFactura.Name = "btnVerFactura";
            this.btnVerFactura.Size = new Size(140, 40);
            this.btnVerFactura.TabIndex = 2;
            this.btnVerFactura.Text = "Ver factura";
            this.btnVerFactura.UseVisualStyleBackColor = true;

            // 
            // btnVolver
            // 
            this.btnVolver.Location = new Point(640, 200);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new Size(140, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;

            // 
            // FacturaProveedorForm
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(820, 380);
            this.Controls.AddRange(new Control[] {
                this.dgvFacturasProv,
                this.btnGenerarFact,
                this.btnVerFactura,
                this.btnVolver
            });
            this.Name = "FacturaProveedorForm";
            this.Text = "Facturas de Proveedores";
            ((ISupportInitialize)(this.dgvFacturasProv)).EndInit();
            ((ISupportInitialize)(this.facturaProveedorBindingSource)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
