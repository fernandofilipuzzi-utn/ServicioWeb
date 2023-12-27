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

        public Encuesta BuscarPorId(int id)
        {
            return null;
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
