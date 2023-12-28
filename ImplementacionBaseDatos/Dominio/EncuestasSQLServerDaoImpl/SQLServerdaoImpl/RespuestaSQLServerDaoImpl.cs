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
    public class RespuestaSQLServerDaoImpl : IRespuestaDAO
    {
        #region parámetros
        string servidor = "TSP";
        string baseDatos = "db_encuestas";
        #endregion
        string cadenaConexion = "";

        public RespuestaSQLServerDaoImpl()
        {
            // Cadena de conexión para SQL Server con autenticación de Windows
            cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";
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
            return null;
        }
    }
}
