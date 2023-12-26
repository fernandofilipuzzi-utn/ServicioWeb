<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
        CodeBehind="InicioEncuesta.aspx.cs" Inherits="ServicioEncuestas.InicioEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Mi ministerio de transporte</h3>
        <p>Encuesta sobre el uso del transporte.</p>
    </div>


    <div class="container col-8 ">
                
        
            <h3 class="text-center">Inicio de nueva encuesta</h3>

            <div class="form-inline m-2">
                <label class="col-3" for="tbAni">Año: </label> 
                <asp:TextBox ID="tbANIO" CssClass="form-control col-5" type="number" name="tbAnio" runat="server" />
            </div>
            <div class="form-inline m-2">
                <label for="tbLocalidad" class="col-3">Localidad: </label> 
                <asp:TextBox ID="tbLocalidad" CssClass="form-control col-5"  type="text"  name="tbLocalidad" runat="server"/>
            </div>
            <div class="text-center m-2">
                <asp:Button ID="btnIniciarEncuesta" type="button" CssClass="btn btn-primary" name="btnAccion" Text="Iniciar" OnClick="btnIniciarEncuesta_Click" runat="server"/>
            </div>
            
       
    </div>
</asp:Content>
