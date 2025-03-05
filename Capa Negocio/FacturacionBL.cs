using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class FacturacionBL
    {
        public List<FacturacionCLS> ListarFacturacion()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ListarFacturacion();
        }

        public int GuardarFacturacion(FacturacionCLS oFacturacionCLS)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.GuardarFacturacion(oFacturacionCLS);
        }

        public FacturacionCLS ObtenerFacturacion(int idFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ObtenerFacturacion(idFacturacion);
        }
    }
}
