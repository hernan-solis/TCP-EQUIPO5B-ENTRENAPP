<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TCP_EQUIPO5B_ENTRENAPP.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="text-center" aria-labelledby="gettingStartedTitle">
        <h2 id="gettingStartedTitle">REGISTRATE</h2>
        <p>
            Completa tus datos para ser parte de Entrenapp
        </p>

    </section>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
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
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvApellido"
                    runat="server"
                    ControlToValidate="txtApellido"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
                <asp:RegularExpressionValidator
                    ID="revApellido"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{3,}$"
                    ErrorMessage="* El apellido solo puede contener letras y debe tener al menos 3 caracteres."
                    Text="* El apellido solo puede contener letras y debe tener al menos 3 caracteres."
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ErrorMessage="El email es incorrecto (ej: usuario@dominio.com)"
                    Display="Dynamic"
                    CssClass="text-danger small"
                    ForeColor="Red"
                    SetFocusOnError="True">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasenia" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvContrasenia"
                    runat="server"
                    ControlToValidate="txtContrasenia"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revTelefono"
                    runat="server"
                    ControlToValidate="txtTelefono"
                    ValidationExpression="^\d{10,}$"
                    ErrorMessage="Debe ingresar solo números, con un mínimo de 10 dígitos."
                    Display="Dynamic"
                    CssClass="text-danger small"
                    ForeColor="Red"
                    SetFocusOnError="True">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator
                    ID="rfvTelefono"
                    runat="server"
                    ControlToValidate="txtTelefono"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox ID="txtEdad" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator
                    ID="revEdad"
                    runat="server"
                    ControlToValidate="txtEdad"
                    ValidationExpression="^\d+$"
                    ErrorMessage="Solo números"
                    Display="Dynamic"
                    CssClass="text-danger small"
                    ForeColor="Red"
                    SetFocusOnError="True">
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator
                    ID="rfvEdad"
                    runat="server"
                    ControlToValidate="txtEdad"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>

        </div>


        <div class="col-6">

            <div class="mb-3">
                <label class="form-label">Objetivos</label>
                <asp:TextBox ID="txtObjetivos" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvObjetivos"
                    runat="server"
                    ControlToValidate="txtObjetivos"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Género</label>
                <asp:TextBox ID="txtGenero" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvGenero"
                    runat="server"
                    ControlToValidate="txtGenero"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Días Disponibles</label>
                <asp:TextBox ID="txtDiasDisponibles" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvDiasDisponibles"
                    runat="server"
                    ControlToValidate="txtDiasDisponibles"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Lesiones</label>
                <asp:TextBox ID="txtLesiones" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvLesiones"
                    runat="server"
                    ControlToValidate="txtLesiones"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Condición Médica</label>
                <asp:TextBox ID="txtCondicionMedica" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvCondicionMedica"
                    runat="server"
                    ControlToValidate="txtCondicionMedica"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <label class="form-label">Comentarios</label>
                <asp:TextBox ID="txtComentarios" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rfvComentarios"
                    runat="server"
                    ControlToValidate="txtComentarios"
                    ErrorMessage="Campo obligatorio"
                    Text="Campo obligatorio *"
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
        </div>
    </div>
    <section class="text-center">

        <asp:Button ID="btnRegistrarme" runat="server" class="btn btn-primary btn-lg text-uppercase" Text="Registrarme" OnClick="BtnRegistrarme_Click" />
    </section>
</asp:Content>
