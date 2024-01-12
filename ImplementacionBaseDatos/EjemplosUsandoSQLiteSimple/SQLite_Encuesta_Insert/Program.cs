using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncuestasNuevoModels.Models;
using System.Data.SQLite;


namespace SQLite_Encuesta_Insert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //caso
            Encuesta nueva = new Encuesta { Anio = 2023, Localidad = "Paraná" };

            string cadenaConexion = "Data Source=../../../db_encuestas.db;Version=3;";
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
insert into encuestas (anio, localidad, en_curso)
values (@anio, @localidad, @enCurso)
RETURNING id;";

                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("anio", DbType.Int32));
                    query.Parameters.Add(new SQLiteParameter("localidad", DbType.String));
                    query.Parameters.Add(new SQLiteParameter("enCurso", DbType.Int32));

                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["enCurso"].Value = nueva.EnCurso ? 1 : 0;

                    //
                   //int  rowsaffected = query.ExecuteNonQuery();
                    object id = query.ExecuteScalar();
                    nueva.Id = Convert.ToInt32(id);

                    Console.WriteLine("Finalizado con exito! ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}|{ex.StackTrace}");
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
