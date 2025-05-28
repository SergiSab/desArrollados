using HotelSOL.DataAccess.Services;

namespace HotelSOL1.FormsAPP
{
    public partial class CheckInCheckOutForm : Form
    {
        private readonly ReservaService reservaService;
        private int reservaId;

        public CheckInCheckOutForm(ReservaService reservaService, int reservaId)
        {
            InitializeComponent(); // 📌 Esto debe estar dentro del mismo namespace
            this.reservaService = reservaService;
            this.reservaId = reservaId;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (reservaService.RegistrarCheckIn(reservaId))
            {
                MessageBox.Show("✅ Check-In registrado con éxito!");
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ No se pudo registrar el Check-In.");
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (reservaService.RegistrarCheckOut(reservaId))
            {
                MessageBox.Show("✅ Check-Out registrado con éxito!");
                this.Close();
            }
            else
            {
                MessageBox.Show("❌ No se pudo registrar el Check-Out.");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

