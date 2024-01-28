<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="ServicioWebASP_POWERBI.Resultados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Encuesta Año: <asp:Label ID="lbAnio" runat="server"></asp:Label>
                    de la localidad: <asp:Label ID="lbLocalidad" runat="server"></asp:Label></h3>
        <p>A continuación se muestra los resultados finales de la encuesta.</p>
    </div>

    <div class="container col-8">
    
        <div class="container p-3 mb-3" style="background-color: #d6e1ed">
            <h4>Población encuestada:</h4> 
            <asp:Label ID="lbCantidadEncuestados" runat="server"/>
        </div>
    
        <div  class="container p-3 mb-3" style="background-color: #d6e1ed">
            <h4>Resultados en porcentajes sobre el medio de transporte utilizado respecto al total de encuestados</h4>
        
            <b>Uso de bicicleta:</b> <asp:Label ID="lbPorcBicicleta" runat="server"></asp:Label><br/>
            <b>Caminando:</b> <asp:Label ID="lbPorcCaminando" runat="server"></asp:Label><br/>
            <b>Transporte Público:</b> <asp:Label ID="lbPorcTransportePublico" runat="server"></asp:Label><br/>
            <b>Transporte propio (automóvil, ciclomotor, etc):</b> <asp:Label ID="lbPorcTransportePrivado" runat="server"></asp:Label>        
        </div>

        <div  class="container p-3 mb-3" style="background-color: #d6e1ed">
            <h4>Distancia media recorrida:</h4> 
            <asp:Label ID="lbDistancia" runat="server"></asp:Label>
        </div>
    
        <div class="text-center p-3 mb-3">
            <asp:HyperLink ID="btnVolver" CssClass="btn btn-primary" 
                        NavigateUrl="Default.aspx" runat="server">Volver al menú principal</asp:HyperLink>
        </div>
    </div>
</asp:Content>
