using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasSQLiteDaoImpl.SQLServerdaoImpl
{
    public class EncuestaSQLiteDaoImpl : IEncuestaDAO
    {
        

        string cadenaConexion = "";

        public EncuestaSQLiteDaoImpl()
        {
            string path = Path.GetFullPath("../../db_encuestas.db");
            cadenaConexion = $"Data Source={path};Version=3;";

            //no es recomendable llamar aquí!, necesito otra cosa
            Inicializar();
        }
        public EncuestaSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3;";

            //no es recomendable llamar aquí!, necesito otra cosa
            Inicializar();
        }

        private void Inicializar()
        {
            SQLiteConnection conn = null;

            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
CREATE TABLE IF NOT EXISTS encuestas (
    id INTEGER PRIMARY KEY AUTOINCREMENT, 
    anio INTEGER NOT NULL,
    localidad TEXT NOT NULL,
    porc_bicicleta REAL DEFAULT 0,
    porc_caminando REAL DEFAULT 0,
    porc_transporte_publico REAL DEFAULT 0,
    porc_transporte_privado REAL DEFAULT 0,
    distancia_media REAL DEFAULT 0,
    en_curso INTEGER CHECK (en_curso IN (0, 1))
)";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.ExecuteNonQuery();
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
        }

        public void Actualizar(Encuesta actual)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
update encuestas 
set anio=@anio, 
        localidad=@localidad, 
        porc_bicicleta=@porcBicicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia,
        en_curso=@enCurso  
where id=@id";

                int rowsaffected = 0;
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("anio", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("localidad", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("porcBicicleta", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("porcCaminando", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePublico", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePrivado", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("distanciaMedia", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("enCurso", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("id", actual.Id));
                    //
                    query.Parameters["anio"].Value = actual.Anio;
                    query.Parameters["localidad"].Value = actual.Localidad;
                    query.Parameters["porcBicicleta"].Value = actual.PorcBicleta;
                    query.Parameters["porcCaminando"].Value = actual.PorcCaminando;
                    query.Parameters["porcTransportePublico"].Value = actual.PorcTransportePublico;
                    query.Parameters["porcTransportePrivado"].Value = actual.PorcTransportePrivado;
                    query.Parameters["distanciaMedia"].Value = actual.DistanciaMedia;
                    query.Parameters["enCurso"].Value = actual.EnCurso ? 1 : 0;
                    query.Parameters["id"].Value = actual.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected} filas.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Encuesta Agregar(Encuesta nueva)
        {   
            SQLiteConnection conn =null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert into encuestas (anio, localidad, en_curso)
values (@anio, @localidad, @enCurso)
RETURNING id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("anio", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("localidad", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("enCurso", DbType.Int32));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["enCurso"].Value = nueva.EnCurso ? 1 : 0;
                    //
                    //rowsaffected += query.ExecuteNonQuery();
                    object id = query.ExecuteScalar();
                    nueva.Id = Convert.ToInt32(id);
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
            return nueva;
        }
                

        public void Eliminar(int id)
        {
            
        }

        public Encuesta BuscarPorId(int idBuscado)
        {
            Encuesta buscado = null;

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                //agregar los campos que faltan
                string sql = @"
select id, anio, localidad, 
        porc_bicicleta,
        porc_caminando, 
        porc_transporte_publico, 
        porc_transporte_privado, 
        distancia_media, 
        en_curso 
from encuestas 
where id=@Id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("Id", DbType.Int32));
                    query.Parameters["Id"].Value = idBuscado;
                    //
                    SQLiteDataReader dataReader = query.ExecuteReader();
                    
                    if( dataReader.Read() )
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = Convert.ToInt32(dataReader["id"]);
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
                        double? porcBicicleta = 0;
                        if (dataReader["porc_bicicleta"] != DBNull.Value)
                            porcBicicleta = Convert.ToDouble(dataReader["porc_bicicleta"]);

                        double? porcCaminando = 0;
                        if (dataReader["porc_caminando"] != DBNull.Value)
                            porcCaminando = Convert.ToDouble(dataReader["porc_caminando"]);

                        double? porcTransportePublico = 0;
                        if (dataReader["porc_transporte_publico"] != DBNull.Value)
                            porcTransportePublico = Convert.ToDouble(dataReader["porc_transporte_publico"]);

                        double? porcTransportePrivado = 0;
                        if (dataReader["porc_transporte_privado"] != DBNull.Value)
                           porcTransportePrivado = Convert.ToDouble(dataReader["porc_transporte_privado"]);

                        double? distanciaMedia = 0;
                        if (dataReader["distancia_media"] != DBNull.Value)
                             distanciaMedia = Convert.ToDouble(dataReader["distancia_media"]);
                        #endregion

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = Convert.ToBoolean( dataReader["en_curso"]);
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
            List<Encuesta> encuestas = new List<Encuesta>();

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, anio, localidad, en_curso 
from encuestas 
order by id asc";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader dataReader = query.ExecuteReader();
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

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio, EnCurso = enCurso };
                        encuestas.Add(encuesta);
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
            return encuestas;
        }

        public List<Encuesta> BuscarUltimasEncuestaNoCerradas()
        {
            List<Encuesta> encuestasActivasLocalidades = new List<Encuesta>();

            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, anio, localidad, en_curso 
from encuestas 
where en_curso=1
order by id asc";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = Convert.ToInt32(dataReader["id"]);
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
                            enCurso = Convert.ToInt32(dataReader["en_curso"])==1;
                        #endregion

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio , EnCurso=enCurso};
                        encuestasActivasLocalidades.Add(encuesta);
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
            return encuestasActivasLocalidades;
        }
    }
}
