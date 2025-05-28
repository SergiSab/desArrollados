// HotelSOL1.FormsAPP/ProveedoresForm.cs
using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Service;
using System.ComponentModel;

namespace HotelSOL1.FormsAPP
{
    public partial class ProveedoresForm : Form
    {
        private readonly ProveedorService _service;
        private readonly BindingSource _bs = new BindingSource();
        private BindingList<Proveedor> _lista = null!;

        public ProveedoresForm(ProveedorService service)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Eventos
            Load += ProveedoresForm_Load;
            btnAnadir.Click += BtnAnadir_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnVolver.Click += btnVolver_Click;

            // Ligamos el BindingSource al DataGridView
            dgvProveedores.DataSource = _bs;
        }

        private void ProveedoresForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargamos todos los proveedores
                var datos = _service.GetAll();
                _lista = new BindingList<Proveedor>(datos);
                _bs.DataSource = _lista;

                // Ajuste opcional de encabezados
                if (dgvProveedores.Columns["IdProveedor"] != null)
                    dgvProveedores.Columns["IdProveedor"].HeaderText = "ID";
                if (dgvProveedores.Columns["Nombre"] != null)
                    dgvProveedores.Columns["Nombre"].HeaderText = "Nombre";
                if (dgvProveedores.Columns["CIF"] != null)
                    dgvProveedores.Columns["CIF"].HeaderText = "CIF";
                if (dgvProveedores.Columns["Direccion"] != null)
                    dgvProveedores.Columns["Direccion"].HeaderText = "Dirección";
                if (dgvProveedores.Columns["Telefono"] != null)
                    dgvProveedores.Columns["Telefono"].HeaderText = "Teléfono";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al cargar proveedores:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnAnadir_Click(object sender, EventArgs e)
        {
            using var dlg = new ProveedorDialogForm();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                _service.Add(dlg.ProveedorItem);
                _lista.Add(dlg.ProveedorItem);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;

            var sel = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem!;
            using var dlg = new ProveedorDialogForm(sel);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // Copiamos los cambios al objeto existente
                sel.Nombre = dlg.ProveedorItem.Nombre;
                sel.CIF = dlg.ProveedorItem.CIF;
                sel.Direccion = dlg.ProveedorItem.Direccion;
                sel.Telefono = dlg.ProveedorItem.Telefono;

                _service.Update(sel);
                // Refresca sólo esa fila
                _bs.ResetItem(_lista.IndexOf(sel));
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;

            var sel = (Proveedor)dgvProveedores.CurrentRow.DataBoundItem!;
            var msg = MessageBox.Show(
                $"¿Eliminar proveedor «{sel.Nombre}»?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (msg == DialogResult.Yes)
            {
                _service.Delete(sel.IdProveedor);
                _lista.Remove(sel);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
