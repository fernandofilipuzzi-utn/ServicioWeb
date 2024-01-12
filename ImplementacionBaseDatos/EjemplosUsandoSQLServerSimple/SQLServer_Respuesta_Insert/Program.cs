using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer_Respuesta_Insert
{
    class Program
    {
        static void Main(string[] args)
        {
            //caso
            Respuesta nueva = new Respuesta {Email="fernando@gmail.com",    
                                            UsaBicicleta=true, 
                                            Camina=false, 
                                            UsaTransportePublico=true, 
                                            UsaTransportePrivado=false,
                                            DistanciaASuDestino=23};
            //aquí tenemos que considerar a que encuesta pertenece esa respuesta
            //y solo aquí presupong que esta dada de alta con id=2
            Encuesta aDondePertenec = new Encuesta { Id = 2, Anio = 2023, Localidad = "Paraná" };
            //tengo dos objetos de entrada a esta subrutina, una es la respuesta, y otra donde pertence
            // 
            //en el dao quedarán separados los dos insert,
            //pero generaremos una exception en el dao de la respuesta si no existe esa id de encuesta 

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
insert respuestas (email, usa_bicicleta, camina, usa_transporte_publico, usa_transporte_privado, distancia_a_su_destino, id_encuesta)
output INSERTED.id 
values (@email, @usaBicicleta, @camina, @usaTransportePublico, @usaTransportePrivado, @distanciaASuDestino, @id_encuesta)";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("email", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("usaBicicleta", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("camina", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("usaTransportePublico", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("usaTransportePrivado", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("distanciaASuDestino", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("id_encuesta", SqlDbType.Int));
                    //
                    query.Parameters["email"].Value = nueva.Email;
                    query.Parameters["usaBicicleta"].Value = nueva.UsaBicicleta;
                    query.Parameters["camina"].Value = nueva.Camina;
                    query.Parameters["usaTransportePublico"].Value = nueva.UsaTransportePublico;
                    query.Parameters["usaTransportePrivado"].Value = nueva.UsaTransportePrivado;
                    query.Parameters["distanciaASuDestino"].Value = nueva.DistanciaASuDestino;
                    query.Parameters["id_encuesta"].Value = aDondePertenec.Id;
                    //
                    //rowsaffected += query.ExecuteNonQuery();
                    Int32 id = (Int32)query.ExecuteScalar();
                    nueva.Id = id;
                }

                Console.WriteLine($"Id del registro insertado es: {nueva.Id}");
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
