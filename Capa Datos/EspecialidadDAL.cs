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
    public class EspecialidadDAL : CadenaDAL
    {
        public List<EspecialidadCLS> ListarEspecialidades()
        {
            List<EspecialidadCLS> listaEspecialidades = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarEspecialidades", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            EspecialidadCLS oEspecialidadCLS;
                            listaEspecialidades = new List<EspecialidadCLS>();
                            while (dr.Read())
                            {
                                oEspecialidadCLS = new EspecialidadCLS();
                                oEspecialidadCLS.especialidadId = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oEspecialidadCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                listaEspecialidades.Add(oEspecialidadCLS);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al listar especialidades", ex);
                }
            }

            return listaEspecialidades;
        }
        public int GuardarEspecialidad(EspecialidadCLS oEspecialidadCLS)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarEspecialidad", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oEspecialidadCLS.especialidadId);
                        cmd.Parameters.AddWithValue("@nombre", oEspecialidadCLS.nombre == null ? "" : oEspecialidadCLS.nombre);
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
        public EspecialidadCLS ObtenerEspecialidad(int especialidadId)
        {
            EspecialidadCLS oEspecialidadCLS = new EspecialidadCLS();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspObtenerEspecialidad", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", especialidadId);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        { 
                            while (dr.Read())
                            {
                                
                                oEspecialidadCLS.especialidadId = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oEspecialidadCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                

                            }
                            
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    oEspecialidadCLS = null;
                    throw;

                }
            }
            return oEspecialidadCLS;

        }
        public int ObtenerEspecialidadPorNombre(string nombreEspecialidad)
        {
            int especialidadId = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspObtenerEspecialidadPorNombre", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreEspecialidad", nombreEspecialidad);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            especialidadId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    throw;
                }
            }
            return especialidadId;
        }


        public int EliminarEspecialidad(int especialidadId)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarEspecialidad", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", especialidadId);
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
