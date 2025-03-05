using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class FacturacionDAL : CadenaDAL
    {
        public List<FacturacionCLS> ListarFacturacion()
        {
            List<FacturacionCLS> listaFacturacion = null;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarFacturacion", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            FacturacionCLS oFacturacionCLS;
                            listaFacturacion = new List<FacturacionCLS>();
                            while (dr.Read())
                            {
                                oFacturacionCLS = new FacturacionCLS();
                                oFacturacionCLS.idFacturacion = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oFacturacionCLS.pacienteId = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oFacturacionCLS.monto = dr.IsDBNull(1) ? 0 : dr.GetDecimal(1);
                                oFacturacionCLS.metodoPago = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oFacturacionCLS.fechaPago = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                listaFacturacion.Add(oFacturacionCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    listaFacturacion = null;
                    throw;
                }
            }
            return listaFacturacion;
        }
        public int GuardarFacturacion(FacturacionCLS oFacturacionCLS)
        {
            int respuesta = 0;
            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarFacturacion", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oFacturacionCLS.idFacturacion);
                        cmd.Parameters.AddWithValue("@pacienteId", oFacturacionCLS.pacienteId);
                        cmd.Parameters.AddWithValue("@monto", oFacturacionCLS.monto == 0 ? (object)DBNull.Value : oFacturacionCLS.monto);
                        cmd.Parameters.AddWithValue("@metodoPago", oFacturacionCLS.metodoPago == null ? "" : oFacturacionCLS.metodoPago);
                        cmd.Parameters.AddWithValue("@fechaPago", oFacturacionCLS.fechaPago == DateTime.MinValue ? (object)DBNull.Value : oFacturacionCLS.fechaPago);

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

        
        public FacturacionCLS ObtenerFacturacion(int idFacturacion)
        {
            FacturacionCLS oFacturacionCLS = new FacturacionCLS();

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspObtenerFacturacion", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idFacturacion);
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                oFacturacionCLS = new FacturacionCLS();
                                oFacturacionCLS.idFacturacion = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oFacturacionCLS.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oFacturacionCLS.monto = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                                oFacturacionCLS.metodoPago = dr.IsDBNull(3) ? "" : dr.GetString(3);
                                oFacturacionCLS.fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();

                }
            }
            return oFacturacionCLS;
        }

    }
}
