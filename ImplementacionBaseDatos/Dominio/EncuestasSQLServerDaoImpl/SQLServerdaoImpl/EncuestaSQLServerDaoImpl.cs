﻿using EncuestasDAO.DAO;
using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasSQLServerDaoImpl.SQLServerDaoImpl
{
    public class EncuestaSQLServerDaoImpl : IEncuestaDAO
    {
        #region parámetros
        //string servidor = "TSP";
        string servidor = "TUPDEV";
        string baseDatos = "db_encuestas";
        #endregion

        string cadenaConexion = "";

        public EncuestaSQLServerDaoImpl()
        {
            // Cadena de conexión para SQL Server con autenticación de Windows
            cadenaConexion = $"Data Source={servidor};Initial Catalog={baseDatos};Integrated Security=True;";
            Inicializar();
        }

        private void Inicializar()
        {
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'encuestas')
BEGIN
    CREATE TABLE encuestas (
        id INT PRIMARY KEY IDENTITY(1,1), 
        anio INT NOT NULL,
        localidad VARCHAR(50) NOT NULL,
        porc_bicicleta NUMERIC(10,2) DEFAULT 0,
        porc_caminando NUMERIC(10,2) DEFAULT 0,
        porc_transporte_publico NUMERIC(10,2) DEFAULT 0,
        porc_transporte_privado NUMERIC(10,2) DEFAULT 0,
        distancia_media NUMERIC(10,2) DEFAULT 0,
        en_curso BIT NOT NULL
    )
END
";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public void Actualizar(Encuesta actual)
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
UPDATE encuestas 
SET anio=@anio, 
        localidad=@localidad, 
        porc_bicicleta=@porcBicicleta, 
        porc_caminando=@porcCaminando, 
        porc_transporte_publico=@porcTransportePublico,
        porc_transporte_privado=@porcTransportePrivado,
        distancia_media=@distanciaMedia,
        en_curso=@enCurso  
WHERE id=@id";

                int rowsaffected = 0;
                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("porcBicicleta", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcCaminando", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePublico", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("porcTransportePrivado", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("distanciaMedia", SqlDbType.Decimal));
                    query.Parameters.Add(new SqlParameter("enCurso", SqlDbType.Bit));
                    query.Parameters.Add(new SqlParameter("id", SqlDbType.Int));
                    //
                    query.Parameters["anio"].Value = actual.Anio;
                    query.Parameters["localidad"].Value = actual.Localidad;
                    query.Parameters["porcBicicleta"].Value = actual.PorcBicicleta;
                    query.Parameters["porcCaminando"].Value = actual.PorcCaminando;
                    query.Parameters["porcTransportePublico"].Value = actual.PorcTransportePublico;
                    query.Parameters["porcTransportePrivado"].Value = actual.PorcTransportePrivado;
                    query.Parameters["distanciaMedia"].Value = actual.DistanciaMedia;
                    //
                    query.Parameters["enCurso"].Value = actual.EnCurso;
                    //
                    query.Parameters["id"].Value = actual.Id;
                    //
                    rowsaffected += query.ExecuteNonQuery();
                }

                Console.WriteLine($"Fueron modificadas {rowsaffected} filas.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        public Encuesta Agregar(Encuesta nueva)
        {   
            SqlConnection conn =null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
INSERT INTO encuestas (anio, localidad, en_curso)
OUTPUT INSERTED.id 
VALUES (@anio, @localidad, @enCurso)";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("anio", SqlDbType.Int));
                    query.Parameters.Add(new SqlParameter("localidad", SqlDbType.VarChar));
                    query.Parameters.Add(new SqlParameter("enCurso", SqlDbType.Bit));
                    //
                    query.Parameters["anio"].Value = nueva.Anio;
                    query.Parameters["localidad"].Value = nueva.Localidad;
                    query.Parameters["enCurso"].Value = Convert.ToInt32(nueva.EnCurso);
                    //
                    //rowsaffected += query.ExecuteNonQuery();
                    Int32 id = (Int32)query.ExecuteScalar();
                    nueva.Id = id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return nueva;
        }
                

        public void Eliminar(int id)
        {
            
        }

        public Encuesta BuscarPorId(int idBuscado)
        {
            Encuesta buscado = null;

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                //agregar los campos que faltan
                string sql = @"
select id, anio, localidad, 
        porc_bicicleta, porc_caminando, 
        porc_transporte_publico, 
        porc_transporte_privado, 
        distancia_media, 
        en_curso 
from encuestas 
where id=@Id";

                using (var query = new SqlCommand(sql, conn))
                {
                    query.Parameters.Add(new SqlParameter("Id", SqlDbType.Int));
                    //
                    query.Parameters["Id"].Value = idBuscado;

                    SqlDataReader dataReader = query.ExecuteReader();
                    
                    if( dataReader.Read() )
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
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

                        #region porcentaje  bicicleta
                        double? porcBicicleta = 0;
                        if (dataReader["porc_bicicleta"] != DBNull.Value)
                            porcBicicleta = Convert.ToDouble(dataReader["porc_bicicleta"]);

                        double? porcCaminando = 0;
                        if (dataReader["porc_caminando"] != DBNull.Value)
                            porcCaminando = Convert.ToDouble(dataReader["porc_caminando"]);

                        double? porcTransportePublico = 0;
                        if (dataReader["porc_transporte_publico"] != DBNull.Value)
                            porcTransportePublico = Convert.ToDouble(dataReader["porc_transporte_publico"]);

                        double? porcTransportePrivado = 0;
                        if (dataReader["porc_transporte_privado"] != DBNull.Value)
                           porcTransportePrivado = Convert.ToDouble(dataReader["porc_transporte_privado"]);

                        double? distanciaMedia = 0;
                        if (dataReader["distancia_media"] != DBNull.Value)
                             distanciaMedia = Convert.ToDouble(dataReader["distancia_media"]);
                        #endregion

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        buscado = new Encuesta { Id = id, Localidad = localidad, Anio = anio, 
                                                 PorcBicicleta=porcBicicleta,
                                                 PorcCaminando= porcCaminando,
                                                 PorcTransportePublico= porcTransportePublico,
                                                 PorcTransportePrivado= porcTransportePrivado,
                                                 DistanciaMedia= distanciaMedia ,
                                                 EnCurso = enCurso };
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return buscado;
        }

        public List<Encuesta> BuscarTodos()
        {
            List<Encuesta> encuestas = new List<Encuesta>();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, anio, localidad, en_curso 
from encuestas 
order by id asc";

                using (var query = new SqlCommand(sql, conn))
                {
                    SqlDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
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

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio, EnCurso = enCurso };
                        encuestas.Add(encuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return encuestas;
        }

        public List<Encuesta> BuscarUltimasEncuestaNoCerradas()
        {
            List<Encuesta> encuestasActivasLocalidades = new List<Encuesta>();

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = @"
select id, anio, localidad, en_curso 
from encuestas 
where en_curso=1
order by id asc";

                using (var query = new SqlCommand(sql, conn))
                {
                    SqlDataReader dataReader = query.ExecuteReader();
                    while (dataReader.Read())
                    {
                        #region ID
                        int id = 0;
                        if (dataReader["id"] != DBNull.Value)
                            id = (int)dataReader["id"];
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

                        #region actual!
                        bool enCurso = false;
                        if (dataReader["en_curso"] != DBNull.Value)
                            enCurso = (bool)dataReader["en_curso"];
                        #endregion

                        Encuesta encuesta = new Encuesta { Id = id, Localidad = localidad, Anio = anio , EnCurso=enCurso};
                        encuestasActivasLocalidades.Add(encuesta);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return encuestasActivasLocalidades;
        }


        public DataSet ListarEncuestas()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(cadenaConexion);
                conn.Open();

                string sql = "SELECT id, anio, localidad FROM encuestas";
                using (var query = new SqlCommand(sql, conn))
                {
                    using (var adapter = new SqlDataAdapter(query))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

            return ds;
        }
    }
}
