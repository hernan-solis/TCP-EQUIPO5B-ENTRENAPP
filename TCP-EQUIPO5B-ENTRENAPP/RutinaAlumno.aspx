<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutinaAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.RutinaAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="text-center">
                <h3 id="HTresNombreAlumno" runat="server"></h3>
                <h3 id="HTresNombreRutina" runat="server"></h3>
                <h3 id="HTresNombreRutinaDescrip" runat="server"></h3>
                <br>
            </div>
            <div class="col-auto col-lg-auto">
                <div class="card border-secondary mb-3">

                    <div id="DivTituloDia" runat="server" class="card-header bg-light border-secondary fw-bold text-center"></div>

                    <div class="card-body text-secondary">

                        <table class="table table-sm text-secondary mb-0 align-middle">
                            <thead>
                                <tr>
                                    <th scope="col">EJERCICIOS</th>
                                    <th scope="col" class="text-center">SERIES</th>
                                    <th scope="col" class="text-center">REPES</th>
                                    <th scope="col" class="text-center">PESO(kg)</th>
                                    <th scope="col" class="text-center">DESCANSO(min)</th>
                                    <th scope="col" class="text-center">OBSERVACIONES</th>
                                    <th scope="col" class="text-center">VIDEO TUTORIAL </th>
                                    <th scope="col" class="text-center">LINK DRIVE</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterEjerciciosAsignados" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("EjercicioBase.Nombre") %></td>
                                            <td class="text-center"><%# Eval("Series") %></td>
                                            <td class="text-center"><%# Eval("Repeticiones") %></td>
                                            <td class="text-center"><%# Eval("Peso") %></td>
                                            <td class="text-center"><%# Eval("TiempoEstimado") %></td>
                                            <td class="text-center"><%# Eval("Observaciones") %></td>
                                            <td class="text-center">
                                                <a href='<%# Eval("EjercicioBase.Url") %>' target="_blank">Ver Video</a>
                                            </td>
                                            <td class="text-center">
                                                <a href='<%# Eval("Url") %>' target="_blank">Ir al DRIVE</a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                    <div class="card-footer bg-light border-secondary">
                        <div class="form-check form-switch">
                            <input class="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault">
                            <label class="form-check-label" for="flexSwitchCheckDefault">Realizado</label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
