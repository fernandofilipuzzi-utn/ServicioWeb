<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="FormularioEncuesta.aspx.cs"
    Inherits="ServicioEncuestas.FormularioEncuesta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Consulta sobre el uso de transporte!</h3>
        <p class="lead">
            Respondenos algunas preguntas sobre el uso del transporte.
        </p>
    </div>

    <div class="container">

        <div class="col p-3 mb-3" style="background-color: #d6e1ed;">

            <h4>Datos personales</h4>

            <div class="form-group">
                <label for="tbEmail">Email: </label>
                <asp:TextBox ID="tbEmail" class="form-control" type="email" name="tbEmail" runat="server" />
                <!--validador-->
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail" InitialValue="" ErrorMessage="Debe completar con su correo electrónico." ForeColor="Red" Display="Dynamic" />
            </div>

            <div class="form-group">
                <label for="cbLocalidad">Elija la Localidad a la que pertence: </label>
                <asp:DropDownList ID="cbLocalidad" class="form-control" name="tbDistancia" DataTextField="Localidad" DataValueField="Id" runat="server" />
                <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="cbLocalidad" InitialValue="" ErrorMessage="Debe completar con la localidad a la que pertence." ForeColor="Red" Display="Dynamic" />
            </div>            
        </div>

        <div class="col validation-container p-3 mb-3" style="background-color: #d6e1ed;">
            <h4>¿Qué medio de transporte usa con mayor frecuencia?. Tilde una o más opciones</h4>



            <div class="form-inline">
                <asp:CheckBox ID="ckbUsaBicicleta" class="form-control" name="ckbUsaBicicleta" type="checkbox" value="1" runat="server" />
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

        <div class="col p-3 mb-3" style="background-color: #d6e1ed;">
            <div class="form-group">
                <label for="tbDistancia">Distancia al lugar de trabajo o estudio: </label>
                <asp:TextBox ID="tbDistancia" name="tbDistancia" runat="server" />(km)
                <asp:RequiredFieldValidator ID="rfvDistancia"  Enabled="true" runat="server" ControlToValidate="tbDistancia" InitialValue="" ErrorMessage="Debe completar el campo." ForeColor="Red" Display="Dynamic" />
            </div>
        </div>

        <div class="text-center m-2">
            <asp:Button ID="btnAccion" name="btnAccion" class="btn btn-primary" Text="Registrar Respuesta" OnClick="btnAccion_Click" runat="server" />
        </div>
    </div>

</asp:Content>
