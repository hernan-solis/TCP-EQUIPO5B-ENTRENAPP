<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearNuevoEjercicio.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.CrearNuevoEjercicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>Nuevo Ejercicio</h4>

    </div>
    <div class="row">
        <div class="col-6">
            <label class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>

            <asp:RegularExpressionValidator
                ID="revNombre"
                runat="server"
                ControlToValidate="txtNombre"
                ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{3,}$"
                ErrorMessage="* El nombre solo puede contener letras y debe tener al menos 3 caracteres."
                Text="* El nombre solo puede contener letras y debe tener al menos 3 caracteres."
                ForeColor="Red"
                Display="Dynamic" />
        </div>
        <div class="mb-3">
            <label class="form-label">Descripcion</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server"></asp:TextBox>

        </div>
        <div class="mb-3">
            <label class="form-label">URL</label>
            <asp:TextBox ID="txtURL" CssClass="form-control" runat="server"></asp:TextBox>

        </div>
        <section>

            <asp:Button ID="btnAgregar" runat="server" class="btn btn-primary btn-lg text-uppercase" Text="Agregar" OnClick="BtnAgregar_Click" OnClientClick="return confirm('¿Está seguro que desea Guardar este ejercicio?');" />
        </section>


    </div>

    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>LISTA DE EJERCICIOS</h4>
    </div>



    <table class="table table-sm text-secondary mb-0 align-middle">
        <thead>
            <tr>
                <th scope="col">NOMBRE</th>
                <th scope="col">DESCRIPCION</th>
            </tr>
        </thead>
        <asp:Repeater ID="rptListarEjercicios" runat="server">
            <ItemTemplate>

                <tbody>
                    <tr>
                        <td>
                            <asp:Label ID="lblNombre"
                                runat="server"
                                Text='<%# Eval("Nombre") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="Series" />
                        </td>
                        <td>
                            <asp:Label ID="lblDescripcion"
                                runat="server"
                                Text='<%# Eval("Descripcion") %>'
                                CssClass="form-control-static text-center"
                                ToolTip="Repeticiones" />
                        </td>
                    </tr>
                </tbody>


            </ItemTemplate>

        </asp:Repeater>
    </table>


</asp:Content>
