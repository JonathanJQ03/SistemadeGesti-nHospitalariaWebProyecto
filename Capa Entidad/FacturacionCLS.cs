
namespace Capa_Entidad
{
    public class FacturacionCLS
    {
        public int idFacturacion { get; set; }
        public int pacienteId { get; set; }
        public decimal monto { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaPago { get; set; }
    }
}
