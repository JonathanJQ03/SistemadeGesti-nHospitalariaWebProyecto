using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class CitasBL
    {
        public List<CitasCLS> ListarCitas()
        {
            CitasDAL obj = new CitasDAL();
            return obj.ListarCitas();
        }
        public List<PacientesCLS> CargarPacientes()
        {
            CitasDAL obj = new CitasDAL();
            return obj.CargarPacientes();
        }
        public List<MedicosCLS> CargarMedicos()
        {
            CitasDAL obj = new CitasDAL();
            return obj.cargarMedicos();
        }
        public int GuardarCita(CitasCLS oCitasCLS)
        {
            CitasDAL citaobj = new CitasDAL();
            return citaobj.GuardarCita(oCitasCLS);
        }

        public CitasCLS ObtenerCita(int idCita)
        {
            CitasDAL obj = new CitasDAL();
            return obj.ObtenerCita(idCita);
        }

        public int EliminarCita(int idCita)
        {
            CitasDAL obj = new CitasDAL();
            return obj.EliminarCita(idCita);
        }

    }
}
