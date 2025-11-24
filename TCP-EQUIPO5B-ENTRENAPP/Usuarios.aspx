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
            </div>

            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox ID="txtContrasenia" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox ID="txtEdad" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>


        <div class="col-6">

            <div class="mb-3">
                <label class="form-label">Objetivos</label>
                <asp:TextBox ID="txtObjetivos" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Género</label>
                <asp:TextBox ID="txtGenero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Días Disponibles</label>
                <asp:TextBox ID="txtDiasDisponibles" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Lesiones</label>
                <asp:TextBox ID="txtLesiones" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Condición Médica</label>
                <asp:TextBox ID="txtCondicionMedica" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Comentarios</label>
                <asp:TextBox ID="txtComentarios" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <section class="text-center">
       
        <asp:Button ID="btnRegistrarme" runat="server" class="btn btn-primary btn-lg text-uppercase" Text="Registrarme" OnClick ="BtnRegistrarme_Click"/>
    </section>
</asp:Content>
