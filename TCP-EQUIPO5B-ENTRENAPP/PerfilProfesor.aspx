<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProfesor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mis alumnos</h3>

    <asp:Repeater ID="rptAlumnos" runat="server">
        <HeaderTemplate>
            <ul class="list-group">
        </HeaderTemplate>

        <ItemTemplate>
            <li class="list-group-item">
                <%# Eval("Nombre") %> <%# Eval("Apellido") %>
                <br />
                <small class="text-muted"><%# Eval("Email") %></small>
                <a href="/RutinaProfesor" class="btn btn-primary btn-sm text-uppercase" role="button">Ver rutina </a>

            </li>


        </ItemTemplate>

        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>



</asp:Content>
