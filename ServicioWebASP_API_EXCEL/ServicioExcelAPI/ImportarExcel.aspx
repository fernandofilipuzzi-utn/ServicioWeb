<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportarExcel.aspx.cs" Inherits="ServicioAPI.ImportarExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="contain" style="min-width: 786px;">

        <div class="jumbotron" style="background-color: #dcdced; min-width: 786px;">
            <h3 class="display-4">Alta/Modificación de credenciales</h3>
            <p class="lead">Alta de credenciales.</p>
        </div>

        <div class="row m-0 p-0">

            <div class="col-12 mb-3 mt-3" style="background-color: #dcdced;">


                <div class="row justify-content-end p-2">
                    <div class="col-8">
                        <asp:FileUpload ID="fuFicheroExcel" class="file-upload" ToolTip="Elegir excel" name="Subir fichero" value="elegir" runat="server" accept=".xlsx" />
                    </div>
                </div>

                <div class="col-12  text-center p-2">
                    <asp:Button ID="btnEnviar" type="submit" class="btn btn-primary mx-auto" OnClick="btnEnviar_Click" runat="server" Text="Enviar" />
                </div>
            </div>
        </div>

        <div class="row m-0 p-0">

            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table class="table table-condensed table-borderless table-hover text-center">
                        <thead class="table-dark">
                            <th>A1</th>
                            <th>B1</th>                            
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("A1") %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

        <div class="row m-0 p-0">

    <asp:ListView ID="ListView2" runat="server">
        <LayoutTemplate>
            <table class="table table-condensed table-borderless table-hover text-center">
                <thead class="table-dark">
                    <th>A1</th>
                    <th>B1</th>                            
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </tbody>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("A1") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</div>
    </div>

</asp:Content>
