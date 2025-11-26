<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestor.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.Gestor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>PROFESORES</h4>
    </div>

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
                                Rows="1" />

                        </td>
                        <td>
                            <asp:TextBox ID="tbxApellido"
                                runat="server"
                                Text='<%# Eval("Apellido") %>'
                                placeholder='<%# Eval("Apellido") %>'
                                CssClass="form-control form-control-sm"
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
                            <asp:RegularExpressionValidator
                                ID="revEmail"
                                runat="server"
                                ControlToValidate="tbxEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="El formato del email es incorrecto (ej: usuario@dominio.com)"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="tbxTelefono"
                                runat="server"
                                Text='<%# Eval("Telefono") %>'
                                placeholder='<%# Eval("Telefono") %>'
                                CssClass="form-control form-control-sm"
                                Rows="1" />
                            <asp:RegularExpressionValidator
                                ID="revTelefono"
                                runat="server"
                                ControlToValidate="tbxTelefono"
                                ValidationExpression="^\d+$"
                                ErrorMessage="Solo números"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>

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

                            <asp:DropDownList
                                ID="ddlStatus"
                                CssClass="form-control form-control-sm text-center"
                                runat="server"
                                SelectedValue='<%# Eval("Status").ToString() %>'>

                                <asp:ListItem Text="True" Value="True" />
                                <asp:ListItem Text="False" Value="False" />
                            </asp:DropDownList>

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

    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>AGREGAR PROFESOR NUEVO</h4>
    </div>


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


        <tbody>
            <tr>
                <td>
                    <asp:TextBox ID="tbxNombreAgregar"
                        runat="server"
                        Text=""
                        CssClass="form-control form-control-sm"
                        Rows="1" />
                </td>
                <td>
                    <asp:TextBox ID="tbxApellidoAgregar"
                        runat="server"
                        Text=""
                        CssClass="form-control form-control-sm"
                        Rows="1" />

                </td>
                <td>
                    <asp:TextBox ID="tbxEmailAgregar"
                        runat="server"
                        Text=""
                        CssClass="form-control form-control-sm"
                        TextMode="MultiLine"
                        Rows="1" />
                    <asp:RegularExpressionValidator
                        ID="revEmail"
                        runat="server"
                        ControlToValidate="tbxEmailAgregar"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="El formato del email es incorrecto (ej: usuario@dominio.com)"
                        Display="Dynamic"
                        CssClass="text-danger small"
                        ForeColor="Red"
                        SetFocusOnError="True">
                    </asp:RegularExpressionValidator>

                </td>
                <td>
                    <asp:TextBox ID="tbxTelefonoAgregar"
                        runat="server"
                        Text=""
                        CssClass="form-control form-control-sm"
                        Rows="1" />
                    <asp:RegularExpressionValidator
                        ID="revTelefono"
                        runat="server"
                        ControlToValidate="tbxTelefonoAgregar"
                        ValidationExpression="^\d+$"
                        ErrorMessage="Solo números"
                        Display="Dynamic"
                        CssClass="text-danger small"
                        ForeColor="Red"
                        SetFocusOnError="True">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator
                        ID="rfvTelefono"
                        runat="server"
                        ControlToValidate="tbxTelefono"
                        ErrorMessage="Campo obligatorio"
                        Text="Campo obligatorio *"
                        ForeColor="Red"
                        Display="Dynamic" />

                </td>
                <td>
                    <asp:TextBox ID="tbxEdadAgregar"
                        runat="server"
                        Text=""
                        CssClass="form-control form-control-sm text-center"
                        ToolTip="Edad" />
                    <asp:RegularExpressionValidator
                        ID="revEdad"
                        runat="server"
                        ControlToValidate="tbxEdadAgregar"
                        ValidationExpression="^\d+$"
                        ErrorMessage="Solo números"
                        Display="Dynamic"
                        CssClass="text-danger small"
                        ForeColor="Red"
                        SetFocusOnError="True">
                    </asp:RegularExpressionValidator>

                </td>

                <td>

                    <asp:DropDownList
                        ID="ddlStatusAgregar"
                        CssClass="form-control form-control-sm text-center"
                        runat="server">

                        <asp:ListItem Text="True" Value="True" />
                        <asp:ListItem Text="False" Value="False" />
                    </asp:DropDownList>

                </td>
                <td>
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <asp:Button ID="Button1" runat="server" Text="➕ Nuevo Profesor" class="btn btn-primary" CommandName="NuevoProfesor" OnCommand="BtnAgregarProfesor_Command" OnClientClick="return confirm('¿Está seguro que desea Agregar Profesor Nuevo?');" />

                    </div>
                </td>
            </tr>

        </tbody>
    </table>

    <br />
    <br />


    <div class="text-center" aria-labelledby="gettingStartedTitle">
        <h4>ALUMNOS</h4>
    </div>

    <table class="table table-sm text-secondary mb-0 align-middle">
        <thead>
            <tr>
                <th scope="col" class="text-center">NOMBRE</th>
                <th scope="col" class="text-center">APELLIDO</th>
                <th scope="col" class="text-center">EMAIL</th>
                <th scope="col" class="text-center">FECHA FIN SUSCRPCION</th>
                <th scope="col" class="text-center">TELEFONO</th>
                <th scope="col" class="text-center">EDAD</th>
                <th scope="col" class="text-center">STATUS</th>
            </tr>
        </thead>

        <asp:Repeater ID="rptGestorAlumno" runat="server">
            <ItemTemplate>

                <tbody>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbxNombreAlumno"
                                runat="server"
                                Text='<%# Eval("Nombre") %>'
                                placeholder='<%# Eval("Nombre") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />

                        </td>
                        <td>
                            <asp:TextBox ID="tbxApellidoAlumno"
                                runat="server"
                                Text='<%# Eval("Apellido") %>'
                                placeholder='<%# Eval("Apellido") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />

                        </td>
                        <td>
                            <asp:TextBox ID="tbxEmailAlumno"
                                runat="server"
                                Text='<%# Eval("Email") %>'
                                placeholder='<%# Eval("Email") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                            <asp:RegularExpressionValidator
                                ID="revEmail"
                                runat="server"
                                ControlToValidate="tbxEmailAlumno"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ErrorMessage="El formato del email es incorrecto (ej: usuario@dominio.com)"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="tbxFechaFinSuscripcion"
                                runat="server"
                                Text='<%# Eval("FechaFinSuscripcion") %>'
                                placeholder='<%# Eval("FechaFinSuscripcion") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                            <asp:CustomValidator
                                ID="cvFechaFinSuscripcion"
                                runat="server"
                                ControlToValidate="tbxFechaFinSuscripcion"
                                ErrorMessage="El formato de la fecha es incorrecto (AAAA/MM/DD) o la fecha no es válida."
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True"
                                OnServerValidate="cvFechaFinSuscripcion_ServerValidate" />


                        </td>
                        <td>
                            <asp:TextBox ID="tbxTelefonoAlumno"
                                runat="server"
                                Text='<%# Eval("Telefono") %>'
                                placeholder='<%# Eval("Telefono") %>'
                                CssClass="form-control form-control-sm"
                                TextMode="MultiLine"
                                Rows="1" />
                            <asp:RegularExpressionValidator
                                ID="revTelefono"
                                runat="server"
                                ControlToValidate="tbxTelefonoAlumno"
                                ValidationExpression="^\d+$"
                                ErrorMessage="Solo números"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>

                        </td>
                        <td>
                            <asp:TextBox ID="tbxEdadAlumno"
                                runat="server"
                                Text='<%# Eval("Edad") %>'
                                placeholder='<%# Eval("Edad") %>'
                                CssClass="form-control form-control-sm text-center"
                                ToolTip="Edad" />
                            <asp:RegularExpressionValidator
                                ID="revEdad"
                                runat="server"
                                ControlToValidate="tbxEdadAlumno"
                                ValidationExpression="^\d+$"
                                ErrorMessage="Solo números"
                                Display="Dynamic"
                                CssClass="text-danger small"
                                ForeColor="Red"
                                SetFocusOnError="True">
                            </asp:RegularExpressionValidator>

                        </td>

                        <td>

                            <asp:DropDownList
                                ID="ddlStatusAlumno"
                                CssClass="form-control form-control-sm text-center"
                                runat="server"
                                SelectedValue='<%# Eval("Status").ToString() %>'>

                                <asp:ListItem Text="True" Value="True" />
                                <asp:ListItem Text="False" Value="False" />
                            </asp:DropDownList>

                        </td>
                        <td>
                            <div class="btn-group" role="group" aria-label="Basic example">
                                <asp:Button ID="btnEditarAlumno" runat="server" Text="✍" type="button" class="btn btn-primary" CommandName="IdAlumnoEditar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEditarAlumno_Command" OnClientClick="return confirm('¿Está seguro que desea Editar el Alumno seleccionado?');" />
                                <asp:Button ID="BtnEliminarAlumno" runat="server" Text="🗑" type="button" class="btn btn-primary" CommandName="IdAlumnoEliminar" CommandArgument='<%#Eval("Id")%>' OnCommand="BtnEliminarAlumno_Command" OnClientClick="return confirm('¿Está seguro que desea Eliminar el Alumno seleccionado?');" />
                            </div>
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>

        </asp:Repeater>
    </table>







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
