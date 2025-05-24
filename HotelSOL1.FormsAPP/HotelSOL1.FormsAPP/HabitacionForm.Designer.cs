namespace HotelSOL1.FormsAPP
{
    partial class HabitacionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.NumericUpDown numCapacidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblDisponible;
        private System.Windows.Forms.CheckBox chkDisponible;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.PictureBox picHabitacion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.numCapacidad = new System.Windows.Forms.NumericUpDown();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblDisponible = new System.Windows.Forms.Label();
            this.chkDisponible = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.picHabitacion = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHabitacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.Text = "Número:";
            this.lblNumero.Location = new System.Drawing.Point(20, 20);
            this.lblNumero.Size = new System.Drawing.Size(80, 23);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(120, 20);
            this.txtNumero.Size = new System.Drawing.Size(200, 23);
            // 
            // lblTipo
            // 
            this.lblTipo.Text = "Tipo:";
            this.lblTipo.Location = new System.Drawing.Point(20, 60);
            this.lblTipo.Size = new System.Drawing.Size(80, 23);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.Location = new System.Drawing.Point(120, 60);
            this.cmbTipo.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.Text = "Capacidad:";
            this.lblCapacidad.Location = new System.Drawing.Point(20, 100);
            this.lblCapacidad.Size = new System.Drawing.Size(80, 23);
            // 
            // numCapacidad
            // 
            this.numCapacidad.Location = new System.Drawing.Point(120, 100);
            this.numCapacidad.Size = new System.Drawing.Size(60, 23);
            this.numCapacidad.Minimum = 1;
            this.numCapacidad.Maximum = 6;
            // 
            // lblPrecio
            // 
            this.lblPrecio.Text = "Precio Base:";
            this.lblPrecio.Location = new System.Drawing.Point(20, 140);
            this.lblPrecio.Size = new System.Drawing.Size(80, 23);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(120, 140);
            this.txtPrecio.Size = new System.Drawing.Size(200, 23);
            // 
            // lblDisponible
            // 
            this.lblDisponible.Text = "Disponible:";
            this.lblDisponible.Location = new System.Drawing.Point(20, 180);
            this.lblDisponible.Size = new System.Drawing.Size(80, 23);
            // 
            // chkDisponible
            // 
            this.chkDisponible.Location = new System.Drawing.Point(120, 180);
            this.chkDisponible.Size = new System.Drawing.Size(20, 20);
            // 
            // picHabitacion
            // 
            this.picHabitacion.Location = new System.Drawing.Point(350, 20);
            this.picHabitacion.Size = new System.Drawing.Size(200, 150);
            this.picHabitacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(20, 310);
            this.btnGuardar.Size = new System.Drawing.Size(80, 30);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Text = "Modificar";
            this.btnModificar.Location = new System.Drawing.Point(120, 310);
            this.btnModificar.Size = new System.Drawing.Size(80, 30);
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(220, 310);
            this.btnEliminar.Size = new System.Drawing.Size(80, 30);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // HabitacionForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.numCapacidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblDisponible);
            this.Controls.Add(this.chkDisponible);
            this.Controls.Add(this.picHabitacion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Text = "Gestión de Habitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            ((System.ComponentModel.ISupportInitialize)(this.numCapacidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHabitacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
