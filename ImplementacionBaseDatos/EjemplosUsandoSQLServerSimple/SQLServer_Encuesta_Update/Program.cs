using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer_Encuesta_Update
{
    class Program
    {
        static void Main(string[] args)
        {
            //caso
            Encuesta nueva = new Encuesta { Id=1, Anio = 2023, Localidad = "Paraná", PorcBicleta=0 };

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
update encuestas 
set anio=@anio, 
        localidad=@localidad, 
        porc_bicicleta=@porcBicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia  
where id=@id";

                int rowsaffected = 0;
                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("porcBicleta", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcCaminando", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePublico", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePrivado", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("distanciaMedia", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["porcBicleta"].Value = nueva.PorcBicleta;
                    query.Parameters["porcCaminando"].Value = nueva.PorcCaminando;
                    query.Parameters["porcTransportePublico"].Value = nueva.PorcTransportePublico;
                    query.Parameters["porcTransportePrivado"].Value = nueva.PorcTransportePrivado;
                    query.Parameters["distanciaMedia"].Value = nueva.DistanciaMedia;
                    query.Parameters["id"].Value = nueva.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected } filas.");
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
