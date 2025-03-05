using Microsoft.AspNetCore.Mvc;
using Capa_Datos;
using Capa_Entidad;
using Capa_Negocio;
namespace SistemadeGestiónHospitalariaWebProyecto.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<PacientesCLS> ListarPacientes()
        {
            PacienteBL obj = new PacienteBL();
            return obj.ListarPacientes();
        }
        public int GuardarPacientes(PacientesCLS oPacienteCLS)
        {
            PacienteBL pacienteobj = new PacienteBL();
            return pacienteobj.GuardarPacientes(oPacienteCLS);
        }
        public PacientesCLS ObtenerPaciente(int idPaciente)
        {
            PacienteBL obj = new PacienteBL();
            return obj.ObtenerPaciente(idPaciente);
        }

        public int ELiminarPaciente(int idPaciente)
        {
            PacienteBL obj = new PacienteBL();
            return obj.EliminarPaciente(idPaciente);
        }
    }
}
