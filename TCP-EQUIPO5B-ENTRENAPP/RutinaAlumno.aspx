<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutinaAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.RutinaAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="text-center">
                <h1 id="HTresNombreAlumno" runat="server"></h1>
                <h3 id="HTresNombreProfe" runat="server"></h3>
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
                        <div class="card-footer bg-light border-secondary">
                        </div>
                        <div id="DivAluRealizado" runat="server" class="card-header bg-light border-secondary fw-bold text-center">Realizado por Alumno:</div>
                        <table class="table table-sm text-secondary mb-0 align-middle">
                            <thead>
                                <tr>
                                    <th scope="col">EJERCICIOS</th>
                                    <th scope="col" class="text-center">SERIES</th>
                                    <th scope="col" class="text-center">REPES</th>
                                    <th scope="col" class="text-center">PESO(kg)</th>
                                    <th scope="col" class="text-center">COMENTARIOS</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RepeaterEjerAlu" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("EjercicioBase.Nombre") %></td>
                                            <td>
                                                <asp:TextBox ID="tbxSeriesRep"
                                                    runat="server"
                                                    Text='<%# Eval("Series") %>'
                                                    placeholder="Completar"
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Número de series" />
                                                <asp:RegularExpressionValidator
                                                    ID="revSeriesRep"
                                                    runat="server"
                                                    ControlToValidate="tbxSeriesRep"
                                                    ValidationExpression="^\d+$"
                                                    ErrorMessage="Solo números"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxRepeticionesRep"
                                                    runat="server"
                                                    Text='<%# Eval("Repeticiones") %>'
                                                    placeholder="Completar"
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Número de series" />
                                                <asp:RegularExpressionValidator
                                                    ID="revRepeticionesRep"
                                                    runat="server"
                                                    ControlToValidate="tbxRepeticionesRep"
                                                    ValidationExpression="^\d+$"
                                                    ErrorMessage="Solo números"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPesoRep"
                                                    runat="server"
                                                    Text='<%# Eval("Peso") %>'
                                                    placeholder="Completar"
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Número de series" />
                                                <asp:RegularExpressionValidator
                                                    ID="revPesoRep"
                                                    runat="server"
                                                    ControlToValidate="tbxPesoRep"
                                                    ValidationExpression="^\d+([,]\d{1,2})?$"
                                                    ErrorMessage="Solo números: 0 o 0,50"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxObservacionesRep"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm"
                                                    TextMode="MultiLine"
                                                    Rows="1" />
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="hfIdEjerAlu" runat="server" Value='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>

                </div>
                <div class="text-center">
                    <asp:Button ID="BtnDiaCompletado" runat="server" Text="✅ COMPLETAR DÍA" class="btn btn-primary" OnClick="BtnDiaCompletado_Click" OnClientClick="return confirm('¿Está seguro que desea Guardar el Dia Completado?');" />
                </div>
            </div>
        </div>
    </div>



</asp:Content>
