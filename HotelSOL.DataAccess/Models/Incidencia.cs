namespace HotelSOL.DataAccess.Models
{
    public class Incidencia
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public string Descripcion { get; set; } = "Pendiente";
        public DateTime FechaInforme { get; set; }

        // Relación con Reserva
        public Reserva Reserva { get; set; } = new Reserva();

    }
}