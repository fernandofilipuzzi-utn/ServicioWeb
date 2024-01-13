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
CREATE TABLE IF NOT EXISTS encuestas (
    id INTEGER PRIMARY KEY AUTOINCREMENT, 
    anio INTEGER NOT NULL,
    localidad TEXT,
    porc_bicicleta REAL DEFAULT 0,
    porc_caminando REAL DEFAULT 0,
    porc_transporte_publico REAL DEFAULT 0,
    porc_transporte_privado REAL DEFAULT 0,
    distancia_media REAL DEFAULT 0,
    en_curso INTEGER CHECK (en_curso IN (0, 1))
)";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.ExecuteNonQuery();
                }

                Console.WriteLine("Finalizado con exito! ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
