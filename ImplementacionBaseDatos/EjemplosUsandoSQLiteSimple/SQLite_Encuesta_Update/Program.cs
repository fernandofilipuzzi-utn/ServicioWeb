using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SQLite_Encuesta_Update
{
    class Program
    {
        static void Main(string[] args)
        {
            //caso
            Encuesta nueva = new Encuesta { Id=1, Anio = 2023, Localidad = "Paraná", PorcBicleta=0 };

            string cadenaConexion = "Data Source=../../../db_encuestas.db;Version=3;";
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = @"
update encuestas 
set anio=@anio, 
        localidad=@localidad, 
        porc_bicicleta=@porcBicicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia  
where id=@id";

                int rowsaffected = 0;
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SQLiteParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SQLiteParameter("porcBicicleta", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcCaminando", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePublico", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePrivado", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("distanciaMedia", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["anio"].Value = (Int32)nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["porcBicicleta"].Value = 0;
                    query.Parameters["porcCaminando"].Value = 0;
                    query.Parameters["porcTransportePublico"].Value = 0;
                    query.Parameters["porcTransportePrivado"].Value =0;
                    query.Parameters["distanciaMedia"].Value =0;
                    query.Parameters["id"].Value = (Int32)nueva.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected } filas.");
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
