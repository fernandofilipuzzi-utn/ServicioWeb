<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioAPI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container">

        <div class="jumbotron">
            <h3 class="display-4">Servicio para exportar e importar ficheros excel</h3>
            <p class="lead">.</p>
        </div>

        <div class="row text-center m-2">

            <div class="col">
                <div class="row">

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/registrar-encuesta.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>API Doc.</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ver Swagger</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:HyperLink class="btn btn-primary" ID="btnExcel" Target="_blank" NavigateUrl="/swagger/ui/index#/Excel" runat="server">Ir</asp:HyperLink>
                        </div>
                    </div>
                </div>

                <div class="border border-primary"></div>

                <div class="h3">Ejemplos usando API Web</div>

                <div class="row">
                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Exportar a Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Generar un fichero excel(XLSX) por medio de un datatable</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:LinkButton class="btn btn-primary" ID="btnExcelDesdeUnDataTable" OnClick="btnExcelDesdeUnDataTable_Click" runat="server"><i class="fa fa-download" aria-hidden="true"></i>Descargar</asp:LinkButton>
                        </div>
                    </div>

                    <div class="card col-lg-4 col-md-5 col-sm-7 m-2 p-3">
                        <img src="./img/excel2.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                        <div class="card-body">
                            <div class="card-title">
                                <h2>Importar Excel</h2>
                            </div>
                            <div class="card-text" style="max-height: 60px; overflow: hidden;">
                                <p>Ejemplo usando API</p>
                            </div>

                        </div>
                        <div class="text-center">
                            <asp:LinkButton class="btn btn-primary" ID="btnImportar" OnClick="btnImportar_Click" runat="server"><i class="fa fa-upload" aria-hidden="true"></i>Subir</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
