using HotelSOL.DataAccess.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Servicio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("TipoServicioId")]
    public int TipoServicioId { get; set; }
    public TipoServicioEntity TipoServicio { get; set; }

    [ForeignKey("ReservaId")]
    public int ReservaId { get; set; }
    public Reserva Reserva { get; set; }

    [ForeignKey("FacturaId")]
    public int? FacturaId { get; set; }
    public Factura? Factura { get; set; }


    public bool DescuentoAplicado { get; set; } = false; // 🔹 Nuevo campo para descuentos
}
