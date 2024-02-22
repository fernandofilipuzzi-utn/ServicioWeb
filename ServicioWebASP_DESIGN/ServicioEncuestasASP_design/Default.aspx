<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioEncuestas_design._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3 class="display-4">Mi ministerio de transporte</h3>
        <p class="lead">Encuesta sobre el uso del transporte.</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-4 col-md-5 col-sm-6 m-2 p-3">
            <img src="/img/administrativo.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Administración</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Para administrativos</p>
                </div>

            </div>
            <div class="text-center">
                <a class="btn btn-primary" href="/BackofficeAdmin/login.aspx">Ingresar</a>
            </div>
        </div>

        <div class="card col-lg-4 col-md-5 col-sm-6 m-2 p-3">
            <img src="/img/registrar-encuesta-azul.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Opinión pública</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Dejenos su opinión personal sobre su uso del transporte.</p>
                </div>

            </div>
            <div class="text-center">
                <a class="btn btn-primary" href="/backofficeEncuestado/Login.aspx">Ingresar</a>
            </div>
        </div>

    </div>

</asp:Content>