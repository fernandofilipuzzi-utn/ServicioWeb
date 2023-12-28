<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
        AutoEventWireup="true" CodeBehind="CierreEncuesta.aspx.cs" 
        Inherits="ServicioEncuestas.CierreEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Mi ministerio de transporte</h3>
        <p>Encuesta sobre el uso del transporte.</p>
    </div>

    <div class="container col-8">
         <h3>Finalizando la encuesta en curso</h3>

        <div class="form-group">
            <label for="cbLocalidad">Elija la Localidad de la encuesta: </label>
            <asp:DropDownList ID="cbLocalidad"  class="form-control" name="tbDistancia" DataTextField="Localidad" DataValueField="Id" runat="server" />
        </div>

        <div class="text-center">
            <asp:Button ID="btnAccion" CssClass="btn btn-primary" name="btnAccion" OnClick="btnAccion_Click" Text="cerrarEncuesta" runat="server"/>
        </div>
    </div>
</asp:Content>
