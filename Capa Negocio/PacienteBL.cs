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
            ValidarPaciente(oPacienteCLS);
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

        private void ValidarPaciente(PacientesCLS paciente)
        {
            if (paciente.fechaNacimiento == DateTime.MinValue || paciente.fechaNacimiento > DateTime.Now)
            {
                throw new ArgumentException("Fecha de nacimiento inválida.");
            }
            if (paciente.fechaNacimiento < DateTime.Now.AddYears(-120))
            {
                throw new ArgumentException("El paciente no puede tener más de 120 años.");
            }
            if (string.IsNullOrEmpty(paciente.telefono) || !System.Text.RegularExpressions.Regex.IsMatch(paciente.telefono, "^09\\d{8}$"))
            {
                throw new ArgumentException("El teléfono debe tener 10 dígitos y empezar con '09'.");
            }
        }
    }
}