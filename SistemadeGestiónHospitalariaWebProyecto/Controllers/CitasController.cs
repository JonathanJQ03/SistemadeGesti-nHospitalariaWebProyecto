using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;

namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<CitasCLS> ListarCitas()
        {
            CitasBL obj = new CitasBL();
            return obj.ListarCitas();
        }
        public JsonResult CargarPacientes()
        {
            CitasBL obj = new CitasBL();
            var pacientes = obj.CargarPacientes();
            return Json(pacientes);
        }
        public JsonResult CargarMedicos()
        {
            CitasBL obj = new CitasBL();
            var medicos = obj.CargarMedicos();
            return Json(medicos);
        }
    }
}
