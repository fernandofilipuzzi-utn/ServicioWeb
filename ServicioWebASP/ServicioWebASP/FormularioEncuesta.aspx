<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="FormularioEncuesta.aspx.cs"
    Inherits="ServicioEncuestas.FormularioEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>Mi ministerio de transporte</h3>
        <p>Encuesta sobre el uso del transporte.</p>
    </div>

    <h3>Encuesta sobre el uso de transporte</h3>

    <div class="form b-2 m-2">
        <div class="form-group">
            <label for="cbLocalidad">Localidad: </label>
            <asp:DropDownList ID="cbLocalidad" 
                                class="form-control" 
                                name="tbDistancia" 
                                DataTextField="Localidad"
                                DataValueField="Id"
                                runat="server" />
        </div>

        <div class="form-group">
            <h4>Datos personales</h4>
            <label for="tbEmail">Email: </label>
            <asp:TextBox ID="tbEmail" class="form-control" type="email" name="tbEmail" runat="server" />
        </div>

        <div>
            <h4>¿Qué medio de transporte usa con mayor frecuencia?. Tilde una o más opciones</h4>

            <div class="form-inline">
                <asp:CheckBox ID="ckbUsaBicicleta" class="form-control" name="ckbUsaBicicleta" type="checkbox" value="1a" runat="server" />
                <label for="ckbUsaBicicleta">Bicicleta</label>
            </div>

            <div class="form-inline">
                <asp:CheckBox ID="ckbCamina" class="form-control" name="ckbCamina" value="1" runat="server" />
                <label for="ckbCamina">Caminando</label>
            </div>

            <div class="form-inline">
                <asp:CheckBox ID="ckbTransportePublico" class="form-control" name="ckbTransportePublico" value="1" runat="server" />
                <label for="ckbTransportePublico">Transporte público, (colectivo, remis, tren, etc)</label>
            </div>

            <div class="form-inline">
                <asp:CheckBox ID="ckbTransportePrivado" class="form-control" name="ckbTransportePrivado" value="1" runat="server" />
                <label for="ckbTransportePrivado">Automóvil, Ciclomotor, etc</label>
            </div>
        </div>

        <div class="form-group">
            <label for="tbDistancia">Distancia al lugar de trabajo o estudio: </label>
            <asp:TextBox ID="tbDistancia" name="tbDistancia" runat="server" />(km)
        </div>

        <div class="text-center">
            <asp:Button ID="btnAccion" name="btnAccion" class="btn btn-primary" Text="Registrar Respuesta" OnClick="btnAccion_Click" runat="server" />
        </div>
    </div>
</asp:Content>
