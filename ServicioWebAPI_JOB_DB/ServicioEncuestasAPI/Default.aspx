<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioEncuestasAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="jumbotron">
        <h3 class="display-4">Mi ministerio de transporte</h3>
        <p class="lead">Encuesta sobre el uso del transporte.</p>
    </div>

    <div class="container row text-center m-2">

        <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
            <img src="./img/inicio-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
            <div class="card-body">
                <div class="card-title">
                    <h2>Documentación API</h2>
                </div>
                <div class="card-text" style="max-height: 60px; overflow: hidden;">
                    <p>Enlace hacia la documentación de la API </p>
                </div>

            </div>
            <div class="text-center">
                <a class="btn btn-primary" href="https://localhost:44376/swagger" target="_blank" >Ir</a>
            </div>
        </div>


    </div>

</asp:Content>
