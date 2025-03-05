using Microsoft.AspNetCore.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class FacturacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<FacturacionCLS> ListarFacturacion()
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.ListarFacturacion();
        }

        public int GuardarFacturacion(FacturacionCLS oFacturacionCLS)
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.GuardarFacturacion(oFacturacionCLS);
        }

        
    }

}
