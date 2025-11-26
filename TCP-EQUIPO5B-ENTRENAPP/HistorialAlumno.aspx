<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistorialAlumno.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.HistorialAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>Historial</h4>
    </div>

    <div class="row mb-3">
        <div class="col-md-4">
            <asp:TextBox ID="tbxFiltroEjercicio" runat="server" CssClass="form-control" placeholder="Filtrar por nombre de ejercicio"></asp:TextBox>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
        </div>
    </div>

    <table class="table table-sm text-secondary mb-0 align-middle">
        <thead>
            <tr>
                <th scope="col" class="text-center">FECHA</th>
                <th scope="col" class="text-center">EJERCICIO</th>
                <th scope="col" class="text-center">SERIES</th>
                <th scope="col" class="text-center">REPETICIONES</th>
                <th scope="col" class="text-center">PESO</th>
                <th scope="col" class="text-center">OBSERVACIONES</th>
            </tr>
        </thead>
        <asp:Repeater ID="rptHistorialAlumno" runat="server">
            <ItemTemplate>

                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbxFechaRegistro"
                                runat="server"
                                Text='<%# Eval("FechaRegistro", "{0:yyyy-MM-dd}") %>'
                                CssClass="form-control form-control-sm"
                                Rows="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxEjercicioAsignado"
                                runat="server"
                                Text='<%# Eval("EjercicioBase.Nombre") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="EjercicioAsignado" />

                        </td>
                        <td>
                            <asp:TextBox ID="tbxSeries"
                                runat="server"
                                Text='<%# Eval("Series") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Series" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxRepeticiones"
                                runat="server"
                                Text='<%# Eval("Repeticiones") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Repeticiones" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxPeso"
                                runat="server"
                                Text='<%# Eval("Peso") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Peso" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxObservaciones"
                                runat="server"
                                Text='<%# Eval("Observaciones") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                        </td>
                    </tr>
                </tbody>


            </ItemTemplate>

        </asp:Repeater>
    </table>

</asp:Content>
