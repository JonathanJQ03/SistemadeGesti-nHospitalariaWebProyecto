using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class CitasCLS
    {
        public int id { get; set; } // Id de la cita (PK)
        public int pacienteId { get; set; } // Id del paciente (FK)
        public int medicoID { get; set; } // Id del médico (FK)
        public DateTime fechaHora { get; set; } // Fecha y hora de la cita
        public string estado { get; set; } // Estado de la cita (ej: "Programada", "Cancelada", "Completada")

        //// Relaciones (opcional, dependiendo de tu lógica de negocio)
        //public PacientesCLS Paciente { get; set; } // Objeto Paciente relacionado
        //public MedicosCLS Medico { get; set; } // Objeto Médico relacionado
    }
}
