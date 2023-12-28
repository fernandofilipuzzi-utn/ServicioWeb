using EncuestasDAO.DAO;
using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasSQLServerDaoImpl.SQLServerdaoImpl
{
    public class EncuestaSQLServerDaoImpl : IEncuestaDAO
    {
        #region parámetros
        string servidor = "TSP";
        string baseDatos = "db_encuestas";
        #endregion

        string cadenaConexion = "";

        public EncuestaSQLServerDaoImpl()
        {
            // Cadena de conexión para SQL Server con autenticación de Windows
            cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";
        }

        public void Actualizar(Encuesta actual)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
update encuestas 
set anio=@anio, 
        localidad=@localidad, 
        porc_bicicleta=@porcBicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia,
        en_curso=@enCurso  
where id=@id";

                int rowsaffected = 0;
                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("porcBicleta", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcCaminando", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePublico", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePrivado", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("distanciaMedia", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("enCurso", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["anio"].Value = actual.Anio;
                    query.Parameters["localidad"].Value = actual.Localidad;
                    query.Parameters["porcBicleta"].Value = actual.PorcBicleta;
                    query.Parameters["porcCaminando"].Value = actual.PorcCaminando;
                    query.Parameters["porcTransportePublico"].Value = actual.PorcTransportePublico;
                    query.Parameters["porcTransportePrivado"].Value = actual.PorcTransportePrivado;
                    query.Parameters["distanciaMedia"].Value = actual.DistanciaMedia;
                    //
                    query.Parameters["enCurso"].Value = actual.EnCurso;
                    //
                    query.Parameters["id"].Value = actual.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected} filas.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{e.StackTrace.ToString()}");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Encuesta Agregar(Encuesta nueva)
        {   
            SqlConnection conn =null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert encuestas (anio, localidad, en_curso)
output INSERTED.id 
values (@anio, @localidad, @enCurso)";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("enCurso", SqlDbType.Bit));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["enCurso"].Value = nueva.EnCurso;
                    //
                    //rowsaffected += query.ExecuteNonQuery();
                    Int32 id = (Int32)query.ExecuteScalar();
                    nueva.Id = id;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return nueva;
        }
                

        public void Eliminar(int id)
        {
            
        }

        public Encuesta BuscarPorId(int idBuscado)
        {
            Encuesta buscado = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                //agregar los campos que faltan
                string sql = @"
select id, anio, localidad, porc_bicicleta, porc_caminando, porc_transporte_publico, porc_transporte_privado, distancia_media, en_curso 
from encuestas 
where id=@Id";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("Id", SqlDbType.Int));
                    //
                    query.Parameters["Id"].Value = idBuscado;

                    SqlDataReader dataReader = query.ExecuteReader();
                    
                    if( dataReader.Read() )
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
                        #endregion

                        #region nombre
                        int anio = 0;
                        if (dataReader["anio"] != DBNull.Value)
                            anio = Convert.ToInt32(dataReader["anio"]);
                        #endregion

                        #region localidad
                        string localidad = "";
                        if (dataReader["localidad"] != DBNull.Value)
                            localidad = dataReader["localidad"] as string;
                        #endregion

                        #region porcentaje  bicicleta
                        double? porcBicicleta = dataReader["porc_bicicleta"] as double?;
                        double? porcCaminando = dataReader["porc_caminando"] as double?;
                        double? porcTransportePublico = dataReader["porc_transporte_publico"] as double?;
                        double? porcTransportePrivado = dataReader["porc_transporte_privado"] as double?;
                        double? distanciaMedia = dataReader["distancia_media"] as double?;
                        #endregion

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        buscado = new Encuesta { Id = id, Localidad = localidad, Anio = anio, 
                                                 PorcBicleta=porcBicicleta,
                                                 PorcCaminando= porcCaminando,
                                                 PorcTransportePublico= porcTransportePublico,
                                                 PorcTransportePrivado= porcTransportePrivado,
                                                 DistanciaMedia= distanciaMedia ,
                                                 EnCurso = enCurso };
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return buscado;
        }

        public List<Encuesta> BuscarTodos()
        {
            return null;
        }

        public List<Encuesta> BuscarUltimasEncuestaNoCerradas()
        {
            List<Encuesta> encuestasActivasLoclidades = new List<Encuesta>();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, anio, localidad, en_curso 
from encuestas 
where en_curso=1
order by id asc";

                using (var command = new SqlCommand(sql, conn))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
                        #endregion

                        #region nombre
                        int anio = 0;
                        if (dataReader["anio"] != DBNull.Value)
                            anio = Convert.ToInt32(dataReader["anio"]);
                        #endregion

                        #region localidad
                        string localidad = "";
                        if (dataReader["localidad"] != DBNull.Value)
                            localidad = dataReader["localidad"] as string;
                        #endregion

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio , EnCurso=enCurso};
                        encuestasActivasLoclidades.Add(encuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return encuestasActivasLoclidades;
        }
    }
}
