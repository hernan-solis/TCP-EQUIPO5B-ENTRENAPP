<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.Gestor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>PROFESORES</h3>
    <table class="table table-sm text-secondary mb-0 align-middle">
        <thead>
            <tr>
                <th scope="col" class="text-center">NOMBRE</th>
                <th scope="col" class="text-center">APELLIDO</th>
                <th scope="col" class="text-center">EMAIL</th>
                <th scope="col" class="text-center">TELEFONO</th>
                <th scope="col" class="text-center">EDAD</th>
                <th scope="col" class="text-center">STATUS</th>
            </tr>
        </thead>

        <asp:Repeater ID="rptGestorProfesor" runat="server">
            <ItemTemplate>

                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbxNombre"
                                runat="server"
                                Text='<%# Eval("Nombre") %>'
                                placeholder='<%# Eval("Nombre") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxApellido"
                                runat="server"
                                Text='<%# Eval("Apellido") %>'
                                placeholder='<%# Eval("Apellido") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxEmail"
                                runat="server"
                                Text='<%# Eval("Email") %>'
                                placeholder='<%# Eval("Email") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxTelefono"
                                runat="server"
                                Text='<%# Eval("Telefono") %>'
                                placeholder='<%# Eval("Telefono") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbxEdad"
                                runat="server"
                                Text='<%# Eval("Edad") %>'
                                placeholder='<%# Eval("Edad") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Edad" />
                            <asp:RegularExpressionValidator
                                ID="revEdad"
                                runat="server"
                                ControlToValidate="tbxEdad"
                                ValidationExpression="^\d+$"
                                ErrorMessage="Solo números"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>
                        </td>

                        <td>
                            <asp:TextBox ID="tbxStatus"
                                runat="server"
                                Text='<%# Eval("Status") %>'
                                placeholder='<%# Eval("Status") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Status" />
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator1"
                                runat="server"
                                ControlToValidate="tbxStatus"
                                ValidationExpression="^[01]$"
                                ErrorMessage="Solo se permite ingresar 1 o 0"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <asp:Button ID="btnEditarProfe" runat="server" Text="✍" type="button" class="btn btn-primary" CommandName="IdProfesorEditar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEditarProfesor_Command" OnClientClick="return confirm('¿Está seguro que desea Editar el Profesor seleccionado?');" />

                                <asp:Button ID="BtnEliminarProfe" runat="server" Text="🗑" type="button" class="btn btn-primary" CommandName="IdProfesor" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEliminarProfesor_Command" OnClientClick="return confirm('¿Está seguro que desea Eliminar el Profesor seleccionado?');" />
                            </div>
                        </td>
                    </tr>


                </tbody>
            </ItemTemplate>

        </asp:Repeater>

    </table>

</asp:Content>
