using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_Encuesta_Select
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadenaConexion = "Data Source=../../../db_encuestas.db;Version=3;";
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = "select id, anio, localidad from encuestas order by id asc";

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

            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
