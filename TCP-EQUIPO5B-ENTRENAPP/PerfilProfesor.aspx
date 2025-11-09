<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProfesor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilProfesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Repeater ID="rptAlumnos" runat="server">
    <HeaderTemplate>
        <ul class="list-group">
    </HeaderTemplate>

    <ItemTemplate>
        <li class="list-group-item">
            <%# Eval("Nombre") %> <%# Eval("Apellido") %>
            <br />
            <small class="text-muted"><%# Eval("Email") %></small>
        </li>
    </ItemTemplate>

    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>



</asp:Content>
