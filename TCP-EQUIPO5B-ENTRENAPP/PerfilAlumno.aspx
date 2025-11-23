<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">

        <asp:Repeater ID="RepeaterDia" runat="server" OnItemDataBound="RepeaterDia_ItemDataBound">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card border-secondary  mb-3" style="max-width: 18rem;">
                        <div class="card-header bg-light  border-secondary fw-bold "><%#Eval("NombreDia")%></div>
                        <div class="card-body text-secondary">
                            <%--<h5 class="card-title">EJERCICIOS</h5>--%>
                            <asp:Repeater ID="RepeaterEjerAsig" runat="server">
                                <ItemTemplate>
                                    <p class="card-text"><%#Eval("EjercicioBase.Nombre") %></p>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="card-footer bg-light border-secondary">
                            <div>
                                <a href="/RutinaAlumno" type="button" class="btn btn-primary" role="button">Ver rutina completa </a>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
