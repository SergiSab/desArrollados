using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    partial class ProveedorDialogForm
    {
        private IContainer components = null;
        private Label labelNombre;
        private TextBox txtNombre;
        private Label labelCIF;
        private TextBox txtCIF;
        private Label labelDireccion;
        private TextBox txtDireccion;
        private Label labelTelefono;
        private TextBox txtTelefono;
        private Button btnOK;
        private Button btnCancel;

        /// <summary> 
        /// Configuración de los controles. 
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ProveedorDialogForm));
            labelNombre = new Label();
            txtNombre = new TextBox();
            labelCIF = new Label();
            txtCIF = new TextBox();
            labelDireccion = new Label();
            txtDireccion = new TextBox();
            labelTelefono = new Label();
            txtTelefono = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // labelNombre
            // 
            labelNombre.Location = new Point(26, 72);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(100, 23);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(26, 98);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 27);
            txtNombre.TabIndex = 1;
            // 
            // labelCIF
            // 
            labelCIF.Location = new Point(132, 72);
            labelCIF.Name = "labelCIF";
            labelCIF.Size = new Size(100, 23);
            labelCIF.TabIndex = 2;
            labelCIF.Text = "CIF";
            // 
            // txtCIF
            // 
            txtCIF.Location = new Point(132, 98);
            txtCIF.Name = "txtCIF";
            txtCIF.Size = new Size(100, 27);
            txtCIF.TabIndex = 3;
            // 
            // labelDireccion
            // 
            labelDireccion.Location = new Point(238, 72);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(400, 23);
            labelDireccion.TabIndex = 4;
            labelDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(238, 98);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(400, 27);
            txtDireccion.TabIndex = 5;
            // 
            // labelTelefono
            // 
            labelTelefono.Location = new Point(644, 72);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(100, 23);
            labelTelefono.TabIndex = 6;
            labelTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(644, 98);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 27);
            txtTelefono.TabIndex = 7;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(550, 158);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(87, 35);
            btnOK.TabIndex = 8;
            btnOK.Text = "Aceptar";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(657, 158);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancelar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(26, 25);
            label1.Name = "label1";
            label1.Size = new Size(281, 28);
            label1.TabIndex = 10;
            label1.Text = "Añade los datos del proveedor";
            // 
            // ProveedorDialogForm
            // 
            AcceptButton = btnOK;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            CancelButton = btnCancel;
            ClientSize = new Size(770, 215);
            Controls.Add(label1);
            Controls.Add(labelNombre);
            Controls.Add(txtNombre);
            Controls.Add(labelCIF);
            Controls.Add(txtCIF);
            Controls.Add(labelDireccion);
            Controls.Add(txtDireccion);
            Controls.Add(labelTelefono);
            Controls.Add(txtTelefono);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProveedorDialogForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Datos de Proveedor";
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private Label label1;
    }
}
