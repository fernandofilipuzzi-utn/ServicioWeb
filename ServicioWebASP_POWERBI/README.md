# PowerBI ejemplo




## Temas
* [Embebiendo el reporte](# 'Embebiendo el reporte')
* [Obtener el token](# 'Obtener el token')

## Embebiendo el reporte
<details>
        <summary>Cómo embeber el documento en la página aspx</summary>
        

```
Página ejemplo 
```html
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ServicioWebASP_POWERBI.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <iframe id="iframeControl" runat="server" width="800" height="600" frameborder="0" allowFullScreen="true"></iframe>
    </form>
</body>
</html>
```

El code-behin de dicha página;
```csharp
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        PowerBiUtils utils = new PowerBiUtils();                
        string embedToken = utils.GetEmbedToken("ID_DE_REPORTE");
        iframeControl.Attributes["src"] = $"http://localhost:8000/Reports/powerbi/prueba?rs:embed=true&embedToken={embedToken}";
    }
}

</details>

## Obtener el token
<details>
        <summary></summary>
     

```csharp
namespace PowerBIAPIServer.ClientServices.Services
{
    public class PowerBiUtils
    {
        /// <summary>
        /// Obtener token de acceso a powerbi
        /// </summary>
        /// <returns></returns>
        public string GetEmbedToken(string reportId)
        {
            string workspaceId = "ESPACIO_DE_TRABAJO";
            //string reportId = "ID_DE_REPORTE";
            string apiUrl = $"http://localhost:8000/api/v2.0/GenerateToken/Workspace/{workspaceId}/Report/{reportId}";

            string embedToken = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                // autorización si es necesario
                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "TOKEN_DE_AUTORIZACION");

                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    embedToken = response.Content.ReadAsStringAsync().Result;
                }
            }

            return embedToken;
        }
    }
}
```


</details>
