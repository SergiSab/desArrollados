// HotelSOL.DataAccess/Models/Contabilidad.cs
namespace HotelSOL.DataAccess.Models
{
    /// <summary>
    /// Catálogo de cuentas (plan contable).
    /// </summary>
    public class Cuenta
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public char Naturaleza { get; set; }

        public ICollection<LineaAsiento> Lineas { get; set; }
            = new List<LineaAsiento>();
    }

    /// <summary>
    /// Encabezado de un asiento contable (fecha, descripción, número de documento).
    /// </summary>
    public class AsientoContable
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; } = null!;
        public string? NumDocumento { get; set; }

        public ICollection<LineaAsiento> Lineas { get; set; }
            = new List<LineaAsiento>();
    }

    /// <summary>
    /// Línea de un asiento: enlaza asiento cuenta con importe Debe/Haber.
    /// </summary>
    public class LineaAsiento
    {
        public int Id { get; set; }

        public int AsientoContableId { get; set; }
        public AsientoContable Asiento { get; set; } = null!;

        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; } = null!;

        public decimal? Debe { get; set; }
        public decimal? Haber { get; set; }
        public string? Descripcion { get; set; }
    }
}
