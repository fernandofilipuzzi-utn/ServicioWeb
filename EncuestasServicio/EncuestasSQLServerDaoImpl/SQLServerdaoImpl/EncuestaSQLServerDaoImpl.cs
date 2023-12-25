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
            cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";
        }

        public Encuesta Actualizar(Encuesta actual)
        {
            return actual;
        }

        public Encuesta Agregar(Encuesta nueva)
        {   
            SqlConnection conn = new SqlConnection(cadenaConexion);
            try
            {
                conn.Open();

                string sql = @"
insert encuestas (anio, localidad)
output INSERTED.id 
values (@anio, @localidad)";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
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

        public Encuesta BuscarPorId(int id)
        {
            return null;
        }

        public List<Encuesta> BuscarTodos()
        {
            return null;
        }

        public void EliminarNuevo(int id)
        {
            
        }
    }
}
