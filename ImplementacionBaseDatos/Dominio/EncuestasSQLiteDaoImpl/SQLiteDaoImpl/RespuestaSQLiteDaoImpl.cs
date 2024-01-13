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

namespace EncuestasSQLiteDaoImpl.SQLiteDaoImpl
{
    public class RespuestaSQLiteDaoImpl : IRespuestaDAO
    {
        string cadenaConexion = "";

        public RespuestaSQLiteDaoImpl(string path)
        {
            cadenaConexion = $"Data Source={path};Version=3;";
            Inicializar();
        }

        public RespuestaSQLiteDaoImpl()
        {
            string path= Path.GetFullPath("../../db_encuestas.db");
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
CREATE TABLE IF NOT EXISTS respuestas (
    id INTEGER PRIMARY KEY AUTOINCREMENT, 
    email TEXT NOT NULL,
    usa_bicicleta INTEGER NOT NULL CHECK (usa_bicicleta IN (0, 1)),
    camina INTEGER NOT NULL CHECK (camina IN (0, 1)),
    usa_transporte_publico INTEGER NOT NULL CHECK (usa_transporte_publico IN (0, 1)),
    usa_transporte_privado INTEGER NOT NULL CHECK (usa_transporte_privado IN (0, 1)),
    distancia_a_su_destino REAL NOT NULL,
    id_encuesta INTEGER 
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

        public Respuesta Agregar(Respuesta nueva, Encuesta aDondePertenece)
        {
           SQLiteConnection conn =null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert into respuestas (email, usa_bicicleta, camina, usa_transporte_publico, usa_transporte_privado, distancia_a_su_destino, id_encuesta)
values (@email, @usaBicicleta, @camina, @usaTransportePublico, @usaTransportePrivado, @distanciaASuDestino, @id_encuesta) 
RETURNING id";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    //
                    query.Parameters.Add(new SQLiteParameter("email", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("usaBicicleta", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("camina", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("usaTransportePublico", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("usaTransportePrivado", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("distanciaASuDestino", DbType.Double));
                    query.Parameters.Add(new SQLiteParameter("id_encuesta", DbType.Int32));
                    //
                    query.Parameters["email"].Value = nueva.Email;
                    query.Parameters["usaBicicleta"].Value = nueva.UsaBicicleta ? 1 : 0;
                    query.Parameters["camina"].Value = nueva.Camina ? 1 : 0;
                    query.Parameters["usaTransportePublico"].Value = nueva.UsaTransportePublico ? 1 : 0;
                    query.Parameters["usaTransportePrivado"].Value = nueva.UsaTransportePrivado ? 1 : 0;
                    query.Parameters["distanciaASuDestino"].Value = nueva.DistanciaASuDestino;
                    query.Parameters["id_encuesta"].Value = aDondePertenece.Id;
                    //
                    object id = query.ExecuteScalar();
                    nueva.Id = Convert.ToInt32(id);
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

        public void Actualizar(Respuesta Nuevo)
        {
            //
        }

        public void Eliminar(int id)
        {
            //
        }

        public Respuesta BuscarPorId(int id)
        {
            return null;
        }

        public List<Respuesta> BuscarTodos()
        {
            List<Respuesta> respuestas = new List<Respuesta>();
            return respuestas;
        }

        public List<Respuesta> BuscarPorIdEncuesta(int idEncuesta)
        {
            List<Respuesta> respuestas = new List<Respuesta>();

           SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, email, 
        usa_bicicleta, camina, usa_transporte_publico, 
        usa_transporte_privado, distancia_a_su_destino, 
        id_encuesta
from respuestas 
where id_encuesta=@IdEncuesta
order by id asc";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.AddWithValue("@IdEncuesta", idEncuesta);

                    SQLiteDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = Convert.ToInt32(dataReader["id"]);
                        #endregion

                        #region email
                        string email = "";
                        if (dataReader["email"] != DBNull.Value)
                            email = dataReader["email"].ToString();
                        #endregion

                        #region usa bicicleta
                        bool usaBicicleta = false;
                        if (dataReader["usa_bicicleta"] != DBNull.Value)
                            usaBicicleta = Convert.ToBoolean(dataReader["usa_bicicleta"]);
                        #endregion

                        #region camina
                        bool camina = false;
                        if (dataReader["camina"] != DBNull.Value)
                            usaBicicleta = Convert.ToBoolean(dataReader["usa_bicicleta"]);
                        #endregion

                        #region usa trasnporte public
                        bool usaTransportePublico = false;
                        if (dataReader["usa_transporte_publico"] != DBNull.Value)
                            usaTransportePublico = Convert.ToBoolean(dataReader["usa_transporte_publico"]);
                        #endregion

                        #region usa trasnporte privado
                        bool usaTransportePrivado = false;
                        if (dataReader["usa_transporte_privado"] != DBNull.Value)
                            usaTransportePrivado = Convert.ToBoolean(dataReader["usa_transporte_privado"]);
                        #endregion

                        #region distancia a su destino
                        double distanciaASuDestino = 0;
                        if (dataReader["distancia_a_su_destino"] != DBNull.Value)
                            distanciaASuDestino = Convert.ToDouble(dataReader["distancia_a_su_destino"]);
                        #endregion

                        #region id_encuesta
                        int id_encuesta = 0;
                        if (dataReader["id_encuesta"] != DBNull.Value)
                            id_encuesta = Convert.ToInt32( dataReader["id_encuesta"]) ;
                        #endregion

                        Respuesta respuesta = new Respuesta { Id = id, Email=email, UsaBicicleta=usaBicicleta, Camina=camina, UsaTransportePublico=usaTransportePublico, UsaTransportePrivado=usaTransportePrivado, DistanciaASuDestino=distanciaASuDestino};
                        respuestas.Add(respuesta);
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
            return respuestas;
        }
    }
}
