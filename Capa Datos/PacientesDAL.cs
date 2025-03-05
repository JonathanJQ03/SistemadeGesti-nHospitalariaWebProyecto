using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class PacientesDAL : CadenaDAL
    {
        public List<PacientesCLS> ListarPacientes()
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
                                oPacienteCLS.idPaciente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oPacienteCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                oPacienteCLS.apellido = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oPacienteCLS.fechaNacimiento = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oPacienteCLS.telefono = dr.IsDBNull(4) ? "" : dr.GetString(4);
                                oPacienteCLS.email = dr.IsDBNull(5) ? "" : dr.GetString(5);
                                oPacienteCLS.direccion = dr.IsDBNull(6) ? "" : dr.GetString(6);

                                listaPacientes.Add(oPacienteCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    listaPacientes = null;
                    throw;
                }
            }
            return listaPacientes;
        }
        public int GuardarPaciente(PacientesCLS oPacienteCLS)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oPacienteCLS.idPaciente);
                        cmd.Parameters.AddWithValue("@nombre", oPacienteCLS.nombre == null ? "" : oPacienteCLS.nombre);
                        cmd.Parameters.AddWithValue("@apellido", oPacienteCLS.apellido == null ? "" : oPacienteCLS.apellido);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", oPacienteCLS.fechaNacimiento == DateTime.MinValue ? (object)DBNull.Value : oPacienteCLS.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@telefono", oPacienteCLS.telefono == null ? "" : oPacienteCLS.telefono);
                        cmd.Parameters.AddWithValue("@email", oPacienteCLS.email == null ? "" : oPacienteCLS.email);
                        cmd.Parameters.AddWithValue("@direccion", oPacienteCLS.direccion == null ? "" : oPacienteCLS.direccion);
                        respuesta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    respuesta = 0;
                    throw;
                }
            }
            return respuesta;
        }
 
      
        public PacientesCLS ObtenerPaciente(int idPaciente)
        {
            PacientesCLS oPacienteCLS = new PacientesCLS();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspObtenerPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idPaciente);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oPacienteCLS.idPaciente = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oPacienteCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                oPacienteCLS.apellido = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oPacienteCLS.fechaNacimiento = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oPacienteCLS.telefono = dr.IsDBNull(4) ? "" : dr.GetString(4);
                                oPacienteCLS.email = dr.IsDBNull(5) ? "" : dr.GetString(5);
                                oPacienteCLS.direccion = dr.IsDBNull(6) ? "" : dr.GetString(6);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
            }
            return oPacienteCLS;
        }
        public int ELiminarPacientes(int idPaciente)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarPaciente", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idPaciente);
                        respuesta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                }
            }
            return respuesta;
        }
    }
}
