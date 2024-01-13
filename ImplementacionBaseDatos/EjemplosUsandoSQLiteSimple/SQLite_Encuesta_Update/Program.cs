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
            Encuesta nueva = new Encuesta { Id=1, Anio = 2023, Localidad = "Parana", PorcBicicleta=0 };

            string cadenaConexion = "Data Source=../../../db_encuestas.db;Version=3;";
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(cadenaConexion);
                conn.Open();

                string sql = $@"
update encuestas 
set anio=@anio, 
        localidad='{nueva.Localidad}',
        porc_bicicleta=@porcBicicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia,
        en_curso=1
where id=@id";

                int rowsaffected = 0;
                using (var query = new SQLiteCommand(sql, conn))
                {
                    query.Parameters.Add(new SQLiteParameter("anio", SqlDbType.Int));
                   // query.Parameters.Add(new SQLiteParameter("@localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SQLiteParameter("porcBicicleta", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcCaminando", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePublico", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("porcTransportePrivado", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("distanciaMedia", SqlDbType.Decimal));
                    query.Parameters.Add(new SQLiteParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    //  query.Parameters["localidad"].Value =nueva.Localidad; //parche: da error, en System.Number.StringToNumber(String str, NumberStyles options, NumberBuffer& number, NumberFormatInfo info, Boolean parseDecimal) en System.Number.ParseInt32(String s, NumberStyles style, NumberFormatInfo info) sqllite text string
                    query.Parameters["porcBicicleta"].Value = nueva.PorcBicicleta;
                    query.Parameters["porcCaminando"].Value = nueva.PorcCaminando;
                    query.Parameters["porcTransportePublico"].Value = nueva.PorcTransportePublico;
                    query.Parameters["porcTransportePrivado"].Value = nueva.PorcTransportePrivado;
                    query.Parameters["distanciaMedia"].Value = nueva.DistanciaMedia;
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
