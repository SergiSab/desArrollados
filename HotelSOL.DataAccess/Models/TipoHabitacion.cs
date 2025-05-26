namespace HotelSOL.DataAccess.Models
{
    public class TipoHabitacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
        public string RutaImagen { get; set; } // 🔹 Imagen del tipo de habitación

        public ICollection<Habitacion> Habitaciones { get; set; } = new List<Habitacion>(); // Relación inversa
    }


}
