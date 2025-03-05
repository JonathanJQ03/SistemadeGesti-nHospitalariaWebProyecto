using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<MedicosCLS> ListarMedicos()
        {
            MedicoBL obj = new MedicoBL();
            return obj.ListarMedicos();
        }
        public int GuardarMedicos(MedicosCLS oMedicoCLS)
        {
            MedicoBL medicoobj = new MedicoBL();
            return medicoobj.GuardarMedicos(oMedicoCLS);
        }
        public JsonResult CargarEspecialidad()
        {
            MedicoBL obj = new MedicoBL();
            var especialidad = obj.CargarEspecialidad();
            return Json(especialidad);
        }

    }
}
