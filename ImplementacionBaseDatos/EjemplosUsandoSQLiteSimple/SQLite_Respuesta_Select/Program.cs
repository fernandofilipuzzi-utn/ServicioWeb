using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_Respuesta_Select
{
    class Program
    {
        static void Main(string[] args)
        {

            string cadenaConexion = "Data Source=../../../db_encuestas.db;Version=3;";
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = "select id, email from respuestas order by id asc";//agregar los otros

                using (var command = new SQLiteCommand(sql, conn))
                {
                    SQLiteDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = Convert.ToInt32(dataReader["id"]);
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
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
