using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer_Respuesta_Select
{
    class Program
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

                string sql = "select id, email from respuestas order by id asc";//agregar los otros

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

                        #region email
                        string email= "";
                        if (dataReader["email"] != DBNull.Value)
                            email = dataReader["email"] as string;
                        #endregion

                        Console.WriteLine($"\t\t{id,10} | { email,20}");
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
