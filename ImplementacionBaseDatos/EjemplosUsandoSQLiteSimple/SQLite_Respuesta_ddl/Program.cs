using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncuestasNuevoModels.Models;
using System.Data.SQLite;

namespace SQLite_Encuesta_ddl
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
                Console.WriteLine($"{ex.Message}\n{ex.StackTrace.ToString()}");
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
