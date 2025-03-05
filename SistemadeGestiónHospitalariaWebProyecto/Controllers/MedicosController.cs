using Microsoft.AspNetCore.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;

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


    }
}
