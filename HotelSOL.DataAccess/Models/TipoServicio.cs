using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HotelSOL.DataAccess.Models
{
    public class TipoServicioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Precio { get; set; }
    }
}
