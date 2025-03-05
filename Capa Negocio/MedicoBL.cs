using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio

{
    public class MedicoBL
    {
        public List<MedicosCLS> ListarMedicos()
        {

            MedicosDAL obj = new MedicosDAL();
            return obj.ListarMedicos();
        }

        public int GuardarMedicos(MedicosCLS oMedicoCLS)
        {
            ValidarMedico(oMedicoCLS);
            MedicosDAL obj = new MedicosDAL();
            return obj.GuardarMedico(oMedicoCLS);
        }
        private void ValidarMedico(MedicosCLS medico)
        {
            if (medico.nombre == null)
            {
                throw new Exception("El nombre no puede ser nulo");
            }
            if (medico.apellido == null)
            {
                throw new Exception("El apellido no puede ser nulo");
            }
            if (medico.especialidadId == 0)
            {
                throw new Exception("La especialidad no puede ser nula");
            }
            if (string.IsNullOrEmpty(medico.telefono) || !System.Text.RegularExpressions.Regex.IsMatch(medico.telefono, "^09\\d{8}$"))
            {
                throw new ArgumentException("El teléfono debe tener 10 dígitos y empezar con '09'.");
            }
            if (medico.email == null)
            {
                throw new Exception("El email no puede ser nulo");
            }
        }
    }
}