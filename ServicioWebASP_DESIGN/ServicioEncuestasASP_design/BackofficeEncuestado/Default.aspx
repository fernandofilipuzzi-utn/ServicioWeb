<%@ Page Title="" Language="C#" MasterPageFile="~/BackofficeEncuestado/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioEncuestas_design.BackofficeEncuestado.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       

    <div class="container text-center m-2">

        <div class="row">

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/inicio-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Formulario de encuestas</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Complete el formulario!</p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="/BackofficeEncuestado/FormularioEncuesta.aspx">Ir</a>
                </div>
            </div>
            
        </div>
    </div>

</asp:Content>
