using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class TratamientosDAL : CadenaDAL
    {
        public List<TratamientosCLS> ListarTratamientos()
        {
            List<TratamientosCLS> listaTratamientos = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTratamientos", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            TratamientosCLS oTratamientoCLS;
                            listaTratamientos = new List<TratamientosCLS>();
                            while (dr.Read())
                            {
                                oTratamientoCLS = new TratamientosCLS();
                                oTratamientoCLS.idTratamiento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oTratamientoCLS.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oTratamientoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oTratamientoCLS.fecha = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oTratamientoCLS.costo = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                                listaTratamientos.Add(oTratamientoCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    listaTratamientos = null;
                    throw;
                }
            }
            return listaTratamientos;
        }
        public int GuardarTratamiento(TratamientosCLS oTratamientoCLS)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTratamiento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pacienteId", oTratamientoCLS.pacienteId);
                        cmd.Parameters.AddWithValue("@descripcion", oTratamientoCLS.descripcion == null ? "" : oTratamientoCLS.descripcion);
                        cmd.Parameters.AddWithValue("@fecha", oTratamientoCLS.fecha == DateTime.MinValue ? (object)DBNull.Value : oTratamientoCLS.fecha);
                        cmd.Parameters.AddWithValue("@costo", oTratamientoCLS.costo == 0 ? (object)DBNull.Value : oTratamientoCLS.costo);
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

        public TratamientosCLS ObtenerTratamiento(int idTratamiento)
        {
            TratamientosCLS oTratamientoCLS = new TratamientosCLS();
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspObtenerTratamiento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idTratamiento);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {

                                oTratamientoCLS.idTratamiento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oTratamientoCLS.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oTratamientoCLS.descripcion = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oTratamientoCLS.fecha = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oTratamientoCLS.costo = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();

                }
            }
            return oTratamientoCLS;
        }
        
    }
}
