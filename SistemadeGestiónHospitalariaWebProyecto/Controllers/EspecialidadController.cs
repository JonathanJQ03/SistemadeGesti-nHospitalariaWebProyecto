using Microsoft.AspNetCore.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class EspecialidadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
    public List<EspecialidadCLS> ListarEspecialidades()
        {
            EspecialidadBL obj = new EspecialidadBL();
            return obj.ListarEspecialidades();
        }
    public int GuardarEspecialidades(EspecialidadCLS oEspecialidadCLS)
        {
            EspecialidadBL obj = new EspecialidadBL();
            return obj.GuardarEspecialidad(oEspecialidadCLS);
        }
    }
}
