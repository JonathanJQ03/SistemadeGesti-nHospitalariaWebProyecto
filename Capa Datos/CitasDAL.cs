using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CitasDAL : CadenaDAL
    {
        public List<CitasCLS> ListarCitas()
        {
            List<CitasCLS> listaCitas = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarCitas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            CitasCLS oCitasCLS;
                            listaCitas = new List<CitasCLS>();
                            while (dr.Read())
                            {
                                oCitasCLS = new CitasCLS();
                                oCitasCLS.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oCitasCLS.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oCitasCLS.medicoID = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                                oCitasCLS.fechaHora = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oCitasCLS.estado = dr.IsDBNull(4) ? "" : dr.GetString(4);


                                listaCitas.Add(oCitasCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    listaCitas = null;
                    throw;
                }
            }
            return listaCitas;
        }
        public List<PacientesCLS> CargarPacientes()
        {
            List<PacientesCLS> listaPacientes = null;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarPacientes", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            PacientesCLS oPacienteCLS;
                            listaPacientes = new List<PacientesCLS>();
                            while (dr.Read())
                            {
                                oPacienteCLS = new PacientesCLS();
                                oPacienteCLS.idPaciente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);  // Id
                                oPacienteCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);    // Nombre
                                oPacienteCLS.apellido = dr.IsDBNull(2) ? "" : dr.GetString(2);  // Apellido
                                                                                                // Puedes agregar las otras propiedades si las necesitas
                                oPacienteCLS.fechaNacimiento = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oPacienteCLS.telefono = dr.IsDBNull(4) ? "" : dr.GetString(4);
                                oPacienteCLS.email = dr.IsDBNull(5) ? "" : dr.GetString(5);
                                oPacienteCLS.direccion = dr.IsDBNull(6) ? "" : dr.GetString(6);

                                listaPacientes.Add(oPacienteCLS);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    listaPacientes = null;
                    
                    throw;
                }
            }
            return listaPacientes;
        }
        public List<MedicosCLS> cargarMedicos()
        {
            List<MedicosCLS> listaMedicos = new List<MedicosCLS>();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMedicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())  // Se encierra en using para liberar recursos
                        {
                            while (dr.Read())
                            {
                                MedicosCLS oMedicoCLS = new MedicosCLS
                                {
                                    idMedico = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                    nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    apellido = dr.IsDBNull(2) ? "" : dr.GetString(2),
                                    especialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3),
                                    telefono = dr.IsDBNull(4) ? "" : dr.GetString(4),
                                    email = dr.IsDBNull(5) ? "" : dr.GetString(5)
                                };

                                listaMedicos.Add(oMedicoCLS);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Se recomienda registrar el error en logs
                    Console.WriteLine("Error: " + ex.Message);
                    listaMedicos = null;
                }
            }
            return listaMedicos;
        }

    }
}
