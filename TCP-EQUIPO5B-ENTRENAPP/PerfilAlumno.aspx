<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.PerfilAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h1 id="HTresNombreAlumno" runat="server"></h1>
        <h3 id="HTresNombreProfe" runat="server"></h3>
        <h3 id="HTresNombreRutina" runat="server"></h3>
        <h3 id="HTresNombreRutinaDescrip" runat="server"></h3>
        <br>
    </div>
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
                                <asp:Button ID="BtnVerRutina" Text="Ver rutina completa" runat="server" class="btn btn-primary" role="button" CommandName="VerDia" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnVerRutina_Command" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
