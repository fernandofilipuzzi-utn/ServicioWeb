<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/BackofficeAdmin/Site.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioEncuestas_design.BackofficeAdmin._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       

    <div class="container text-center m-2">

        <div class="row">

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/inicio-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Iniciar Nueva Encuesta</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Cree una encuesta nueva de acuerdo a la loclidad de interés </p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="/BackofficeAdmin/InicioEncuesta.aspx">Ir</a>
                </div>
            </div>

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/cerrar-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Cerrar encuesta</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Cree una encuesta nueva de acuerdo a la loclidad de interés </p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="/BackofficeAdmin/CierreEncuesta.aspx">Ir</a>
                </div>
            </div>

            <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                <img src="/img/ver-resultados-estadisticos.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title">
                        <h2>Resultados</h2>
                    </div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Ver resultados estadísticos</p>
                    </div>

                </div>
                <div class="text-center">
                    <a class="btn btn-primary" href="/BackofficeAdmin/Resultados.aspx">Ir</a>
                </div>
            </div>

        </div>
    </div>

</asp:Content>