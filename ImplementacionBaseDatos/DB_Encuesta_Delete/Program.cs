using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Encuesta_Delete
{
    class Program
    {
        static void Main(string[] args)
        {
            //caso - la id debe existir en la tabla esa para que muestre que borró 1 fila
            Encuesta nueva = new Encuesta { Id=1, Anio = 2023, Localidad = "Paraná" };

            #region parámetros
            string servidor = "TSP";
            string baseDatos = "db_encuestas";
            #endregion

            // Cadena de conexión para SQL Server con autenticación de Windows
            string cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";

            SqlConnection conn = new SqlConnection(cadenaConexion);
            try
            {
                conn.Open();

                string sql = @"
delete from encuestas 
where id=@id";

                int rowsaffected = 0;
                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["id"].Value = nueva.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"{rowsaffected} fueron eliminadas");
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
