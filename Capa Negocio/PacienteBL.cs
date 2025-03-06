using Capa_Datos;
using Capa_Entidad;
namespace Capa_Negocio
{
    public class PacienteBL
    {
        public List<PacientesCLS> ListarPacientes()
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.ListarPacientes();
        }

        public int GuardarPacientes(PacientesCLS oPacienteCLS)
        {
            PacientesDAL pacienteobj = new PacientesDAL();
            return pacienteobj.GuardarPaciente(oPacienteCLS);
        }

        public PacientesCLS ObtenerPaciente(int idPaciente)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.ObtenerPaciente(idPaciente);
        }

        public int EliminarPaciente(int idPaciente)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.ELiminarPacientes(idPaciente);
        }
    }
}