// HotelSOL1.FormsAPP/AsientoContableDialogForm.cs
using HotelSOL.DataAccess.Models;

namespace HotelSOL1.FormsAPP
{
    public partial class AsientoContableDialogForm : Form
    {
        /// <summary>
        /// Al cerrar con OK, este objeto contendrá Fecha, Descripción y Nº Documento.
        /// </summary>
        public AsientoContable AsientoItem { get; private set; }

        public AsientoContableDialogForm()
        {
            InitializeComponent();

            // Creamos el Asiento vacío con fecha por defecto
            AsientoItem = new AsientoContable
            {
                Fecha = DateTime.Today
            };

            // Asociamos el handler de OK
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validación mínima
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "La descripción es obligatoria.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                DialogResult = DialogResult.None;
                return;
            }

            // Volcar valores al AsientoItem
            AsientoItem.Fecha = dtpFecha.Value.Date;
            AsientoItem.Descripcion = txtDescripcion.Text.Trim();
            AsientoItem.NumDocumento = string.IsNullOrWhiteSpace(txtDocumento.Text)
                                      ? null
                                      : txtDocumento.Text.Trim();
            // DialogResult ya queda en OK
        }
    }
}
