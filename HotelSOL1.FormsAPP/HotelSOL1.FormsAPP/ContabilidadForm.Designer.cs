// HotelSOL1.FormsAPP/ContabilidadForm.Designer.cs
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HotelSOL1.FormsAPP
{
    partial class ContabilidadForm
    {
        private IContainer components = null;
        private DataGridView dgvAsientos;
        private DataGridView dgvLineas;
        private Button btnNuevoAsiento;
        private Button btnBorrarAsiento;
        private Button btnVolver;
        private BindingSource asientoBindingSource;
        private BindingSource lineaBindingSource;

        /// <summary> 
        /// Limpia los recursos que se estén usando. 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary> 
        /// Método necesario para el Diseñador — no lo modifiques 
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            var resources = new ComponentResourceManager(typeof(ContabilidadForm));

            // Inicializamos las BindingSource
            this.asientoBindingSource = new BindingSource(this.components);
            this.lineaBindingSource = new BindingSource(this.components);

            // 
            // dgvAsientos
            // 
            this.dgvAsientos = new DataGridView
            {
                Name = "dgvAsientos",
                Location = new Point(20, 20),
                Size = new Size(480, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoGenerateColumns = true,
                DataSource = this.asientoBindingSource
            };
            // 
            // dgvLineas
            // 
            this.dgvLineas = new DataGridView
            {
                Name = "dgvLineas",
                Location = new Point(520, 20),
                Size = new Size(480, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AutoGenerateColumns = true,
                DataSource = this.lineaBindingSource
            };
            // 
            // btnNuevoAsiento
            // 
            this.btnNuevoAsiento = new Button
            {
                Name = "btnNuevoAsiento",
                Text = "Nuevo asiento",
                Location = new Point(200, 240),
                Size = new Size(120, 40),
                Anchor = AnchorStyles.Bottom
            };
            // 
            // btnBorrarAsiento
            // 
            this.btnBorrarAsiento = new Button
            {
                Name = "btnBorrarAsiento",
                Text = "Borrar asiento",
                Location = new Point(360, 240),
                Size = new Size(120, 40),
                Anchor = AnchorStyles.Bottom
            };
            // 
            // btnVolver
            // 
            this.btnVolver = new Button
            {
                Name = "btnVolver",
                Text = "Volver",
                Location = new Point(520, 240),
                Size = new Size(120, 40),
                Anchor = AnchorStyles.Bottom
            };

            // 
            // ContabilidadForm
            // 
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1020, 300);
            this.Text = "Contabilidad";
            this.FormBorderStyle = FormBorderStyle.Sizable;
            // Si quieres fondo, descomenta:
            // this.BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            // this.BackgroundImageLayout = ImageLayout.Stretch;

            // Añadimos controles al formulario
            this.Controls.Add(this.dgvAsientos);
            this.Controls.Add(this.dgvLineas);
            this.Controls.Add(this.btnNuevoAsiento);
            this.Controls.Add(this.btnBorrarAsiento);
            this.Controls.Add(this.btnVolver);
        }
    }
}
