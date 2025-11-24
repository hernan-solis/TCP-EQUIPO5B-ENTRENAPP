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
                <asp:TextBox ID="txtContrasena" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Repetir Contraseña</label>
                <asp:TextBox ID="txtRepetirContraseña" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Telefono</label>
                <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Edad</label>
                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>


        <div class="col-6">

            <div class="mb-3">
                <label class="form-label">Objetivos</label>
                <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Género</label>
                <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Días Disponibles</label>
                <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Lesiónes</label>
                <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Condición Médica</label>
                <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Comentarios</label>
                <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <section class="text-center">
        <a href="/Login" class="btn btn-primary btn-lg text-uppercase" role="button">Registrarme </a>
    </section>
</asp:Content>
