using EncuestasModels.Models;
using ServicioWebSimpleCss.Controllers;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace ServicioWebSimpleCss
{
    class Program
    {
        public static object StreamFile { get; private set; }

        static void Main()
        {
            // url
            string url = "http://localhost:2000/";

            #region subproceso  que atiende las consultas http
            Thread serverThread = new Thread(() => StartServer(url));
            serverThread.Start();
            #endregion

            Console.WriteLine($"Servidor iniciado en {url}");
            Console.WriteLine("Presiona Enter para detener el servidor.");
            Console.ReadLine();

            #region finalización del servicio
            StopServer();
            serverThread.Join();
            #endregion
        }

        #region métodos auxiliares

        static void StartServer(string url)
        {
            using (HttpListener listener = new HttpListener())
            {
                listener.Prefixes.Add(url);
                listener.Start();

                Console.WriteLine("Esperando solicitudes...");

                while (listener.IsListening)
                {
                    HttpListenerContext context = listener.GetContext();
                    ThreadPool.QueueUserWorkItem((state) =>
                    {
                        HttpListenerRequest request = context.Request;
                        HttpListenerResponse response = context.Response;

                        // resolviendo la urta al recurso solicitado
                        string requestedResource = request.Url.AbsolutePath;

                        #region Manejar la solicitud según el método HTTP
                        switch (request.HttpMethod)
                        {
                            case "GET":
                                {
                                    HandleGetRequest(requestedResource, request, response);
                                }
                                break;
                            case "POST":
                                {
                                    HandleGetRequest(requestedResource, request, response);
                                }
                                break;
                            case "PUT":
                                {
                                    HandlePutRequest(response);
                                }
                                break;
                            case "DELETE":
                                {
                                    HandleDeleteRequest(response);
                                }
                                break;
                            default:
                                {
                                    response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;//405
                                }
                                break;
                        }
                        #endregion

                        response.Close();
                    }, null);
                }
            }
        }

        static void StopServer()
        {
        }
                
        /// GET
        static void HandleGetRequest(string requestedResource, 
                                     HttpListenerRequest request, 
                                     HttpListenerResponse response)
        {
            try
            {
                if (File.Exists("web/" + requestedResource) == true)
                {
                    ResuelvePaginasEstaticas(requestedResource, response);
                }
                else
                {
                    if (requestedResource == "/encuesta-controller")
                    {
                        EncuestaController controlador = new EncuestaController();
                        NameValueCollection queryParams = request.QueryString;
                        string accion = queryParams["btnAccion"];
                        #region resolviendo las acciones

                        #region proceso iniciarEncuesta
                        if (accion == "iniciarEncuesta")
                        {
                            string localidad = queryParams["tbLocalidad"];

                            int anio = 0;
                            if (string.IsNullOrEmpty(queryParams["tbAnio"]))
                                anio = Convert.ToInt32(queryParams["tbAnio"]);

                            Encuesta nueva = controlador.GetIniciarEncuesta(anio, localidad);

                            string html = $@"
<!DOCTYPE html>
<html lang=""es"">
  <head>
    <meta charset=""UTF-8""> 
    <title>Encuesta recien creada</title>
  </head>
  <body>
    <h1>Encuesta del año {nueva.Anio} iniciada con Id:{nueva.Id};</h1>
    <br/>
    <a href=""index.html"">Volver al menú principal</a>
  </body>
</html>";
                            HtmlResponse(html, response);
                        }
                        #endregion
                        #region proceso registrarRespuesta
                        else if (accion == "registrarRespuesta")
                        {
                            
                            string email = queryParams["tbEmail"];

                            bool usaBicleta = queryParams["ckbUsaBicicleta"] == "1";
                            bool camina = queryParams["ckbCamina"] == "1";
                            bool usaTransportePublico = queryParams["ckbTransportePublico"] == "1";
                            bool usaTransportePrivado = queryParams["ckbTransportePrivado"] == "1";
                            double distancia = 0;
                            if (string.IsNullOrEmpty(queryParams["tbDistancia"]))
                                distancia = Convert.ToDouble(queryParams["tbDistancia"]);


                            controlador.GetRegistrarEncuesta(email,
                                                              usaBicleta, camina, usaTransportePublico, usaTransportePrivado,
                                                              distancia);
                            
                        }
                        #endregion
                        #region proceso cerrarEncuesta
                        else if (accion == "cerrarEncuesta")
                        {
                            
                            Encuesta enCierre=controlador.GetCerrarEncuesta();

                            string html = $@"
<!DOCTYPE html>
<html lang=""es"">
  <head>
    <meta charset=""UTF-8"">
    <title>Resultados de la encuesta del año {enCierre.Anio}</title>
  </head>
  <body>
    <h3>Encuesta Año: {enCierre.Anio} de la localidad: {enCierre.Localidad} Cerrada</h3>
    <br/>
    <h4>Población encuestada:</h4> 
        <p>{enCierre.CantidadEncuestados}</p>
    <br/>
    <h4>Resultados en porcentajes sobre el medio de transporte utilizado respecto al total de encuestados</h4>
        <p><b>Uso de bicicleta:</b> {enCierre.PorcBicleta}%</p>
        <p><b>Caminando:</b> {enCierre.PorcCaminando}%</p>
        <p><b>Transporte Público:</b> {enCierre.PorcTransportePublico}%</p>
        <p><b>Transporte propio (automóvil, ciclomotor, etc):</b> {enCierre.PorcTransportePrivado}%</p>
    <br/>
    <h4>Distancia media recorrida:</h4> 
        <p>{enCierre.DistanciaMedia}</p>
    <br/>
    <br/>
    <a href=""./index.html"">Volver al menú principal</a>
  </body>
</html>";
                            HtmlResponse(html, response);
                        }
                        #endregion
                        
                        #endregion

                        response.Redirect("index.html");
                    }
                    else
                    {
                        response.StatusCode = (int)HttpStatusCode.NotFound; // 404
                    }
                }
            }
            #region resoviendo las excepciones
            catch (Exception ex)
            {
                string html = $@"
<!DOCTYPE html>
<html lang=""es"">
  <head>
    <meta charset=""UTF-8"">
    <title>Encuesta recien creada</title>
  </head>
  <body>
    <h1>Error interno!</h1>
    <p>{ex.Message}</p>
    <p>{ex.StackTrace.ToString()}</p>
    <br/>
    <a href=""index.html"">Volver al menú principal</a>
  </body>
</html>";
                HtmlResponse(html, response);
            }
            #endregion
        }

        /// POST
        static void HandlePutRequest(string requestedResource, HttpListenerRequest request,
                                                        HttpListenerResponse response)
        {
            if (File.Exists("web/" + requestedResource) == true)
            {
                ResuelvePaginasEstaticas(requestedResource, response);
            }
            else
            {
                if (requestedResource == "/WebRegistroDeEncuestaController")
                {
                    EncuestaController controlador = new EncuestaController();

                    using (var reader = new StreamReader(request.InputStream))
                    {
                        string requestBody = reader.ReadToEnd();
                        var formData = ParseQueryString(requestBody);
                        string distanciaValue = formData["tbDistancia"];
                       //
                    }

                    response.Redirect("index.html");
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound; // 404
                }
            }
        }

        private static NameValueCollection ParseQueryString(string queryString)
        {
            var collection = new NameValueCollection();

            foreach (var pair in queryString.Split('&'))
            {
                var parts = pair.Split('=');
                if (parts.Length == 2)
                {
                    var key = Uri.UnescapeDataString(parts[0]);
                    var value = Uri.UnescapeDataString(parts[1]);
                    collection.Add(key, value);
                }
            }

            return collection;
        }

        /// PUT
        static void HandlePutRequest(HttpListenerResponse response)
        {
            string html = File.ReadAllText("file");

            byte[] buffer = Encoding.UTF8.GetBytes(html);

            response.ContentType = "text/html";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        /// DELETE
        static void HandleDeleteRequest(HttpListenerResponse response)
        {
            string html = @"
<!DOCTYPE html>
<html lang=""es"">
  <head>
    <meta charset=""UTF-8"">
  </head>
  <body>
    <h1>Página HTML básica (DELETE)
    </h1>
  </body>
</html>";
            byte[] buffer = Encoding.UTF8.GetBytes(html);

            response.ContentType = "text/html";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        static void ResuelvePaginasEstaticas(string requestedResource, HttpListenerResponse response)
        {
            if (requestedResource.EndsWith(".jpg"))
            {
                byte[] buffer = File.ReadAllBytes("web/" + requestedResource);
                response.ContentType = "image/jpeg";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else if (requestedResource.EndsWith(".html") || requestedResource.EndsWith(".htm"))
            {
                string html = File.ReadAllText("web/" + requestedResource);
                byte[] buffer = Encoding.UTF8.GetBytes(html);
                response.ContentType = "text/html";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else
            { 
            }
        }

        static void HtmlResponse(string html, HttpListenerResponse response)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(html);

            response.ContentType = "text/html";
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
        }

        #endregion

    }
}