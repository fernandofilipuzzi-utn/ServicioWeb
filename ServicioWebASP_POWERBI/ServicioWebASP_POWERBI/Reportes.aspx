<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ServicioWebASP_POWERBI.Reportes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Encuesta Año: <asp:Label ID="Label1" runat="server"></asp:Label>
                    de la localidad: <asp:Label ID="Label2" runat="server"></asp:Label></h3>
        <p>A continuación se muestra los resultados finales de la encuesta.</p>
    </div>

    <div class="container">    
        <iframe id="iframeControl" runat="server" frameborder="0" allowFullScreen="true"></iframe>
    </div>
</asp:Content>
