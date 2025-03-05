namespace Capa_Entidad
{
    public class TratamientosCLS
    {
        public int idTratamiento { get; set; }
        public int pacienteId { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public decimal costo { get; set; }

    }
}
