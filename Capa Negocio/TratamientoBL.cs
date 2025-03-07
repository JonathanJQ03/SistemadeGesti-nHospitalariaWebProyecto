using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class TratamientoBL
    {
        public List<TratamientosCLS> ListarTratamientos()
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.ListarTratamientos();
        }
        
        public List<PacientesCLS> CargarPacientes()
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.cargarPacientes();
        }

        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            TratamientosDAL tratamientoobj = new TratamientosDAL();
            return tratamientoobj.GuardarTratamiento(oTratamientoCLS);
        }

        public TratamientosCLS ObtenerTratamiento(int idCita)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.ObtenerTratamiento(idCita);
        }
    }
}
