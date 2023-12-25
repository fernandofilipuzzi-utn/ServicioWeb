<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ServicioEncuestas._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Mi Secretaria de transporte</h2>
        <p class="lead">Encuestas sobre el uso de los transportes urbanos</p>
    </div>

    <div class="container" id="content">

        <div class="sticky-inner">
            <asp:ListView ID="menuListView" runat="server">

                <LayoutTemplate>
                    <div class="row">
                        <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                    </div>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="card col-lg-3 col-md-4 col-sm-6 m-2 p-3">
                        <asp:Image ID="menuImage" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
                            CssClass="card-img-top img-fluid" style="height: 200px; object-fit: cover;" alt="" />

                        <div class="card-body">
                            <h5 class="card-title">"titulo"</h5>
                            <div class="card-text"  style="max-height: 60px; overflow: hidden;">Descripción</div>
                            
                        </div>
                        <div class="text-center">
                            <asp:HyperLink ID="menuLink" CssClass="btn btn-sm btn-primary" runat="server" NavigateUrl='#'> Ingresar </asp:HyperLink>
                        </div>
                    </div>
                    
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>