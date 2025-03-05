using Capa_Entidad;
using System;
using System.Collections.Generic;
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
    }
}
