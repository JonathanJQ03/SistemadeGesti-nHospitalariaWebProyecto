﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;

namespace Capa_Datos
{
    public class MedicosDAL : CadenaDAL
    {
        public List<MedicosCLS> ListarMedicos()
        {
            List<MedicosCLS> listaMedicos = null;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMedicos", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr != null)
                        {
                            MedicosCLS oMedicoCLS;
                            listaMedicos = new List<MedicosCLS>();
                            while (dr.Read())
                            {
                                oMedicoCLS = new MedicosCLS();
                                oMedicoCLS.idMedico = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oMedicoCLS.nombre = dr.IsDBNull(1) ? "" : dr.GetString(1);
                                oMedicoCLS.apellido = dr.IsDBNull(2) ? "" : dr.GetString(2);
                                oMedicoCLS.especialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                oMedicoCLS.telefono = dr.IsDBNull(4) ? "" : dr.GetString(4);
                                oMedicoCLS.email = dr.IsDBNull(5) ? "" : dr.GetString(5);

                                listaMedicos.Add(oMedicoCLS);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    listaMedicos = null;
                    throw;
                }
            }
            return listaMedicos;
        }

        public int GuardarMedico(MedicosCLS oMedicoCLS)
        {
            if (oMedicoCLS == null)
            {
                throw new ArgumentNullException(nameof(oMedicoCLS), "El objeto médico no puede ser nulo.");
            }

            int respuesta = 0;

            using (SqlConnection cn = new SqlConnection(this.cadena))
            {
                try
                {
                    cn.Open();
                    EspecialidadDAL especialidadDAL = new EspecialidadDAL();
                    int especialidadId = 0;

                    especialidadId = especialidadDAL.ObtenerEspecialidadPorNombre(oMedicoCLS.especialidadNombre);
                    

                    using (SqlCommand cmd = new SqlCommand("uspGuardarMedico", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id", oMedicoCLS.idMedico);
                        cmd.Parameters.AddWithValue("@nombre", oMedicoCLS.nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@apellido", oMedicoCLS.apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@especialidadId", especialidadId);
                        cmd.Parameters.AddWithValue("@telefono", oMedicoCLS.telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@email", oMedicoCLS.email ?? string.Empty);

                        respuesta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Se recomienda registrar el error en logs en un sistema real
                    Console.WriteLine("Error al guardar el médico: " + ex.Message);
                    respuesta = 0;
                    throw;
                }
            }
            return respuesta;
        }



            public List<EspecialidadCLS> cargarEspecialidad()
            {
                List<EspecialidadCLS> listaEspecialidades = new List<EspecialidadCLS>();


                using (SqlConnection cn = new SqlConnection(this.cadena))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cmd = new SqlCommand("uspListarEspecialidades", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            using (SqlDataReader dr = cmd.ExecuteReader())  // Se encierra en using para liberar recursos
                            {
                                while (dr.Read())
                                {
                                    EspecialidadCLS oEspecialidadCLS = new EspecialidadCLS
                                    {

                                        especialidadId = dr.IsDBNull(0) ? 0 : dr.GetInt32(0),
                                        nombre = dr.IsDBNull(1) ? "" : dr.GetString(1),
                                    };

                                    listaEspecialidades.Add(oEspecialidadCLS);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Se recomienda registrar el error en logs
                        Console.WriteLine("Error: " + ex.Message);
                        listaEspecialidades = null;
                    }
                }
                return listaEspecialidades;
            }

    }
}
