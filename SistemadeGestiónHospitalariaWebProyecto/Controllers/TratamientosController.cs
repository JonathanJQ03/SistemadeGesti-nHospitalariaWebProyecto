using Microsoft.AspNetCore.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class TratamientosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TratamientosCLS> ListarTratamientos()
        {
            TratamientoBL obj = new TratamientoBL();
            return obj.ListarTratamientos();
        }
        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            TratamientoBL tratamientoobj = new TratamientoBL();
            return tratamientoobj.GuardarTratamiento(oTratamientoCLS);
        }

        public JsonResult CargarPacientes()
        {
            TratamientoBL obj = new TratamientoBL();
            var pacientes = obj.CargarPacientes();
            return Json(pacientes);
        }
    }
}
