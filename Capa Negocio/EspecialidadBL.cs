using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class EspecialidadBL
    {
        public List<EspecialidadCLS> ListarEspecialidades()
        {
            EspecialidadDAL obj = new EspecialidadDAL();
            return obj.ListarEspecialidades();
        }
        public int GuardarEspecialidad(EspecialidadCLS oEspecialidadCLS)
        {
            EspecialidadDAL obj = new EspecialidadDAL();
            return obj.GuardarEspecialidad(oEspecialidadCLS);
        }
        public EspecialidadCLS ObtenerEspecialidad(int id)
        {
            EspecialidadDAL obj = new EspecialidadDAL();
            return obj.ObtenerEspecialidad(id);
        }
        public int EliminarEspecialidad(int id)
        {
            EspecialidadDAL obj = new EspecialidadDAL();
            return obj.EliminarEspecialidad(id);
        }
    }
}
