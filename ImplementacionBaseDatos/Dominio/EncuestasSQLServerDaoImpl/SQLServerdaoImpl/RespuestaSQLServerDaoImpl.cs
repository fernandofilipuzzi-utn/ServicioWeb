using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasSQLServerDaoImpl.SQLServerDaoImpl
{
    public class RespuestaSQLServerDaoImpl : IRespuestaDAO
    {
        #region parámetros
        //string servidor = "TSP";
        string servidor = "TUPDEV";
        string baseDatos = "db_encuestas";
        #endregion
        string cadenaConexion = "";

        public RespuestaSQLServerDaoImpl()
        {
            // Cadena de conexión para SQL Server con autenticación de Windows
            cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";
            Inicializar();
        }

        private void Inicializar()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'respuestas')
BEGIN
    CREATE TABLE respuestas (
        id INT PRIMARY KEY IDENTITY(1,1), 
        email VARCHAR(50) NOT NULL,
        usa_bicicleta BIT NOT NULL,
        camina INT NOT NULL,
        usa_transporte_publico INT NOT NULL,
        usa_transporte_privado INT NOT NULL,
        distancia_a_su_destino NUMERIC(10,2) NOT NULL,
        id_encuesta INT 
    )
END";

                using (var query = new SqlCommand(sql, conn))
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
            SqlConnection conn =null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert respuestas (email, usa_bicicleta, camina, usa_transporte_publico, usa_transporte_privado, distancia_a_su_destino, id_encuesta)
output INSERTED.id 
values (@email, @usaBicicleta, @camina, @usaTransportePublico, @usaTransportePrivado, @distanciaASuDestino, @id_encuesta)";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("email", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("usaBicicleta", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("camina", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("usaTransportePublico", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("usaTransportePrivado", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("distanciaASuDestino", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("id_encuesta", SqlDbType.Int));
                    //
                    query.Parameters["email"].Value = nueva.Email;
                    query.Parameters["usaBicicleta"].Value = nueva.UsaBicicleta;
                    query.Parameters["camina"].Value = nueva.Camina;
                    query.Parameters["usaTransportePublico"].Value = nueva.UsaTransportePublico;
                    query.Parameters["usaTransportePrivado"].Value = nueva.UsaTransportePrivado;
                    query.Parameters["distanciaASuDestino"].Value = nueva.DistanciaASuDestino;
                    query.Parameters["id_encuesta"].Value = aDondePertenece.Id;
                    //
                    nueva.Id = (Int32)query.ExecuteScalar();
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

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, email, 
        usa_bicicleta, camina, usa_transporte_publico, 
        usa_transporte_privado, distancia_a_su_destino, 
        id_encuesta
from respuestas 
where id_encuesta=@IdEncuesta
order by id asc";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("IdEncuesta", SqlDbType.Int));
                    query.Parameters["IdEncuesta"].Value = idEncuesta;

                    SqlDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
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
