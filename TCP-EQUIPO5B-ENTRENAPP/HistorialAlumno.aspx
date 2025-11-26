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
                <th scope="col">FECHA</th>
                <th scope="col" >EJERCICIO</th>
                <th scope="col" >SERIES</th>
                <th scope="col" >REPETICIONES</th>
                <th scope="col" >PESO</th>
                <th scope="col" >OBSERVACIONES</th>
            </tr>
        </thead>
        <asp:Repeater ID="rptHistorialAlumno" runat="server">
            <ItemTemplate>

                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblFechaRegistro"
                                runat="server"
                                Text='<%# Eval("FechaRegistro", "{0:yyyy-MM-dd}") %>'
                                CssClass="form-control-static" />
                        </td>
                        <td>
                            <asp:Label ID="lblEjercicioAsignado"
                                runat="server"
                                Text='<%# Eval("EjercicioBase.Nombre") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="EjercicioAsignado" />
                        </td>

                        <td>
                            <asp:Label ID="lblSeries"
                                runat="server"
                                Text='<%# Eval("Series") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="Series" />
                        </td>
                        <td>
                            <asp:Label ID="lblRepeticiones"
                                runat="server"
                                Text='<%# Eval("Repeticiones") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="Repeticiones" />
                        </td>
                        <td>
                            <asp:Label ID="lblPeso"
                                runat="server"
                                Text='<%# Eval("Peso") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="Peso" />
                        </td>
                        <td>
                            <asp:Label ID="lblObservaciones"
                                runat="server"
                                Text='<%# Eval("Observaciones") %>'
                                CssClass="form-control-static"
                                ToolTip="Observaciones" />
                        </td>
                    </tr>
                </tbody>


            </ItemTemplate>

        </asp:Repeater>
    </table>

</asp:Content>
