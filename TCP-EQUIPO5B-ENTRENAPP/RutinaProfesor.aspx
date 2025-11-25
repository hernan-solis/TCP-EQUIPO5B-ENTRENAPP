<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RutinaProfesor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.RutinaProfesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="text-center">

        <h3 id="HTresNombreAlumno" runat="server"></h3>

        <h3 id="HTresNombreRutina" runat="server"></h3>
        <div class="d-flex justify-content-center my-2">
            <asp:TextBox ID="TbxNombreRutina"
                runat="server"
                placeholder="Aqui Nombre Nuevo + Lapicito -->"
                Text=""
                CssClass="form-control form-control-sm text-center"
                ToolTip="Nuevo Nombre Rutina" />
            <asp:Button ID="BtnEditarNombreRutina" runat="server" Text="✍" class="btn btn-primary" OnClick="BtnEditarNombreRutina_Click" OnClientClick="return confirm('¿Está seguro que desea Editar el Nombre de la Rutina?');" />
        </div>

        <h3 id="HTresDescripRutina" runat="server"></h3>
        <div class="d-flex justify-content-center my-2">
            <asp:TextBox ID="TbxDescripcionRutina"
                runat="server"
                placeholder="Aqui Descripcion Nueva + Lapicito -->"
                Text=""
                CssClass="form-control form-control-sm text-center"
                ToolTip="Nuevo Descripcion Rutina" />
            <asp:Button ID="BtnEditarDescripcionRutina" runat="server" Text="✍" class="btn btn-primary" OnClick="BtnEditarDescripcionRutina_Click" OnClientClick="return confirm('¿Está seguro que desea Editar la Descripcion de la Rutina?');" />
        </div>

    </div>

    <asp:Button ID="BtnAgregarDia" runat="server" Text="✙ Nuevo Dia" class="btn btn-primary" OnClick="BtnAgregarDia_Click" OnClientClick="return confirm('¿Está seguro que desea Agregar Dia Nuevo?');" />

    <asp:Repeater ID="RepeaterDiaAlu" runat="server" OnItemDataBound="RepeaterDiaAlu_ItemDataBound">
        <ItemTemplate>
            <div class="container mt-5">
                <div class="row justify-content-center">

                    <div class="col-auto col-lg-auto">
                        <div class="card border-secondary mb-3">

                            <div class="card-header bg-light border-secondary fw-bold text-center">
                                <%#Eval("NombreDia") %>
                                <asp:Button ID="BtnEliminarDia" runat="server" Text="🗑" type="button" class="btn btn-primary" CommandName="IdDiaEliminar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEliminarDia_Command" OnClientClick="return confirm('¿Está seguro que desea Eliminar el Día seleccionado?');" />
                                <div class="d-flex justify-content-center my-2">
                                    <asp:TextBox ID="TbxNombreDia"
                                        runat="server"
                                        placeholder="Aqui Nombre Nuevo + Lapicito -->"
                                        Text=""
                                        CssClass="form-control form-control-sm text-center"
                                        ToolTip="Nuevo Nombre Dia" />
                                    <asp:Button ID="BtnEditarNombreDia" runat="server" Text="✍" class="btn btn-primary" CommandName="IdDiaEditar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEditarNombreDia_Command" OnClientClick="return confirm('¿Está seguro que desea Editar el Día seleccionado?');" />
                                </div>


                            </div>

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
                                            <th scope="col" class="text-center">LINK DRIVE MULTIMEDIA ALUMNO</th>
                                            <th scope="col" class="text-center">Editar/Eliminar</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <asp:Repeater ID="RepeaterEjerAsigDiaAlu" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("EjercicioBase.Nombre") %></td>
                                                    <td>
                                                        <asp:TextBox ID="tbxSeriesRep"
                                                            runat="server"
                                                            Text='<%# Eval("Series") %>'
                                                            placeholder='<%# Eval("Series") %>'
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
                                                            placeholder='<%# Eval("Repeticiones") %>'
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
                                                        <asp:TextBox ID="tbxTiempoEstimadoRep"
                                                            runat="server"
                                                            Text='<%# Eval("TiempoEstimado") %>'
                                                            placeholder='<%# Eval("TiempoEstimado") %>'
                                                            CssClass="form-control form-control-sm text-center"
                                                            ToolTip="Número de series" />
                                                        <asp:RegularExpressionValidator
                                                            ID="revTiempoEstimadoRep"
                                                            runat="server"
                                                            ControlToValidate="tbxTiempoEstimadoRep"
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
                                                            placeholder='<%# Eval("Peso") %>'
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
                                                            Text='<%# Eval("Observaciones") %>'
                                                            placeholder='<%# Eval("Observaciones") %>'
                                                            CssClass="form-control form-control-sm"
                                                            TextMode="MultiLine"
                                                            Rows="1" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxUrlRep"
                                                            runat="server"
                                                            Text='<%# Eval("Url") %>'
                                                            placeholder='<%# Eval("Url") %>'
                                                            CssClass="form-control form-control-sm text-center"
                                                            ToolTip="Url Link para que el alumno suba el video" />
                                                    </td>
                                                    <td>
                                                        <div class="btn-group" role="group" aria-label="Basic example">
                                                            <asp:Button ID="BtnEditar" runat="server" Text="✍" type="button" class="btn btn-primary" CommandName="IdEjerSeleccionadoAEditar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEditar_Command" OnClientClick="return confirm('¿Está seguro que desea Editar el Ejercicio seleccionado?');" />
                                                            <asp:Button ID="BtnEliminar" runat="server" Text="🗑" type="button" class="btn btn-primary" CommandName="IdEjerSeleccionado" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEliminar_Command" OnClientClick="return confirm('¿Está seguro que desea Eliminar el Ejercicio seleccionado?');" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </tbody>
                                </table>
                            </div>

                            <div class="card-footer bg-light border-secondary">
                                <table class="table table-bordered table-striped table-sm">
                                    <tbody>
                                        <tr>
                                            <th scope="col">EJERCICIOS</th>
                                            <th scope="col" class="text-center">SERIES</th>
                                            <th scope="col" class="text-center">REPETICIONES</th>
                                            <th scope="col" class="text-center">DESCANSO (min)</th>
                                            <th scope="col" class="text-center">PESO (kg)</th>
                                            <th scope="col" class="text-center">OBSERVACIONES</th>
                                            <th scope="col" class="text-center">LINK DRIVE ALU</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList
                                                    ID="DdlEjercicios"
                                                    runat="server">
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="tbxSeries"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Número de series" />
                                                <asp:RegularExpressionValidator
                                                    ID="revSeries"
                                                    runat="server"
                                                    ControlToValidate="tbxSeries"
                                                    ValidationExpression="^\d+$"
                                                    ErrorMessage="Solo números"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="tbxRepeticiones"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Número de repeticiones" />
                                                <asp:RegularExpressionValidator
                                                    ID="RevRepeticiones"
                                                    runat="server"
                                                    ControlToValidate="tbxRepeticiones"
                                                    ValidationExpression="^\d+$"
                                                    ErrorMessage="Solo números"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="tbxDescanso"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Descanso en minutos" />
                                                <asp:RegularExpressionValidator
                                                    ID="RevDescanso"
                                                    runat="server"
                                                    ControlToValidate="tbxDescanso"
                                                    ValidationExpression="^\d+$"
                                                    ErrorMessage="Solo números"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="tbxPeso"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Peso utilizado en kilogramos" />
                                                <asp:RegularExpressionValidator
                                                    ID="RevPeso"
                                                    runat="server"
                                                    ControlToValidate="tbxPeso"
                                                    ValidationExpression="^\d+([,]\d{1,2})?$"
                                                    ErrorMessage="Solo números: 0 o 0,50"
                                                    Display="Dynamic"
                                                    CssClass="text-danger small"
                                                    ForeColor="Red"
                                                    SetFocusOnError="True">
                                                </asp:RegularExpressionValidator>
                                            </td>

                                            <td>
                                                <asp:TextBox ID="tbxObservaciones"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm"
                                                    TextMode="MultiLine"
                                                    Rows="1" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxUrl"
                                                    runat="server"
                                                    Text=""
                                                    CssClass="form-control form-control-sm text-center"
                                                    ToolTip="Url Link para que el alumno suba el video" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="text-left">
                                    <asp:Button ID="BtnAgregarEjercicioAsignado" Text="Asignar Nuevo Ejercicio" runat="server" class="btn btn-primary" role="button" CommandName="VerDia" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnAgregarEjercicioAsignado_Command" OnClientClick="return confirm('¿Está seguro que desea Guardar el Nuevo ejercicio asignado?');" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>


    <script>
        window.addEventListener('beforeunload', function () {
            sessionStorage.setItem('scrollY', window.scrollY);
        });

        window.addEventListener('load', function () {
            var y = sessionStorage.getItem('scrollY');
            if (y !== null) {
                window.scrollTo(0, y);
            }
        });
    </script>

</asp:Content>
