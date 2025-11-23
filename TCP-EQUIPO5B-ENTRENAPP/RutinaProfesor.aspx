<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutinaProfesor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.RutinaProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center">
        <h3 id="HTresNombreAlumno" runat="server"></h3>

    </div>


    <asp:Repeater ID="RepeaterDiaAlu" runat="server" OnItemDataBound="RepeaterDiaAlu_ItemDataBound">
        <ItemTemplate>
            <div class="container mt-5">
                <div class="row justify-content-center">

                    <div class="col-auto col-lg-auto">
                        <div class="card border-secondary mb-3">

                            <div class="card-header bg-light border-secondary fw-bold text-center"><%#Eval("NombreDia") %></div>

                            <div class="card-body text-secondary">

                                <table class="table table-sm text-secondary mb-0 align-middle">
                                    <thead>
                                        <tr>
                                            <th scope="col">EJERCICIOS</th>
                                            <th scope="col" class="text-center">SERIES</th>
                                            <th scope="col" class="text-center">REPETICIONES</th>
                                            <th scope="col" class="text-center">DESCANSO (min)</th>
                                            <th scope="col" class="text-center">PESO (kg)</th>
                                            <th scope="col" class="text-center">OBSERVACIONES</th>
                                            <th scope="col" class="text-center">VIDEO DEMOSTRATIVO </th>
                                            <th scope="col" class="text-center">Editar/Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="RepeaterEjerAsigDiaAlu" runat="server" >
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("EjercicioBase.Nombre") %></td>
                                                    <td class="text-center"><%# Eval("Series") %></td>
                                                    <td class="text-center"><%# Eval("Repeticiones") %></td>
                                                    <td class="text-center"><%# Eval("TiempoEstimado") %></td>
                                                    <td class="text-center"><%# Eval("Peso") %></td>
                                                    <td class="text-center"><%# Eval("Observaciones") %></td>
                                                    <td class="text-center"><%# Eval("EjercicioBase.Url") %></td>
                                                    <td>
                                                        <div class="btn-group" role="group" aria-label="Basic example">
                                                            <button type="button" class="btn btn-primary">✍</button>
                                                            <button type="button" class="btn btn-primary">🗑</button>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>

                            <div class="card-footer bg-light border-secondary">
                                <div class="text-left">
                                    <button type="button" class="btn btn-primary">Agregar Ejercicio</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
