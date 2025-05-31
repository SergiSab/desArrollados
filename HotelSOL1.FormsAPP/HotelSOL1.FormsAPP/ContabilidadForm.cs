using HotelSOL.DataAccess.Models;
using HotelSOL.DataAccess.Services;
using System.ComponentModel;

namespace HotelSOL1.FormsAPP
{
    public partial class ContabilidadForm : Form
    {
        private readonly ContabilidadService _service;
        private BindingList<AsientoContable> _listaAsientos = null!;
        private BindingList<LineaAsiento> _listaLineas = null!;

        public ContabilidadForm(ContabilidadService service)
        {
            InitializeComponent();
            _service = service ?? throw new ArgumentNullException(nameof(service));

            // Eventos
            this.Load += ContabilidadForm_Load;
            dgvAsientos.SelectionChanged += DgvAsientos_SelectionChanged;
            btnNuevoAsiento.Click += BtnNuevoAsiento_Click;
            btnBorrarAsiento.Click += BtnBorrarAsiento_Click;
            btnVolver.Click += (_, __) => Close();
        }

        private void ContabilidadForm_Load(object sender, EventArgs e)
        {
            // Cargo todos los asientos
            var asientos = _service.GetAllAsientos();
            _listaAsientos = new BindingList<AsientoContable>(asientos);
            asientoBindingSource.DataSource = _listaAsientos;

            // Inicialmente no mostramos líneas
            lineaBindingSource.DataSource = new BindingList<LineaAsiento>();
            dgvLineas.DataSource = lineaBindingSource;
        }

        private void DgvAsientos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAsientos.CurrentRow == null) return;

            var sel = (AsientoContable)dgvAsientos.CurrentRow.DataBoundItem!;
            var lineas = _service.GetLineasByAsiento(sel.Id);

            _listaLineas = new BindingList<LineaAsiento>(lineas);
            lineaBindingSource.DataSource = _listaLineas;
        }

        private void BtnNuevoAsiento_Click(object sender, EventArgs e)
        {
            using var dlg = new AsientoContableDialogForm();  // <-- sin servicio
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            // Persiste y añade
            var nuevo = _service.AddAsiento(dlg.AsientoItem);
            _listaAsientos.Add(nuevo);

            // Selecciona el recién creado
            dgvAsientos.CurrentCell = dgvAsientos.Rows[^1].Cells[0];
        }

        private void BtnBorrarAsiento_Click(object sender, EventArgs e)
        {
            if (dgvAsientos.CurrentRow == null) return;

            var sel = (AsientoContable)dgvAsientos.CurrentRow.DataBoundItem!;
            if (MessageBox.Show($"¿Eliminar asiento #{sel.Id}?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes) return;

            _service.DeleteAsiento(sel.Id);
            _listaAsientos.Remove(sel);

            // Limpia las líneas
            lineaBindingSource.Clear();
        }
    }
}
