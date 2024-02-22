<%@ Page Title="" Language="C#" MasterPageFile="~/BackofficeAdmin/Site.Master" AutoEventWireup="true" CodeBehind="InicioEncuesta.aspx.cs" Inherits="ServicioEncuestas_design.BackofficeAdmin.InicioEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div class="col p-3 mb-3" style="background-color: #d6e1ed;">
            <h3 class="text-center">Datos generales</h3>

            <div class="form-inline m-2">
                <label class="col-3" for="tbAni">Año: </label>
                <asp:TextBox ID="tbANIO" CssClass="form-control col-5" type="number" name="tbAnio" runat="server" />
                <asp:RequiredFieldValidator ID="rvfAnio" runat="server" ControlToValidate="tbANIO" InitialValue="" ErrorMessage="Debe completar con el año" ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="form-inline m-2">
                <label for="tbLocalidad" class="col-3">Localidad: </label>
                <asp:TextBox ID="tbLocalidad" CssClass="form-control col-5" type="text" name="tbLocalidad" runat="server" />
                <asp:RequiredFieldValidator ID="rvfLocalidad" runat="server" ControlToValidate="tbLocalidad" InitialValue="" ErrorMessage="Debe seleccionar una localidad" ForeColor="Red" Display="Dynamic" />
            </div>
        </div>

        <div class="text-center m-2">
            <asp:Button ID="btnIniciarEncuesta" type="button" CssClass="btn btn-primary" name="btnAccion" Text="Iniciar Nueva Encuesta" OnClick="btnIniciarEncuesta_Click" runat="server" />
        </div>
    </div>
</asp:Content>
