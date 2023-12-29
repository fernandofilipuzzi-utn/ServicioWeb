<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="CierreEncuesta.aspx.cs"
    Inherits="ServicioEncuestas.CierreEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3 class="display-4">Cierre de encuesta en curso</h3>
        <p class="lead">
            Elija la localidad de la encuesta que quiere cerrar.
        </p>
    </div>

    <div class="container">
        <div class="col p-3 mb-3" style="background-color: #d6e1ed;">
            <h3 class="text-center">Finalizando la encuesta en curso</h3>

            <div class="form-group">
                <label for="cbLocalidad">Elija la Localidad de la encuesta: </label>
                <asp:DropDownList ID="cbLocalidad" class="form-control" name="tbDistancia" DataTextField="Localidad" DataValueField="Id" runat="server" />
               
            </div>
        </div>

        <div class="text-center">
            <asp:Button ID="btnAccion" CssClass="btn btn-primary" name="btnAccion" OnClick="btnAccion_Click" Text="Cerrar Encuesta" runat="server" />
        </div>
    </div>
</asp:Content>
