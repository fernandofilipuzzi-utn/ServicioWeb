using ServicioEncuestaSimple.Controllers;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;


namespace servicio
{

    class Program
    {
        public static object StreamFile { get; private set; }

        static void Main()
        {
            // Definir la URL base
            string url = "http://localhost:2000/";

            // Iniciar el servidor en un subproceso
            Thread serverThread = new Thread(() => StartServer(url));
            serverThread.Start();

            Console.WriteLine($"Servidor iniciado en {url}");
            Console.WriteLine("Presiona Enter para detener el servidor.");
            Console.ReadLine();

            // Detener el servidor cuando se presiona Enter
            StopServer();
            serverThread.Join();
        }

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

                        #region Manejar la solicitud según el método HTTP
                        switch (request.HttpMethod)
                        {
                            case "GET":
                                {
                                    // Obtener la ruta del recurso solicitado
                                    string requestedResource = request.Url.AbsolutePath;
                                    HandleGetRequest(requestedResource, request, response);
                                }
                                break;
                            case "POST":
                                {
                                    // Obtener la ruta del recurso solicitado
                                    string requestedResource = request.Url.AbsolutePath;
                                    HandleGetRequest(requestedResource, request, response);
                                }
                                break;
                            case "PUT":
                                HandlePutRequest(response);
                                break;
                            case "DELETE":
                                HandleDeleteRequest(response);
                                break;
                            default:
                                response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;//405
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
        static void HandleGetRequest(string requestedResource, HttpListenerRequest request, HttpListenerResponse response)
        {

            
            if (File.Exists("web/" + requestedResource) == true)
            {
                #region páginas estáticas
                string html = File.ReadAllText("web/" + requestedResource);
                byte[] buffer = Encoding.UTF8.GetBytes(html);
                response.ContentType = "text/html";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                #endregion
            }
            else
            {
                if (requestedResource == "/encuesta-controller")
                {
                    EncuestaController controlador = new EncuestaController();

                    NameValueCollection queryParams = request.QueryString;

                    string accion = queryParams["btnAccion"];

                    if (accion == "registrarRespuesta")
                    {
                        string email = queryParams["tbEmail"];

                        bool usaBicleta = queryParams["ckbUsaBicicleta"] == "1";
                        bool camina = queryParams["ckbCamina"]=="1";
                        bool usaTransportePublico = queryParams["ckbTransportePublico"] == "1";
                        bool usaTransportePrivado = queryParams["ckbTransportePrivado"] == "1";
                        double distancia = 0;
                        if (string.IsNullOrEmpty(queryParams["tbDistancia"]))
                            distancia = Convert.ToDouble(queryParams["tbDistancia"]);


                        controlador.GetRegistrarEncuesta( email,
                                                          usaBicleta, camina, usaTransportePublico, usaTransportePrivado,
                                                          distancia);
                    }

                    response.Redirect("index.html");
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound; // 404
                }
            }
        }

        /// POST
        static void HandlePutRequest(string requestedResource, HttpListenerRequest request, HttpListenerResponse response)
        {
            if (File.Exists("web/" + requestedResource) == true)
            {
                #region páginas estáticas
                string html = File.ReadAllText("web/" + requestedResource);
                byte[] buffer = Encoding.UTF8.GetBytes(html);
                response.ContentType = "text/html";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                #endregion
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
                       // controlador.GetRegistrarEncuesta(Convert.ToDouble(distanciaValue));
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
<html>
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
    }
}