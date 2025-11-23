<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProfesor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mis alumnos</h3>

    <asp:Repeater ID="rptAlumnos" runat="server">
        <HeaderTemplate>
            <ul class="list-group">
        </HeaderTemplate>
        <ItemTemplate>
            <li class="list-group-item">
                <%# Eval("Apellido") %> <%# Eval("Nombre") %> 
                <br />
                <small class="text-muted"><%# Eval("Email") %></small>
                <asp:Button ID="BtnVerRutina" runat="server" Text="VER RUTINA" class="btn btn-primary" role="button" CommandName="IdAlumno" CommandArgument=<%#Eval("Id")%> OnCommand="BtnVerRutina_Command" />
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>



</asp:Content>
