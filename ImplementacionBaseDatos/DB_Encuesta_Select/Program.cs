using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Encuesta_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region parámetros
            //string servidor = "TSP\\SQLEXPRESS";//para sql server express
            string servidor = "TSP";
            string baseDatos = "db_encuestas";
            #endregion

            // Cadena de conexión para SQL Server con autenticación de Windows
            string cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = "select id, anio, localidad from encuestas order by id asc";

                using (var query = new SqlCommand(sql, conn))
                {
                    SqlDataReader dataReader = query.ExecuteReader();
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

                Console.WriteLine($"\t\t{id,10} | {anio,10} | { localidad,20}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}\n{e.StackTrace.ToString()}");
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            Console.ReadKey();
        }
    }
}
